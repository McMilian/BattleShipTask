using BattleShipTask.Constants;
using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using BattleShipTask.Models.Enums;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BattleShipTask.Services
{
    public class GameplayService : IGameplayService
    {
        private readonly IShipsLocationGenerationService _shipsLocationGenerationService;
        private readonly IDrawingService _drawingService;
        private readonly IUserCommandsService _userCommandsService;

        public GameplayService(IShipsLocationGenerationService shipsLocationGenerationService, IDrawingService drawingService,
            IUserCommandsService userCommandsService)
        {
            _shipsLocationGenerationService = shipsLocationGenerationService;
            _drawingService = drawingService;
            _userCommandsService = userCommandsService;
        }

        public void StartGameOnePlayer()
        {
            //Generate both battlefields
            var player1Board = new PlayersBoard("MACIEJ", _shipsLocationGenerationService.GenerateShipsLocationWithSeed(10, new ShipsConfiguration(), new Random().Next(1, 10000)));
            var player2Board = new PlayersBoard("KAROLINA", _shipsLocationGenerationService.GenerateShipsLocationWithSeed(10, new ShipsConfiguration(), new Random().Next(1, 10000)));

            do
            {
                _drawingService.DrawBothBattlefieldsUsingShips(player1Board, player2Board);

                var shot = GetShotPosition(true);
                
                //logika oznaczania shota:
                var isShipShot = player2Board.Ships.SelectMany(ship => ship.Parts).SingleOrDefault(x => x.Position.Row == shot.Row && x.Position.Column == shot.Column)?
                    .Content == FieldValue.Ship;

                if (isShipShot)
                {
                    var shotShip = player2Board.Ships.First(ship => ship.Parts.SingleOrDefault(x => x.Position.Row == shot.Row && x.Position.Column == shot.Column)?
                        .Content == FieldValue.Ship);

                    shotShip.Parts.Single(x => x.Position.Row == shot.Row && x.Position.Column == shot.Column).Content = FieldValue.Wreck;
                    shotShip.HealthPoints--;
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
                    Console.WriteLine(GameConstants.ShotMissed);
                    player1Board.MissedShotsExecuted.Add(shot);
                    player2Board.MissedShotsReceived.Add(shot);
                }
            }
            while (player2Board.HasAnyUndestroyedShip());

            //Console.WriteLine(GameConstants.GameOver); //TODO: do zmiany
        }

        public void StartGameTwoPlayers()
        {
            var playersSeed = _userCommandsService.SetAndValidateValue(GameConstants.InsertSeed, (seed) => seed > 1 && seed < 10001); //TODO: zrób coś z tą funkcją
            var opponentsSeed = _userCommandsService.SetAndValidateValue(GameConstants.InsertOpponentsSeed, (seed) => seed > 1 && seed < 10001);

            var turnAnswer = _userCommandsService.SetAndValidateValue(GameConstants.PickStartingPlayer, GameConstants.YesNoRegex);

            var isPlayersTurn = turnAnswer.IsTrue();

            //Generate both battlefields
            var playersBoard = new PlayersBoard("MACIEJ", _shipsLocationGenerationService.GenerateShipsLocationWithSeed(10, new ShipsConfiguration(), playersSeed)); //TODO: co z imionami?
            var opponentsBoard = new PlayersBoard("KAROLINA", _shipsLocationGenerationService.GenerateShipsLocationWithSeed(10, new ShipsConfiguration(), opponentsSeed));

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

            var row = GameConstants.AlphabetLetters.FindIndex(a => a.Contains(coordinates.Substring(0, 1).ToUpper())) + 1;
            var column = int.Parse(coordinates.Substring(1));

            return new Position(row, column);
        }

        private void ExecuteShooting(PlayersBoard shooter, PlayersBoard defender, Position shot)
        {
            //logika oznaczania shota:
            var shotField = defender.Ships.SelectMany(ship => ship.Parts).SingleOrDefault(x => x.Position.Row == shot.Row && x.Position.Column == shot.Column)?
                .Content;

            if (shotField == FieldValue.Ship)
            {
                var shotShip = defender.Ships.First(ship => ship.Parts.SingleOrDefault(x => x.Position.Row == shot.Row && x.Position.Column == shot.Column)?
                    .Content == FieldValue.Ship);

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
                if (shotField == FieldValue.Wreck)
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
        }
    }
}
