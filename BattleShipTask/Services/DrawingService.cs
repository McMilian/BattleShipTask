using BattleShipTask.Constants;
using BattleShipTask.Interfaces;
using BattleShipTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipTask.Services
{
    public class DrawingService : IDrawingService
    {
        public void DrawField()
        {
            #region Declarations

            const string cellLeftTop = "┌";
            const string cellRightTop = "┐";
            const string cellLeftBottom = "└";
            const string cellRightBottom = "┘";
            const string cellHorizontalJointTop = "┬";
            const string cellHorizontalJointbottom = "┴";
            const string cellVerticalJointLeft = "├";
            const string cellTJoint = "┼";
            const string cellVerticalJointRight = "┤";
            const string cellHorizontalLine = "─";
            const string cellVerticalLine = "│";

            #endregion

            //Narysuj jednomasztowiec
            Console.WriteLine("  ┌────┐");
            Console.WriteLine("  │    │");
            Console.WriteLine("  └────┘");

            //Narysuj dwumasztowiec pion
            Console.WriteLine("  ┌────┐");
            Console.WriteLine("  │ XX │");
            Console.WriteLine("  ├────┤");
            Console.WriteLine("  │ XX │");
            Console.WriteLine("  └────┘");

            //Narysuj dwumasztowiec poziom
            Console.WriteLine("  01   02   03   04   05   06   07   08   09   10");

            Console.WriteLine("┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("└────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘");


            Console.WriteLine("┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("│    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("└────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘");

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

            Console.WriteLine("       01   02   03   04   05   06   07   08   09   10");
            Console.WriteLine("     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐");
            Console.WriteLine("  A  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  B  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  C  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  D  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  E  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  F  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  G  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  H  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  I  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
            Console.WriteLine("  J  │    │    │    │    │    │    │    │    │    │    │");
            Console.WriteLine("     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘");



            Console.WriteLine("  A  │  │  │  │  │  │  │  │  │  │  │");



        }

        //public void DrawBattlefieldUsingShips(IEnumerable<Ship> shipsList, IEnumerable<Position> missedShots, bool showShips)
        //{
        //    var battlefield = new Battlefield(10);
        //    foreach (var ship in shipsList)
        //    {
        //        battlefield.InsertShip(ship);
        //    }

        //    battlefield.InsertWater(missedShots);

        //    DrawGridWithIcons(battlefield, showShips);
        //}

        public void DrawBothBattlefieldsUsingShips(PlayersBoard myBoard, PlayersBoard opponentsBoard)
        {
            var myBattlefield = new Battlefield(10);  //Hardcoded size of battlefield
            foreach (var ship in myBoard.Ships)
            {
                myBattlefield.InsertShip(ship);
            }

            myBattlefield.InsertWater(myBoard.MissedShotsReceived);

            //again
            var opponentsBattlefied = new Battlefield(10);  //Hardcoded size of battlefield
            foreach (var ship in opponentsBoard.Ships)
            {
                opponentsBattlefied.InsertShip(ship);
            }

            opponentsBattlefied.InsertWater(opponentsBoard.MissedShotsReceived);

            DrawBothGridsWithIcons(myBattlefield, opponentsBattlefied);
        }

        //private void DrawGridWithIcons(Battlefield battlefield, bool showShips)
        //{
        //    Console.WriteLine("       01   02   03   04   05   06   07   08   09   10");
        //    Console.WriteLine("     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐");

        //    for (int i = 1; i <= battlefield.Size; i++)
        //    {
        //        var letters = GameConstants.AlphabetLetters;
        //        var rowfields = battlefield.Fields.Where(field => field.Position.Row == i).OrderBy(x => x.Position.Column).ToList();

        //        Console.WriteLine($"  {letters[i - 1]}  │ {rowfields[0].Content.Map(showShips)} │ {rowfields[1].Content.Map(showShips)} │ {rowfields[2].Content.Map(showShips)} │ {rowfields[3].Content.Map(showShips)} │ {rowfields[4].Content.Map(showShips)} │ {rowfields[5].Content.Map(showShips)} │ {rowfields[6].Content.Map(showShips)} │ {rowfields[7].Content.Map(showShips)} │ {rowfields[8].Content.Map(showShips)} │ {rowfields[9].Content.Map(showShips)} │");

        //        if (i == battlefield.Size)
        //        {
        //            Console.WriteLine("     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘");
        //        }
        //        else
        //        {
        //            Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
        //        }
        //    }
        //}

        private void DrawBothGridsWithIcons(Battlefield myBattlefield, Battlefield opponentsBattlefield)
        {
            Console.WriteLine("                           My Board                                            Opponent's Board             ");
            Console.WriteLine("       01   02   03   04   05   06   07   08   09   10         01   02   03   04   05   06   07   08   09   10");
            Console.WriteLine("     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐     ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐");

            for (int i = 1; i <= 10; i++)  //Hardcoded size
            {
                var letters = GameConstants.AlphabetLetters;
                var myRowFields = myBattlefield.Fields.Where(field => field.Position.Row == i).OrderBy(x => x.Position.Column).ToList();
                var opponentsRowFields = opponentsBattlefield.Fields.Where(field => field.Position.Row == i).OrderBy(x => x.Position.Column).ToList();

                //TODO: showShips do zmiany
                Console.WriteLine($"  {letters[i - 1]}  │ {myRowFields[0].Content.Map(true)} │ {myRowFields[1].Content.Map(true)} │ {myRowFields[2].Content.Map(true)} │ {myRowFields[3].Content.Map(true)} │ {myRowFields[4].Content.Map(true)} │ {myRowFields[5].Content.Map(true)} │ {myRowFields[6].Content.Map(true)} │ {myRowFields[7].Content.Map(true)} │ {myRowFields[8].Content.Map(true)} │ {myRowFields[9].Content.Map(true)} │  {letters[i - 1]}  │ {opponentsRowFields[0].Content.Map(false)} │ {opponentsRowFields[1].Content.Map(false)} │ {opponentsRowFields[2].Content.Map(false)} │ {opponentsRowFields[3].Content.Map(false)} │ {opponentsRowFields[4].Content.Map(false)} │ {opponentsRowFields[5].Content.Map(false)} │ {opponentsRowFields[6].Content.Map(false)} │ {opponentsRowFields[7].Content.Map(false)} │ {opponentsRowFields[8].Content.Map(false)} │ {opponentsRowFields[9].Content.Map(false)} │");

                if (i == myBattlefield.Size)
                {
                    Console.WriteLine("     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘");
                }
                else
                {
                    Console.WriteLine("     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤     ├────┼────┼────┼────┼────┼────┼────┼────┼────┼────┤");
                }
            }
        }
    }
}
