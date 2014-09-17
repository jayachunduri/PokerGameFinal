using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    public enum HandRank
    {
        HighCard,
        OnePair = 20,
        TwoPairs = 30,
        ThreeOfAKind = 40,
        Straight = 50,
        Flush = 60,
        FullHouse = 70,
        FourOfAKind = 80,
        StraightFlush = 90,
        RoyalFlush = 100
    }

    class PokerPlayer
    {
        //Step1 property
        public List<Card> cards;
        public HandRank handType;

        //Step2 Constructor
        public PokerPlayer()
        {
            cards = new List<Card>();
            handType = HandRank.HighCard;
        }

        //Step3 methods or functions
        public void DrawHand()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            cards = deck.Deal(5);
        }

        //means cards have only one pair. We only look at Rank
        public bool OnePair()
        {
            //Rank rankOfCards = new Rank();
            //string[] rankOfCards = new string[5];
            //int i =0;

            //foreach (var item in cards)
            //{
            //    rankOfCards[i] = item.Rank.ToString();
            //}

            //below select statement does exactly the above task
            return this.cards.Select(x=> x.Rank).Distinct().Count() == 4;
        }

        //means cards have only two pairs. We only look at Rank
        public bool TwoPairs()
        {
            //we need to group them and verify if 2 groups have 2 pairs
            IEnumerable<IGrouping<Rank, Card>> group = this.cards.GroupBy(x=> x.Rank);
            return group.Count(x => x.Count() == 2) == 2;
            //here x is a individual group. So first we are counting how many cards are there in individual group, then those groups should be only 2
        }

        //function for 3 of a kind. 3 cards and 2 differect cards
        public bool ThreeOfAKind()
        {
            //Group the cards based on their rank
            IEnumerable<IGrouping<Rank, Card>> group = this.cards.GroupBy(x => x.Rank);
            if (group.Count() == 3)
            {
                return group.Count(x => x.Count() == 3) == 1;
            }
            else
                return false;
        }

        //Straight: All cards are consecutive values
        public bool Straight()
        {
            //If 5 cards have 5 distinct cards then only we need to verify for consecutive values
            if (cards.Select(x => x.Rank).Distinct().Count() == 5)
            {
                cards.OrderByDescending(x => x.Rank);
                return cards.First().Rank - cards.Last().Rank == 4;
            }
            else //else there is atlest one pair
                return false;
        }

        //Flush: All cards of the same suit
        public bool Flush()
        {
            return cards.Select(x => x.Suit).Distinct().Count() == 1;
        }

        //Three of a kind and a pair
        public bool FullHouse()
        {
            IEnumerable<IGrouping<Rank, Card>> group = this.cards.GroupBy(x => x.Rank);

            //even though there are 2 groups there might be 4 in a group
            if (group.Count() == 2)
            {
                return group.Count(x => x.Count() == 3) == 1;
            }
            else
                return false;
        }

        //Four of a kind
        public bool FourOfAKind()
        {
            IEnumerable<IGrouping<Rank, Card>> group = this.cards.GroupBy(x => x.Rank);

            //even though there are 2 groups there might be 3 in a group
            if (group.Count() == 2)
            {
                return group.Count(x => x.Count() == 4) == 1;
            }
            else
                return false;
        }

        //Straight Flush: All cards are consecutive values of same suit
        //means its a Flush and Straight
        public bool StraightFlush()
        {
            if (Flush())
            {
                return Straight();
            }
            else
                return false;
        }

        //Royal Flush: Ten, Jack, Queen, King, Ace in the same suit
        //means StraightFlush with a Ace
        public bool RoyalFlush()
        {
            return (StraightFlush() && this.cards.Any(x => x.Rank == Rank.Ace));
        }

        //High Card: Gets the card with highest rank
        public Card HighCard()
        {
            return this.cards.OrderByDescending(x => x.Rank).First();
        }

        //Function to show hand
        public void ShowHand()
        {
            //verify of Royal Flush
            if (RoyalFlush())
            {
                this.handType = HandRank.RoyalFlush;
                Console.WriteLine("Wow you got a lucky hand. You got a ROYAL FLUSH\nYour Score is: " +(int)this.handType);
            }
            else if (StraightFlush())
            {
                this.handType = HandRank.StraightFlush;
                Console.WriteLine("Wow you got a good hand. You got a STRAIGHT FLUSH\nYour Score is: " + (int)this.handType);
            }
            else if(FourOfAKind())
            {
                this.handType = HandRank.FourOfAKind;
                Console.WriteLine("You got FOUR OF A KIND\nYour Score is: " + (int)this.handType);
            }
            else if (FullHouse())
            {
                this.handType = HandRank.FullHouse;
                Console.WriteLine("You got FOUR OF A KIND\nYour Score is: " + (int)this.handType);
            }
            else if (Flush())
            {
                this.handType = HandRank.Flush;
                Console.WriteLine("You got FLUSH\nYour Score is: " + (int)this.handType);
            }
            else if (Straight())
            {
                this.handType = HandRank.Straight;
                Console.WriteLine("You got STRAIGHT\nYour Score is: " + (int)this.handType);
            }
            else if (ThreeOfAKind())
            {
                this.handType = HandRank.ThreeOfAKind;
                Console.WriteLine("You got THREE OF A KIND\nYour Score is: " + (int)this.handType);
            }
            else if (TwoPairs())
            {
                this.handType = HandRank.TwoPairs;
                Console.WriteLine("You got TWO PAIRS\nYour Score is: " + (int)this.handType);
            }
            else if (OnePair())
            {
                this.handType = HandRank.OnePair;
                Console.WriteLine("You got ONE PAIR\nYour Score is: " + (int)this.handType);
            }
            else //Show players High Card
            {
                this.handType = HandRank.HighCard;
                Console.WriteLine("Better luck next time your HIGH CARD and also your Score is: " + (int)this.cards.Max(x => x.Rank));
            }
            
        }

        public void PrintPokerPlayersCards()
        {
            foreach (var item in cards)
            {
                item.PrintCard();
            }
        }
    }
}
