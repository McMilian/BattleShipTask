using BattleShipTask.Constants;
using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using Serilog;
using System;
using BattleShipTask.Configuration;
using BattleShipTask.Extensions;

namespace BattleShipTask.Services
{
    public class GameplayService : IGameplayService
    {
        private readonly IPlayersBoardFactory _playersBoardFactory;
        private readonly IDrawingService _drawingService;
        private readonly IUserCommandsService _userCommandsService;

        private const int SeedMultiplier = 10000;
        private const int BoardSize = 10;

        public GameplayService(IDrawingService drawingService,
            IUserCommandsService userCommandsService, IPlayersBoardFactory playersBoardFactory)
        {
            _drawingService = drawingService;
            _userCommandsService = userCommandsService;
            _playersBoardFactory = playersBoardFactory;
        }

        public void StartGame()
        {
            Log.Information("Game started");

            var playersSeed = _userCommandsService.SetAndValidateSeed(GameConstants.InsertSeed);
            var opponentsSeed = _userCommandsService.SetAndValidateSeed(GameConstants.InsertOpponentsSeed);

            var turnAnswer = _userCommandsService.SetAndValidateValue(GameConstants.PickStartingPlayer, GameConstants.YesNoRegex);

            Log.Information("Game Configuration: {0}, {1}, {2} ", playersSeed.ToString(), opponentsSeed.ToString(), turnAnswer);

            var isPlayersTurn = turnAnswer.IsTrue();

            var playersBoard = _playersBoardFactory.Create(BoardSize, playersSeed);
            var opponentsBoard = _playersBoardFactory.Create(BoardSize, opponentsSeed + SeedMultiplier);

            do
            {
                _drawingService.DrawBoards(playersBoard, opponentsBoard);

                var shot = GetShotPosition(isPlayersTurn);

                if (isPlayersTurn)
                {
                    ExecuteShooting(playersBoard, opponentsBoard, shot);
                }
                else
                {
                    ExecuteShooting(opponentsBoard, playersBoard, shot);
                }

                isPlayersTurn = !isPlayersTurn;

                
            }
            while (opponentsBoard.HasAnyUndestroyedShip() && playersBoard.HasAnyUndestroyedShip());

            FinishGame(playersBoard.HasAnyUndestroyedShip());
        }

        private Position GetShotPosition(bool isPlayersTurn)
        {
            string name = isPlayersTurn ? "YOUR" : "OPPONENT'S";

            var coordinates = _userCommandsService.SetAndValidateValue(GameConstants.InsertShotCoordinates(name), 
                GameConstants.ShotCoordinatesRegex);

            Log.Information("IsPlayersTurn: {0}, shot: {1}", isPlayersTurn.ToString(), coordinates);

            var row = GameConstants.AlphabetLetters.FindIndex(a => a.Contains(coordinates.Substring(0, 1).ToUpper())) + 1;
            var column = int.Parse(coordinates.Substring(1));

            return new Position(row, column);
        }

        private void ExecuteShooting(PlayersBoard shooter, PlayersBoard defender, Position shot)
        {
            var shotField = defender.ShootingOutcome(shot);

            if (shotField == Content.Ship)
            {
                var shotShip = defender.GetDamagedShip(shot);

                shotShip.DestroyShipPart(shot);

                Console.WriteLine(shotShip.IsDestroyed ? GameConstants.ShipDestroyed : GameConstants.ShipDamaged);
            }
            else
            {
                if (shotField == Content.Wreck)
                {
                    Console.WriteLine("You shot the wreck!");
                }
                else
                {
                    Console.WriteLine(GameConstants.ShotMissed);
                    shooter.MissedShotsExecuted.Add(shot);
                    defender.MissedShotsReceived.Add(shot);
                }
            }
        }

        public static void FinishGame(bool isPlayerTheWinner)
        {
            Console.WriteLine(isPlayerTheWinner ? GameConstants.PlayerWonInfo : GameConstants.PlayerLostInfo);

            Log.Information("Game finished. isPlayerTheWinner: {0}", isPlayerTheWinner.ToString());
        }
    }
}
