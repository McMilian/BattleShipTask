using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BattleShipTask.Constants
{
    public static class GameConstants
    {
        public const string InsertRowCommand = "Shot the row: ";
      
        public const string InsertColumnCommand = "Shot the column: ";
        
        public const string ShipDamaged = "Ship has been damaged!";
        
        public const string ShipDestroyed = "Ship has been destroyed!";
        
        public const string ShotMissed = "Shot missed the target!";
       
        public const string PlayerWonInfo = "YOU WON! All opponent's ships have been destoryed. Game Over";
        public const string PlayerLostInfo = "YOU LOST! All your ships have been destoryed. Game Over";
       
        public const string InsertSeed = "Choose randomizing seed for ships generation. Pick number from range 1 - 10000. \n" +
                                "Remember the number and provide it to your opponent";
        public const string InsertOpponentsSeed  = "Insert opponents chosen number. Number must be exactly the same which opponent inserted.";
        
        public const string PickStartingPlayer  = "Agree with the opponent who shots first. If you start then type 'y' if opponent starts type 'n'.";

        public static List<string> AlphabetLetters = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U" };

        public static string InsertShotCoordinates(string player) => $"Insert coordinates of {player} shot:";

        public static Regex ShotCoordinatesRegex { get; } = new Regex(@"^[a-jA-J]0?([1-9]|10)$");
        public static Regex YesNoRegex { get; } = new Regex(@"^[y|n]$");
    }
}
