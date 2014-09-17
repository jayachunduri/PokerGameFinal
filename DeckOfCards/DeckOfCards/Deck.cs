using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Deck
    {
        //STEP 1. Declare properties
        public List<Card> CardList { get; set;}
        
        //STEP 2. Constructors
        public Deck()
        {
        CardList = new List<Card>();
    
            for (int j = 1; j <= 4; j++)
            {

                for (int i = 2; i <= 14; i++)
                {
                    Card card = new Card((Rank)i, (Suit)j);
                    
                    this.CardList.Add(card);
                }
            }
        }

        //STEP 3. Methods and Functions
        public void Shuffle()
        {
            Random rng = new Random();
            int totalCards = CardList.Count;
            while (totalCards > 1)
            {
                
                totalCards--;
                int randCard = rng.Next(0, totalCards);
                var x = CardList[randCard];
                CardList[randCard] = CardList[totalCards];
                CardList[totalCards] = x;
            }
        }

        public List<Card> Deal(int numDealt)
        {
            List<Card> dealCards = new List<Card>();
            for (int i = 0; i < numDealt; i++)
            {
                dealCards.Add(CardList[i]);
            }
            for (int i = 0; i < dealCards.Count; i++)
			{
                CardList.Remove(dealCards[i]);
			}

            return dealCards;
        }
        public void PrintDeck()
        {
            foreach (var item in CardList)
            {
                item.PrintCard();
            }
        }


    }
}
