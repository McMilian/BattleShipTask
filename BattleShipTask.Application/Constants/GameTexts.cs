namespace BattleShipTask.Application.Constants
{
    public class GameTexts
    {
        public const string ShipDamaged = "Ship has been damaged!";

        public const string ShipDestroyed = "Ship has been destroyed!";

        public const string ShotMissed = "Shot missed the target!";

        public const string PlayerWonInfo = "YOU WON! All opponent's ships have been destoryed. Game Over";

        public const string PlayerLostInfo = "YOU LOST! All your ships have been destoryed. Game Over";

        public const string InsertSeed = "Choose randomizing seed for ships generation. Pick number from range 1 - 10000. \n" +
                                         "Remember the number and provide it to your opponent";

        public const string InsertOpponentsSeed = "Insert opponents chosen number. Number must be exactly the same which opponent inserted.";

        public const string PickStartingPlayer = "Agree with the opponent who shots first. If you start then type 'y' if opponent starts type 'n'.";

        public const string ApplicationException = "****************************** \r\n I'm sorry, but application exception occured \r\n******************************";
        
        public const string UnhandledException = "****************************** \r\n I'm sorry, but fatal unhandled exception occured \r\n******************************";
        public static string InsertShotCoordinates(string player) => $"Insert coordinates of {player} shot:";
    }
}
