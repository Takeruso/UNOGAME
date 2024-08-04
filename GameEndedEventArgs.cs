using System.Net.Http.Headers;
using System;

namespace Distinction{
    /// <summary>
    /// Represents event arguments for the end of a game, including the name of the winner.
    /// </summary>
    public class GameEndedEventArgs : EventArgs
    {
        private string _winnerName;

        /// <summary>
        /// Initializes a new instance of the GameEndedEventArgs class with the name of the winner.
        /// </summary>
        /// <param name="winnerName">The name of the game winner.</param>
        public GameEndedEventArgs(string winnerName)
        {
            _winnerName = winnerName;
        }

        /// <summary>
        /// Gets the name of the game winner.
        /// </summary>
        public string WinnerName{
            get{return _winnerName;}
        }
    }
}