using BattleShipTask.Constants;
using BattleShipTask.Exceptions;
using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleShipTask.Extensions;

namespace BattleShipTask.Services
{
    public class DrawingService : IDrawingService
    {
        private const int BattlefieldSize = 10;
        public void DrawField()
        {
            Console.WriteLine("       01   02   03   04   05   06   07   08   09   10");
            Console.WriteLine("     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐");
            Console.WriteLine("  A  │    │ () │ () │ () │ () │ () │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  B  │    │    │ ~~ │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  C  │    │ () │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  D  │    │ XX │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  E  │    │ () │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  F  │    │ () │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  G  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  H  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  I  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  J  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘");
        }

        public void DrawBoards(PlayersBoard playersBoard, PlayersBoard opponentsBoard)
        {
            var playersBattlefield = CreateBattlefield(playersBoard);
            var opponentsBattlefield = CreateBattlefield(opponentsBoard);

            DrawBoardsWithIcons(playersBattlefield, opponentsBattlefield);
        }

        private static void DrawBoardsWithIcons(Battlefield myBattlefield, Battlefield opponentsBattlefield)
        {
            if(myBattlefield.Size != opponentsBattlefield.Size)
            {
                throw new BattleshipApplicationException("Battlefields are not the same size", ApplicationErrorType.ForbiddenOperation);
            }

            Console.WriteLine("                           My Board                                            Opponent's Board             ");
            Console.WriteLine("       01   02   03   04   05   06   07   08   09   10         01   02   03   04   05   06   07   08   09   10");
            Console.WriteLine("     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐");

            for (int rowNumber = 1; rowNumber <= myBattlefield.Size; rowNumber++)
            {
                DrawContent(myBattlefield, opponentsBattlefield, rowNumber);

                if (rowNumber == myBattlefield.Size)
                {
                    Console.WriteLine("     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘");
                }
                else
                {
                    Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
                }
            }
        }

        private static void DrawContent(Battlefield myBattlefield, Battlefield opponentsBattlefield, int rowNumber)
        {
            var letters = GameConstants.AlphabetLetters;
            var myRowFields = myBattlefield.Fields.Where(field => field.Position.Row == rowNumber).OrderBy(x => x.Position.Column).ToList();
            var opponentsRowFields = opponentsBattlefield.Fields.Where(field => field.Position.Row == rowNumber).OrderBy(x => x.Position.Column).ToList();

            var builder = new StringBuilder();

            builder.Append($"  { letters[rowNumber - 1]}  ");

            InsertRowContent(myRowFields, builder);

            builder.Append($"│  {letters[rowNumber - 1]}  ");

            InsertRowContent(opponentsRowFields, builder);

            builder.Append("│");

            Console.WriteLine(builder.ToString());
        }

        private static void InsertRowContent(List<Field> myRowFields, StringBuilder builder)
        {
            foreach (var rowField in myRowFields)
            {
                builder.Append($"│ {rowField.Content.Map(true)} ");
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
