namespace Distinction
{
    /// <summary>
    /// Represents a special wild card that forces the next player to draw four cards in the game.
    /// </summary>
    public class WildDrawFourCard : Card
    {
        /// <summary>
        /// Initializes a new instance of the WildDrawFourCard class with a specified color.
        /// </summary>
        /// <param name="color">The color of the card.</param>
        public WildDrawFourCard(Color color) : base(color){}

        /// <summary>
        /// Applies the game effect of this card, forcing the next player to draw four cards.
        /// </summary>
        /// <param name="game">The game in which the card's effect is applied.</param>
        public override void GameEffect(Game game){
            game.NextPlayerDraws(4);
        }

        /// <summary>
        /// Always returns true to match any card for gameplay purposes.
        /// </summary>
        /// <param name="card">The card to compare with this card.</param>
        /// <returns>True to match any card, regardless of type or color.</returns>
        public override bool Match(Card card)
        {
            return true;
        }

        /// <summary>
        /// Returns a string representation of this WildDrawFourCard.
        /// </summary>
        /// <returns>A string containing the card's type.</returns>
        public override string ToString()
        {
            return "WildDrawFourCard";
        }
    }
}
