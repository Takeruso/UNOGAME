namespace Distinction
{
    /// <summary>
    /// Represents a Reverse card in the UNO card game.
    /// </summary>
    public class ReverseCard : Card
    {
        /// <summary>
        /// Initializes a new instance of the ReverseCard class with the specified color.
        /// </summary>
        /// <param name="color">The color of the Reverse card.</param>
        public ReverseCard(Color color) : base(color) { }

        /// <summary>
        /// Performs the game effect of reversing the turn order when this card is played.
        /// </summary>
        /// <param name="game">The UNO game instance.</param>
        public override void GameEffect(Game game)
        {
            game.ReverseTurnOrder();
        }

        /// <summary>
        /// Determines if this card matches another card, either by having the same color or being the same type (ReverseCard).
        /// </summary>
        /// <param name="card">The card to compare with.</param>
        /// <returns>True if the cards match; otherwise, false.</returns>
        public override bool Match(Card card)
        {
            if (card is ReverseCard)
            {
                return true;
            }

            return this.Color == card.Color;
        }

        /// <summary>
        /// Returns a string representation of the ReverseCard, including its color.
        /// </summary>
        /// <returns>A string representing the ReverseCard.</returns>
        public override string ToString()
        {
            return $"ReverseCard: Color={Color}";
        }
    }
}
