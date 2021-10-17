using BattleShipTask.Constants;
using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using Serilog;
using System;

namespace BattleShipTask.Services
{
    public class GameplayService : IGameplayService
    {
        private readonly IPlayersBoardFactory _playersBoardFactory;
        private readonly IDrawingService _drawingService;
        private readonly IUserCommandsService _userCommandsService;

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

            var playersSeed = _userCommandsService.SetAndValidateValue(GameConstants.InsertSeed, (seed) => seed > 0 && seed < 10001); //TODO: zrób coś z tą funkcją
            var opponentsSeed = _userCommandsService.SetAndValidateValue(GameConstants.InsertOpponentsSeed, (seed) => seed > 0 && seed < 10001);

            var turnAnswer = _userCommandsService.SetAndValidateValue(GameConstants.PickStartingPlayer, GameConstants.YesNoRegex);

            Log.Information("Game Configuration: {0}, {1}, {2} ", playersSeed.ToString(), opponentsSeed.ToString(), turnAnswer);

            var isPlayersTurn = turnAnswer.IsTrue();

            //Generate both battlefields
            var playersBoard = _playersBoardFactory.Create(10, new ShipsConfiguration(), playersSeed); // TODO: ShipsConfiguration to be set in appsettings
            var opponentsBoard = _playersBoardFactory.Create(10, new ShipsConfiguration(), opponentsSeed + 10000);

            do
            {
                _drawingService.DrawBothBattlefieldsUsingShips(playersBoard, opponentsBoard);

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

                if (shotShip.IsDestroyed)
                {
                    Console.WriteLine(GameConstants.ShipDestroyed);
                }
                else
                {
                    Console.WriteLine(GameConstants.ShipDamaged);
                }
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
            if (isPlayerTheWinner)
            {
                Console.WriteLine(GameConstants.PlayerWonInfo);
            }
            else
            {
                Console.WriteLine(GameConstants.PlayerLostInfo);
            }

            Log.Information("Game finished. isPlayerTheWinner: {0}", isPlayerTheWinner.ToString());
        }
    }
}
