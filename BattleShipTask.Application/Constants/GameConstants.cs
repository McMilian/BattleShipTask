using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BattleShipTask.Application.Constants
{
    public static class GameConstants
    {
        public static List<string> AlphabetLetters = new() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U" };

        public static Regex ShotCoordinatesRegex { get; } = new(@"^[a-jA-J]0?([1-9]|10)$");
        public static Regex YesNoRegex { get; } = new(@"^[y|n]$");

        
    }
}
