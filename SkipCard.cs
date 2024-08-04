namespace Distinction
{
    /// <summary>
    /// Represents a special card that skips the turn of the next player in the game.
    /// </summary>
    public class SkipCard : Card
    {
        /// <summary>
        /// Initializes a new instance of the SkipCard class with a specified color.
        /// </summary>
        /// <param name="color">The color of the card.</param>
        public SkipCard(Color color) : base(color){}

        /// <summary>
        /// Applies the game effect of this card, skipping the turn of the next player.
        /// </summary>
        /// <param name="game">The game in which the card's effect is applied.</param>
        public override void GameEffect(Game game){
            game.SkipNextPlayer();
        }

        /// <summary>
        /// Determines if this card matches another card for gameplay purposes.
        /// </summary>
        /// <param name="card">The card to compare with this card.</param>
        /// <returns>True if the cards match, false otherwise.</returns>
        public override bool Match(Card card)
        {
            if (card is SkipCard)
            {
                return true; 
            }

            return this.Color == card.Color; 
        }

        /// <summary>
        /// Returns a string representation of this SkipCard, including its color.
        /// </summary>
        /// <returns>A string containing the card's type and color.</returns>
        public override string ToString()
        {
            return $"SkipCard: Color={Color}";
        }
    }
}
