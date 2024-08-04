using System.Collections;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Distinction
{
    /// <summary>
    /// Represent a deck of cards.
    /// </summary>
    public class Deck
    {
        private List<Card> _cards;
        private List<Card> _discardPile;

        /// <summary>
        /// Initialize a new instance of the Deck class.
        /// </summary>
        public Deck()
        {
            _cards = new List<Card>();
            _discardPile = new List<Card>();
        }

        /// <summary>
        /// Gets the list of cards in the deck.
        /// </summary>
        /// <value>The list of cards.</value>
        public List<Card> Cards
        {
            get { return _cards; }
        }
        /// <summary>
        /// Gets the list of cards in the deck.
        /// </summary>
        /// <value>The list of discarded cards.</value>
        public List<Card> DiscardPile
        {
            get { return _discardPile; }
        }

        /// <summary>
        /// Initialize the Deck with a standard set of cards.
        /// </summary>
       public void InitializeDeck()
        {
            _cards.Clear();
            _discardPile.Clear();
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                if (color == Color.Wild) continue; 

                foreach (Number number in Enum.GetValues(typeof(Number)))
                {
                    _cards.Add(new NumberCard(color, number));
                    if (number != Number.Zero) 
                    {
                        _cards.Add(new NumberCard(color, number));
                    }
                }
                _cards.Add(new DrawTwoCard(color));
                _cards.Add(new DrawTwoCard(color));
                _cards.Add(new ReverseCard(color));
                _cards.Add(new ReverseCard(color));
                _cards.Add(new SkipCard(color));
                _cards.Add(new SkipCard(color));
                _cards.Add(new DoublePlayCard(color));
                _cards.Add(new DoublePlayCard(color));
            }

            for (int i = 0; i < 4; i++)
            {
                _cards.Add(new WildDrawCard(Color.Wild));
                _cards.Add(new WildDrawFourCard(Color.Wild));
            }

            Shuffle(); 
        }

        /// <summary>
        /// Shuffles the deck of cards
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        /// <summary>
        ///  Deals a specified number of cards.
        /// </summary>
        /// <param name="numOfCards">The number of cards to deal.</param>
        /// <returns>The number of cards to deal.</returns>
        public List<Card> DealCards(int numOfCards)
        {
            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < numOfCards; i++)
            {
                if (_cards.Count > 0)
                {
                    dealtCards.Add(Draw());
                }
                else
                {
                    RecycleUsedCards();
                    dealtCards.Add(Draw());
                }
            }
            return dealtCards;
        }

        /// <summary>
        /// Draws a card from the deck.
        /// </summary>
        /// <returns>The drawn card.</returns>
        public Card Draw()
        {
            if (_cards.Count > 0)
            {
                Card card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            }else{
                RecycleUsedCards();
                Card card = _cards[0];
                _cards.RemoveAt(0);
                return card;
            } 
        }

        /// <summary>
        /// Discards a card to the discard pile.
        /// </summary>
        /// <param name="card">Discards a card to the discard pile.</param>
        public void DiscardCard(Card card)
        {
            _discardPile.Add(card);
        }

        /// <summary>
        /// Recycles used cards from the discard pile back into the deck.
        /// </summary>
        public void RecycleUsedCards()
        {
            _cards.AddRange(_discardPile);
            _discardPile.Clear();
            Shuffle();
        }

    }
}
