using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get user name and pass it as a parameter
            Console.WriteLine("Welcome to Play Poker with the computer");
            PlayPoker pokerGame = new PlayPoker();

            pokerGame.PlayGame();

            pokerGame.PrintCards();
            
        }

        
    }
}
