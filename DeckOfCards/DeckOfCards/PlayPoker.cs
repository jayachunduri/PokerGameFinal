using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class PlayPoker
    {
        PokerPlayer player { get; set; }
        PokerPlayer comp { get; set; }
        Deck pokerDeck { get; set; }

        //Constructor
        public PlayPoker()
        {
            this.player = new PokerPlayer();
            this.comp = new PokerPlayer();
            this.pokerDeck = new Deck();
        }

        //methods
        public void PlayGame()
        {
            //shuffle the cards
            pokerDeck.Shuffle();

            //deal 5 cards for each player
            player.cards = pokerDeck.Deal(5);
            comp.cards = pokerDeck.Deal(5);

            Console.WriteLine("\nYour hand is");
            player.ShowHand();
            Console.WriteLine("\nComputer's hand is");
            comp.ShowHand();

            ////Check who has Highest Rank
            if (player.handType > comp.handType)
            {
                Console.WriteLine("congratulations you won!");
            }
            else if (player.handType < comp.handType)
            {
                Console.WriteLine("oops computer won");
            }
            else
            {
                Console.WriteLine("it's a tie");
            }
            
        }

        public void PrintCards()
        {
            Console.WriteLine("\nYour cards are");
            this.player.PrintPokerPlayersCards();

            Console.WriteLine("\nComputer's cards are");
            this.comp.PrintPokerPlayersCards();
        }
    }
}
