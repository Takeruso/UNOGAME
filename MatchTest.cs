using NUnit.Framework;

namespace Distinction
{
    /// <summary>
    /// Tests for verifying the Match method of different Card types.
    /// </summary>
    [TestFixture]
    public class MatchTest
    {
        /// <summary>
        /// Tests the Match method for NumberCard.
        /// Verifies that NumberCards match if they have the same number or color.
        /// </summary>
        [Test]
        public void TestNumberCardMatch()
        {
            var card1 = new NumberCard(Color.Red, Number.Five);
            var card2 = new NumberCard(Color.Blue, Number.Five);
            var card3 = new DrawTwoCard(Color.Green);
            var card4 = new NumberCard(Color.Red, Number.Six);
            Assert.IsTrue(card1.Match(card2));
            Assert.IsFalse(card1.Match(card3));
            Assert.IsTrue(card1.Match(card4));
        }
        /// <summary>
        /// Tests the Match method for DrawTwoCard.
        /// Verifies that DrawTwoCards match with any card of the same color.
        /// </summary>
        [Test]
        public void TestDrawTwoCardMatch()
        {
            var card1 = new DrawTwoCard(Color.Red);
            var card2 = new DrawTwoCard(Color.Blue);
            var card3 = new NumberCard(Color.Red, Number.Five);
            var card4 = new NumberCard(Color.Green, Number.Five);
            Assert.IsTrue(card1.Match(card2));
            Assert.IsTrue(card1.Match(card3));
            Assert.IsFalse(card1.Match(card4));
        }

        /// <summary>
        /// Tests the Match method for DoublePlayCard.
        /// Verifies that DoublePlayCards match with any card of the same color.
        /// </summary>
        [Test]
        public void TestDoubleplayCardMatch()
        {
            var card1 = new DoublePlayCard(Color.Red);
            var card2 = new DoublePlayCard(Color.Blue);
            var card3 = new NumberCard(Color.Red, Number.Five);
            var card4 = new NumberCard(Color.Green, Number.Five);
            Assert.IsTrue(card1.Match(card2));
            Assert.IsTrue(card1.Match(card3));
            Assert.IsFalse(card1.Match(card4));
        }

        /// <summary>
        /// Tests the Match method for ReverseCard.
        ///  Verifies that ReverseCards match with any card of the same color.
        /// </summary>
        [Test]
        public void TestReverseCardMatch()
        {
            var card1 = new ReverseCard(Color.Red);
            var card2 = new ReverseCard(Color.Blue);
            var card3 = new NumberCard(Color.Red, Number.Five);
            var card4 = new NumberCard(Color.Green, Number.Five);
            Assert.IsTrue(card1.Match(card2));
            Assert.IsTrue(card1.Match(card3));
            Assert.IsFalse(card1.Match(card4));
        }

        /// <summary>
        /// Tests the Match method for SkipCard.
        ///  Verifies that SkipCards match with any card of the same color.
        /// </summary>
        [Test]
        public void TestSkipCardMatch()
        {
            var card1 = new SkipCard(Color.Yellow);
            var card2 = new SkipCard(Color.Green);
            var card3 = new NumberCard(Color.Yellow, Number.Five);
            var card4 = new NumberCard(Color.Green, Number.Five);
            Assert.IsTrue(card1.Match(card2));
            Assert.IsTrue(card1.Match(card3));
            Assert.IsFalse(card1.Match(card4));
        }
        /// <summary>
        /// Tests the Match method for WildDrawCard.
        /// Verifies that WildDrawCard matches with any card.
        /// </summary>
        [Test]
        public void TestWildDrawCardMatch()
        {
            var WildDrawCard = new WildDrawCard(Color.Wild);
            var numberCard = new NumberCard(Color.Blue, Number.Five);
            Assert.IsTrue(WildDrawCard.Match(numberCard));
        }
        /// <summary>
        /// Tests the Match method for WildDrawFourCard.
        /// Verifies that WildDrawFourCard matches with any card.
        /// </summary>
        [Test]
        public void TestWildDrawFourCardMatch()
        {
            var WildDrawFourCard = new WildDrawFourCard(Color.Wild);
            var numberCard = new NumberCard(Color.Blue, Number.Five);
            Assert.IsTrue(WildDrawFourCard.Match(numberCard));
        }
    }
}
