using System;

namespace Distinction{
    /// <summary>
    /// Represents a card in the game.
    /// </summary>
    public abstract class Card{
        private Color _color;

        /// <summary>
        /// Initializes a new instance of the Card class with a specified color.
        /// </summary>
        /// <param name="color">The color of the card.</param>
        public Card(Color color){
            _color = color;
        }

        /// <summary>
        /// Gets or sets the color associated with this object.
        /// </summary>
        /// <value>The color value</value>
        public Color Color{
            get{return _color;}
            set{_color = value;}
        }

        /// <summary>
        /// Executes the game effect of the card.
        /// </summary>
        /// <param name="game">The game context in which the card is played.</param>
        public abstract void GameEffect(Game game);

        /// <summary>
        /// Determines if the card matches another card
        /// </summary>
        /// <param name="otherCard">The card to compare with.</param>
        /// <returns>True if the cards match; otherwise, false.</returns>
        public abstract bool Match(Card otherCard);

        /// <summary>
        /// Returns a string that represents the current card.
        /// </summary>
        /// <returns>A string representation of the card.</returns>
        public override string ToString()
        {
            return $"Card: Color={Color}";
        }   
    }
}