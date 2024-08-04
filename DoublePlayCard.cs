namespace Distinction
{
    /// <summary>
    /// Represents a special card that allows a double turn in a game.
    /// </summary>
    public class DoublePlayCard : Card
    {
        /// <summary>
        /// Initializes a new instance of the DoublePlayCard class with a specified color.
        /// </summary>
        /// <param name="color">The color of the card.</param>
        public DoublePlayCard(Color color) : base(color){}

        /// <summary>
        /// Applies the game effect of this card, allowing a double turn in the game.
        /// </summary>
        /// <param name="game">The game in which the card's effect is applied.</param>
        public override void GameEffect(Game game){
            game.AllowDoubleTurn();
        }

        /// <summary>
        /// Determines if this card matches another card for gameplay purposes.
        /// </summary>
        /// <param name="card">The card to compare with this card.</param>
        /// <returns>True if the cards match, false otherwise.</returns>
        public override bool Match(Card card)
        {
            if (card is DoublePlayCard)
            {
                return true; 
            }

            return this.Color == card.Color;
        }

        /// <summary>
        /// Returns a string representation of this DoublePlayCard.
        /// </summary>
        /// <returns>A string containing the card's type and color.</returns>
        public override string ToString()
        {
            return $"DoublePlayCard: Color={Color}";
        }
    }
}
