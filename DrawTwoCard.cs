namespace Distinction
{
    /// <summary>
    /// Represents a special card that forces the next player to draw two cards in a game.
    /// </summary>
    public class DrawTwoCard : Card
    {
        /// <summary>
        /// Initializes a new instance of the DrawTwoCard class with a specified color.
        /// </summary>
        /// <param name="color">The color of the card.</param>
        public DrawTwoCard(Color color) : base(color){}

        /// <summary>
        /// Applies the game effect of this card, forcing the next player to draw two cards.
        /// </summary>
        /// <param name="game">The game in which the card's effect is applied.</param>
        public override void GameEffect(Game game){
            game.NextPlayerDraws(2);
        }

        /// <summary>
        /// Determines if this card matches another card for gameplay purposes.
        /// </summary>
        /// <param name="card">The card to compare with this card.</param>
        /// <returns>True if the cards match, false otherwise.</returns>
        public override bool Match(Card card)
        {
            if (card is DrawTwoCard)
            {
                return true; 
            }

            return this.Color == card.Color; 
        }

        /// <summary>
        /// Returns a string representation of this DrawTwoCard.
        /// </summary>
        /// <returns>A string containing the card's type and color.</returns>
        public override string ToString()
        {
            return $"DrawTwoCard: Color={Color}";
        }
    }
}
