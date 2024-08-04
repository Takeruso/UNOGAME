using System;
using System.Collections.Generic;
using System.Linq;

namespace Distinction
{
    /// <summary>
    /// Represents a player in a card game.
    /// </summary>
    public class Player
    {
        private List<Card> _hands;
        private string _name;

        /// <summary>
        /// Initializes a new instance of the Player class with a list of initial cards and a player number.
        /// </summary>
        /// <param name="hands">The list of initial cards held by the player.</param>
        /// <param name="playerNumber">The player's number or identifier.</param>
        public Player(List<Card> hands, int playerNumber)
        {
            _hands = hands;
            _name = "Player" + playerNumber;
        }

        /// <summary>
        /// Gets or sets the list of cards currently held by the player.
        /// </summary>
        public List<Card> Hand
        {
            get { return _hands; }
            set { _hands = value; }
        }

        /// <summary>
        /// Gets or sets the name or identifier of the player.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Receives a list of cards and adds them to the player's hand.
        /// </summary>
        /// <param name="cards">The list of cards to be received.</param>
        public void ReceiveCards(List<Card> cards)
        {
            _hands.AddRange(cards);
        }
    }
}
