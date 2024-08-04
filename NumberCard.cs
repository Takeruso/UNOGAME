namespace Distinction
{
    /// <summary>
    /// Represents a card with a numeric value in the game.
    /// </summary>
    public class NumberCard : Card
    {
        private Number _number;

        /// <summary>
        /// Initializes a new instance of the NumberCard class with a specified color and numeric value.
        /// </summary>
        /// <param name="color">The color of the card.</param>
        /// <param name="number">The numeric value of the card.</param>
        public NumberCard(Color color, Number number) : base(color)
        {
            _number = number;
        }

        /// <summary>
        /// Gets the numeric value of the card.
        /// </summary>
        public Number Number{
            get{return _number;}
        }

        /// <summary>
        /// Defines the game effect of this card (no effect for number cards).
        /// </summary>
        /// <param name="game">The game in which the card's effect is applied.</param>
        public override void GameEffect(Game game){
            // Number cards typically have no game effect.
        }


        /// <summary>
        /// Determines if this card matches another card for gameplay purposes.
        /// </summary>
        /// <param name="otherCard">The card to compare with this card.</param>
        /// <returns>True if the cards match, false otherwise.</returns>      
        public override bool Match(Card otherCard)
        {
            if (otherCard is NumberCard otherNumberCard)
            {
                return this.Number == otherNumberCard.Number || this.Color == otherNumberCard.Color;
            }
            else
            {
                return this.Color == otherCard.Color;
            }
        }

        /// <summary>
        /// Returns a string representation of this NumberCard, including its color and numeric value.
        /// </summary>
        /// <returns>A string containing the card's type, color, and number.</returns>
        public override string ToString()
        {
            return $"NumberCard: Color={Color}, Number={Number}";
        }
    }
}
