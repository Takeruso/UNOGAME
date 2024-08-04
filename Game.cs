using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Distinction{
    /// <summary>
    /// Represents a card game with players, a deck, and gameplay logic.
    /// </summary>
    public class Game{
        private List<Player> _players;
        private Deck _deck;
        private Player _currentPlayer;
        private Card _currentCard;
        private bool _isDoubleTurn;
        /// <summary>
        /// Occurs when a player's turn-related event needs to be notified.
        /// </summary>
        public event EventHandler<string> PlayerNotification;
        /// <summary>
        /// Occurs when the game has ended.
        /// </summary>
        public event EventHandler<GameEndedEventArgs> OnGameEnded; 

        /// <summary>
        /// Initializes a new instance of the Game class with a specified deck.
        /// </summary>
        /// <param name="deck">The deck of cards used in the game.</param>
        public Game(Deck deck)
        {
            _players = new List<Player>();
            _deck = deck;
            _isDoubleTurn = false;
        }

        /// <summary>
        /// Gets or sets the list of players in the game.
        /// </summary>
        public List<Player> Players{
            get{return _players;}
            set{_players = value;}
        }

        /// <summary>
        /// Gets or sets the deck of cards used in the game.
        /// </summary>
        public Deck Deck{
            get{return _deck;}
            set{_deck = value;}
        }

        /// <summary>
        /// Gets or sets the current player taking their turn.
        /// </summary>
        public Player CurrentPlayer{
            get{return _currentPlayer;}
            set{_currentPlayer = value;}
        }

        /// <summary>
        /// Gets or sets the current card in play.
        /// </summary>
        public Card CurrentCard{
            get{return _currentCard;}
            set{_currentCard = value;}
        }

        /// <summary>
        /// Adds a specified number of players to the game and starts it.
        /// </summary>
        /// <param name="playerCount">The number of players to add to the game.</param>
        public void AddPlayersToGame(int playerCount)
        {

            for (int i = 0; i < playerCount; i++)
            {
                _players.Add(new Player(new List<Card>(), _players.Count + 1));

            }
            StartGame();
        }

        /// <summary>
        /// Starts the game by initializing the deck and dealing cards to players.
        /// </summary>
        public void StartGame()
        {
            _deck.InitializeDeck();
            foreach (var player in _players)
            {
                var initialCards = _deck.DealCards(7);
                player.ReceiveCards(initialCards);
            }

            Card firstDiscard;
            do
            {
                firstDiscard = _deck.Draw();
                if (firstDiscard != null && !(firstDiscard is NumberCard))
                {
                    _deck.DiscardCard(firstDiscard);
                }
            } while (firstDiscard != null && !(firstDiscard is NumberCard));

            if (firstDiscard != null)
            {
                _currentCard = firstDiscard;
            }
            else
            {
                throw new InvalidOperationException("Deck is empty or no NumberCard found");
            }

            _currentPlayer = _players[0];
        }

        /// <summary>
        /// Advances the game to the next player's turn.
        /// </summary>
        public void NextTurn()
        {
            if (!_isDoubleTurn)
            {
            int currentIndex = _players.IndexOf(_currentPlayer);
            currentIndex = (currentIndex + 1) % _players.Count;
            _currentPlayer = _players[currentIndex];
            }
            else
            {
                _isDoubleTurn = false;
            }
            StartPlayerTurn();
        }
       
        /// <summary>
        /// Starts the turn for the current player by checking if they have a matching card to play.
        /// If not, the player draws a card from the deck, and if still no match is found, it advances to the next player's turn.
        /// </summary>
        public void StartPlayerTurn()
        {
            if (!_currentPlayer.Hand.Any(card => card.Match(_currentCard)))
            {
                Card drawnCard = _deck.Draw();
                _currentPlayer.ReceiveCards(new List<Card> { drawnCard });

                if (!_currentPlayer.Hand.Any(card => card.Match(_currentCard)))
                {
                    PlayerNotification?.Invoke(this,  $"{_currentPlayer.Name}:No matching card found after drawing. Next player's turn.");
                    NextTurn();
                }
                else
                {
                    PlayerNotification?.Invoke(this, $"{_currentPlayer.Name}:You drew a card.");
                }
            }
        }

        /// <summary>
        /// Plays the specified card, removes it from the current player's hand, and applies its game effect.
        /// </summary>
        /// <param name="card">The card to be played.</param>
        public void PlayCard(Card card)
        {
            _currentPlayer.Hand.Remove(card);
            card.GameEffect(this); 
            Deck.DiscardCard(card);
            CurrentCard = card;

            Player winner = CheckWinner();
            if (winner != null)
            {
                EndGame();
            }
            else
            {
                NextTurn();
            }
        }

        /// <summary>
        /// Ends the game and announces the winner if one exists.
        /// </summary>
        public void EndGame()
        {
            Player winner = CheckWinner();
            if (winner != null)
            {
                Console.WriteLine($"{winner.Name} wins the game!");
                OnGameEnded?.Invoke(this, new GameEndedEventArgs(winner.Name));
            }
        }

        /// <summary>
        /// Checks if there is a winner by examining whether any player's hand is empty.
        /// </summary>
        /// <returns>The winning player if there is one, or null if the game is ongoing.</returns>
        public Player CheckWinner()
        {
            foreach (var player in _players)
            {
                if (player.Hand.Count == 0)
                {
                    return player;
                }
            }
            return null;
        }

        /// <summary>
        /// Allows the current player to take a double turn in the game.
        /// </summary>
        public void AllowDoubleTurn(){
            _isDoubleTurn = true;
        }

        /// <summary>
        /// he next player in turn order draws a specified number of cards from the deck.
        /// </summary>
        /// <param name="n">The number of cards to draw</param>
        public void NextPlayerDraws(int n)
        {
            int nextPlayerIndex = (_players.IndexOf(_currentPlayer) + 1) % _players.Count;
            var nextPlayer = _players[nextPlayerIndex];
            var drawnCards = _deck.DealCards(n);
            nextPlayer.ReceiveCards(drawnCards);
        }

        /// <summary>
        /// Reverses the turn order of the players in the game.
        /// </summary>
        public void ReverseTurnOrder(){
            _players.Reverse();
        }

        /// <summary>
        /// Skips the turn of the next player in the game.
        /// </summary>
        public void SkipNextPlayer(){
            NextTurn();
        }
        
    }
    
}