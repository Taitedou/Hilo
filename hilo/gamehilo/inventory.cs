using System;

namespace Hilo.gamehilo
{
    //storage for points and cards
    public class InventoryPoint
    {
        int points = 300;

        public InventoryPoint(){
            
        }
        public int getPoints(){

            return points;
        }

        public int Guess(string input, int card, int prevCard){

            
            
            switch (input)
            {
                case "l":
                    if (card < prevCard )
                    {
                        points += 100;
                    }
                    else
                    {
                        points += -75;
                    }
                    break;

                case "h":
                if (card > prevCard )
                    {
                        points += 100;
                    }
                    else
                    {
                        points += -75;
                    }
                    
                    break;
                case "q":
                    points = 0;
                    break;
                default:
                    Console.WriteLine("Sorry, invalid input");
                    break;
            }

            return points;
            
        }
        
    }
}