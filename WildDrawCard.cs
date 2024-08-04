namespace Distinction
{
    /// <summary>
    /// Represents a special wild card that does not have a specific game effect.
    /// </summary>
    public class WildDrawCard : Card
    {
        /// <summary>
        /// Initializes a new instance of the WildDrawCard class with a specified color.
        /// </summary>
        /// <param name="color">The color of the card.</param>
        public WildDrawCard(Color color) : base(color){}

        /// <summary>
        /// Does not apply any game effect for this wild card.
        /// </summary>
        /// <param name="game">The game in which the card's effect is applied.</param>
        public override void GameEffect(Game game){
            // WildDrawCard typically has no game effect.
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
        /// Returns a string representation of this WildDrawCard.
        /// </summary>
        /// <returns>A string containing the card's type.</returns>
        public override string ToString()
        {
            return "WildDrawCard";
        }
    }
}
