using System;
using System.Collections.Generic;
namespace Hilo.gamehilo
{

    //the responsibility of the director is to control the sequence of the game
    //start 300, guess whether next card will be higher or lower
    //if correct add 100, if incorrect subtract 75, game ends at 0 or when you want
    public class Director
    {

        int cardIndex = 0;
        int card;
        int prevCard;

        public bool playgame = true;

        InventoryPoint inv = new InventoryPoint();

        // List<int> deck = new List<int>();
        
        public Director()
        {
            welcome();
            startGame();


        }

        //Welcome message
        void welcome(){
            Console.WriteLine("Welcome To Hilo!\n");
            Console.WriteLine("A card will be displayed.");
            Console.WriteLine("It is up to you to guess if the next card is higher or lower");
            Console.WriteLine("You have 300 points. If you guess correctly you gain 100 points.");
            Console.WriteLine("If you guess incorrectly, you lose 75 points");
            Console.WriteLine("The game ends when you reach 0 or if you quit.\n");
            
        }
        
        void startGame(){
            card = DrawCard();
            int round = 1;
            while(playgame){
                Console.WriteLine($"round {round} Point: {inv.getPoints()}");
                Console.WriteLine($"Your Card is {card}");
                Console.Write("Higher or Lower? Quit (h/l/q): ");
                string input = Console.ReadLine().ToLower();
                if (GameOver(input)){
                    break;
                }
                GetNextCard();
                Console.WriteLine($"Your next card is {card}\n");
                Console.WriteLine();
                inv.Guess(input, card, prevCard);
                round ++;
                
            }

            
        }
        /// <summary>
        /// picks a card instance from the deck list
        /// and saves it to a temporary card;
        /// </summary>
        
        int DrawCard()
        {
            Random random = new Random();
            cardIndex = random.Next(1,14);
            return cardIndex;
        }



        void GetNextCard(){
            bool cardLoop = true;
            
            prevCard = card;
            
            while (cardLoop)
            {
                card = DrawCard();
                if(prevCard != card){
                    cardLoop = false;
                }
                
            }
        }
        bool GameOver(string input){
            
            if (inv.getPoints() <= 0){
                playgame = false;
                return true;
            }

            
            if (input == "q"){
                playgame = false;
                return true;
            }
            return false;
        }

    }
}
