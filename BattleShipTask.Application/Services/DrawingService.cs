using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleShipTask.Application.Configuration;
using BattleShipTask.Application.Constants;
using BattleShipTask.Application.Exceptions;
using BattleShipTask.Application.Extensions;
using BattleShipTask.Application.Interfaces;
using BattleShipTask.Application.Models;
using BattleShipTask.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;

namespace BattleShipTask.Application.Services
{
    public class DrawingService : IDrawingService
    {
        private readonly IConsoleWrappingService _console;
        private readonly DrawingServiceOptions _options;

        private const int BattlefieldSize = 10;

        public DrawingService(IConsoleWrappingService console, IOptions<DrawingServiceOptions> options
        )
        {
            _console = console;
            _options = options.Value;
        }

        public void DrawDashboard(PlayersBoard playersBoard, PlayersBoard opponentsBoard)
        {
            var playersBattlefield = CreateBattlefield(playersBoard);
            var opponentsBattlefield = CreateBattlefield(opponentsBoard);

            DrawGameBoardsWithIcons(playersBattlefield, opponentsBattlefield);
        }

        private void DrawGameBoardsWithIcons(Battlefield myBattlefield, Battlefield opponentsBattlefield)
        {
            if (myBattlefield.Size != opponentsBattlefield.Size)
            {
                throw new BattleshipApplicationException("Battlefields are not the same size", ApplicationErrorType.ForbiddenOperation);
            }

            _console.WriteLine("                           My Board                                            Opponent's Board             ");
            _console.WriteLine("       01   02   03   04   05   06   07   08   09   10         01   02   03   04   05   06   07   08   09   10");
            _console.WriteLine("     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐");

            for (var rowNumber = 1; rowNumber <= myBattlefield.Size; rowNumber++)
            {
                _console.WriteLine(DrawContent(myBattlefield, opponentsBattlefield, rowNumber));

                if (rowNumber == myBattlefield.Size)
                {
                    _console.WriteLine("     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘");
                }
                else
                {
                    _console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
                }
            }
        }

        private string DrawContent(Battlefield myBattlefield, Battlefield opponentsBattlefield, int rowNumber)
        {
            var letters = GameConstants.AlphabetLetters;
            var myRowFields = myBattlefield.Fields.Where(field => field.Position.Row == rowNumber).OrderBy(x => x.Position.Column).ToList();
            var opponentsRowFields = opponentsBattlefield.Fields.Where(field => field.Position.Row == rowNumber).OrderBy(x => x.Position.Column).ToList();

            var builder = new StringBuilder();

            builder.Append($"  { letters[rowNumber - 1]}  ");

            InsertRowContent(myRowFields, builder, true);

            builder.Append($"│  {letters[rowNumber - 1]}  ");

            InsertRowContent(opponentsRowFields, builder, _options.ShowOpponentsShips);

            builder.Append("│");

            return builder.ToString();
        }

        private static void InsertRowContent(List<Field> myRowFields, StringBuilder builder, bool showShips)
        {
            foreach (var rowField in myRowFields)
            {
                builder.Append($"│ {rowField.Content.Map(showShips)} ");
            }
        }

        private static Battlefield CreateBattlefield(PlayersBoard board)
        {
            var playersBattlefield = new Battlefield(BattlefieldSize);
            foreach (var ship in board.Ships)
            {
                playersBattlefield.InsertShip(ship);
            }

            playersBattlefield.InsertWater(board.MissedShotsReceived);

            return playersBattlefield;
        }
    }
}
