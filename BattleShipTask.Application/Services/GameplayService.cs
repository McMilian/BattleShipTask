using BattleShipTask.Application.Constants;
using BattleShipTask.Application.Extensions;
using BattleShipTask.Application.Interfaces;
using BattleShipTask.Application.Models;
using BattleShipTask.Application.Models.Enums;
using BattleShipTask.Infrastructure.Interfaces;
using Serilog;

namespace BattleShipTask.Application.Services
{
    public class GameplayService : IGameplayService
    {
        private readonly IPlayersBoardFactory _playersBoardFactory;
        private readonly IDrawingService _drawingService;
        private readonly IUserCommandsService _userCommandsService;
        private readonly IConsoleWrappingService _console;

        private const int SeedMultiplier = 10000;
        private const int BoardSize = 10;

        public GameplayService(IDrawingService drawingService,
            IUserCommandsService userCommandsService, IPlayersBoardFactory playersBoardFactory,
            IConsoleWrappingService console)
        {
            _drawingService = drawingService;
            _userCommandsService = userCommandsService;
            _playersBoardFactory = playersBoardFactory;
            _console = console;
        }

        public void StartGame()
        {
            Log.Information("Game started");

            ShowIntro();

            var playersSeed = _userCommandsService.SetAndValidateSeed(GameTexts.InsertSeed);
            var opponentsSeed = _userCommandsService.SetAndValidateSeed(GameTexts.InsertOpponentsSeed);

            var turnAnswer = _userCommandsService.SetAndValidateValue(GameTexts.PickStartingPlayer, GameConstants.YesNoRegex);

            Log.Information("Game Configuration: {0}, {1}, {2} ", playersSeed.ToString(), opponentsSeed.ToString(), turnAnswer);

            var isPlayersTurn = turnAnswer.IsTrue();

            var playersBoard = _playersBoardFactory.Create(BoardSize, playersSeed);
            var opponentsBoard = _playersBoardFactory.Create(BoardSize, opponentsSeed + SeedMultiplier);

            do
            {
                _drawingService.DrawDashboard(playersBoard, opponentsBoard);

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

        private void ShowIntro()
        {
            _console.WriteLine(GameTexts.GameIntro);
            _console.ReadLine();
        }

        private Position GetShotPosition(bool isPlayersTurn)
        {
            string name = isPlayersTurn ? "YOUR" : "OPPONENT'S";

            var coordinates = _userCommandsService.SetAndValidateValue(GameTexts.InsertShotCoordinates(name), 
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

                _console.WriteLine(shotShip.IsDestroyed ? GameTexts.ShipDestroyed : GameTexts.ShipDamaged);
            }
            else
            {
                if (shotField == Content.Wreck)
                {
                    _console.WriteLine(GameTexts.ShotIntoWreck);
                }
                else
                {
                    _console.WriteLine(GameTexts.ShotMissed);
                    shooter.MissedShotsExecuted.Add(shot);
                    defender.MissedShotsReceived.Add(shot);
                }
            }
        }

        public void FinishGame(bool isPlayerTheWinner)
        {
            if(isPlayerTheWinner)
            {
                _console.WriteLine(GameTexts.YouWon);
                _console.WriteLine(GameTexts.PlayerWonInfo);
            } 
            else
            {
                _console.WriteLine(GameTexts.YouLost);
                _console.WriteLine(GameTexts.PlayerLostInfo);
            }

            Log.Information("Game finished. isPlayerTheWinner: {0}", isPlayerTheWinner.ToString());
        }
    }
}
