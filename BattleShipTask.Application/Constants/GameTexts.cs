namespace BattleShipTask.Application.Constants
{
    public class GameTexts
    {
        public const string GameIntro =
            "       __                        __                 \r\n      )_)  _  _)_ _)_  )   _   (_ ` ( _  o   _   _ \r\n     /__) (_( (_  (_  (   )_) .__)   ) ) (  )_) (  \r\n                         (_                (    _) \r\n \r\n \r\n Press enter to start the game.";
        public const string ShipDamaged = "\n Ship has been damaged! \n";

        public const string ShipDestroyed = "\n Ship has been destroyed! \n";

        public const string ShotMissed = "\n Shot missed the target! \n";
        public const string ShotIntoWreck = "\n You shot the wreck! \n";

        public const string YouLost =
            "\r\n      __   __                    _                     _   \r\n      \\ \\ / /   ___    _   _    | |       ___    ___  | |_ \r\n       \\ V /   / _ \\  | | | |   | |      / _ \\  / __| | __|\r\n        | |   | (_) | | |_| |   | |___  | (_) | \\__ \\ | |_ \r\n        |_|    \\___/   \\__,_|   |_____|  \\___/  |___/  \\__|\r\n ";

        public const string YouWon =
            "\r\n       __   __                   __        __                \r\n      \\ \\ / /   ___    _   _    \\ \\      / /   ___    _ __  \r\n       \\ V /   / _ \\  | | | |    \\ \\ /\\ / /   / _ \\  | '_ \\ \r\n        | |   | (_) | | |_| |     \\ V  V /   | (_) | | | | |\r\n        |_|    \\___/   \\__,_|      \\_/\\_/     \\___/  |_| |_|\r\n ";

        public const string PlayerWonInfo = "All opponent's ships have been destoryed. Game Over";

        public const string PlayerLostInfo = "All your ships have been destoryed. Game Over";

        public const string InsertSeed = "Choose randomizing seed for YOUR ships generation. Pick number from range 1 - 10000. Press enter and provide \n" +
                                         "the number to your opponent";

        public const string InsertOpponentsSeed = "Insert OPPONENT'S chosen number. Number must be exactly the same \n" +
                                                  "which opponent inserted in his/her first question.";

        public const string PickStartingPlayer = "Agree with the opponent who shoots first. If you start then type 'y' if opponent starts type 'n'.";

        public const string ApplicationException = "****************************** \r\n I'm sorry, but application exception occured \r\n******************************";
        
        public const string UnhandledException = "****************************** \r\n I'm sorry, but fatal unhandled exception occured \r\n******************************";
        public static string InsertShotCoordinates(string player) => $"Insert coordinates of {player} shot:";
    }
}
