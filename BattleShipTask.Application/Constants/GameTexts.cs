namespace BattleShipTask.Application.Constants
{
    public class GameTexts
    {
        public const string GameIntro =
            "       __                        __                 \r\n      )_)  _  _)_ _)_  )   _   (_ ` ( _  o   _   _ \r\n     /__) (_( (_  (_  (   )_) .__)   ) ) (  )_) (  \r\n                         (_                (    _) \r\n \r\n \r\n Press enter to start the game.";
        public const string ShipDamaged = "Ship has been damaged!";

        public const string ShipDestroyed = "Ship has been destroyed!";

        public const string ShotMissed = "Shot missed the target!";

        public const string YouLost =
            "\r\n      __   __                    _                     _   \r\n      \\ \\ / /   ___    _   _    | |       ___    ___  | |_ \r\n       \\ V /   / _ \\  | | | |   | |      / _ \\  / __| | __|\r\n        | |   | (_) | | |_| |   | |___  | (_) | \\__ \\ | |_ \r\n        |_|    \\___/   \\__,_|   |_____|  \\___/  |___/  \\__|\r\n ";

        public const string YouWon =
            "\r\n       __   __                   __        __                \r\n      \\ \\ / /   ___    _   _    \\ \\      / /   ___    _ __  \r\n       \\ V /   / _ \\  | | | |    \\ \\ /\\ / /   / _ \\  | '_ \\ \r\n        | |   | (_) | | |_| |     \\ V  V /   | (_) | | | | |\r\n        |_|    \\___/   \\__,_|      \\_/\\_/     \\___/  |_| |_|\r\n ";

        public const string PlayerWonInfo = "All opponent's ships have been destoryed. Game Over";

        public const string PlayerLostInfo = "All your ships have been destoryed. Game Over";

        public const string InsertSeed = "Choose randomizing seed for ships generation. Pick number from range 1 - 10000. \n" +
                                         "Remember the number and provide it to your opponent";

        public const string InsertOpponentsSeed = "Insert opponents chosen number. Number must be exactly the same which opponent inserted.";

        public const string PickStartingPlayer = "Agree with the opponent who shots first. If you start then type 'y' if opponent starts type 'n'.";

        public const string ApplicationException = "****************************** \r\n I'm sorry, but application exception occured \r\n******************************";
        
        public const string UnhandledException = "****************************** \r\n I'm sorry, but fatal unhandled exception occured \r\n******************************";
        public static string InsertShotCoordinates(string player) => $"Insert coordinates of {player} shot:";
    }
}
