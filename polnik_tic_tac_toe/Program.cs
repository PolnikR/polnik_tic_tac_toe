using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace polnik_tic_tac_toe
{
    internal class Program
    {
         /*
         * Project name : Eset coding challange Tic Tac Toe
         * Author       : Roman Polník
         * Phone Number : +421 907 474 723
         * 1 1 1
         * 2 2 2
         * 3 3 3
         * 
         * Process of creation:
         * 
         * Vytvorím triedu Game;
         * Inicializujem velkos pola
         * vytvorim pole
         * vytvorim funkciu pre vypisanie pola 
         * Potrebujem funkciu , ktore overy spravnost vstupov a zapise hraci znak do pola 
         * Potrebujem vytvorit funkciu , ktora bude kontolovat stav hracej plochy
         */
        static void Main(string[] args)
        {
            Game game = new Game(3);


            while (game.IsGameOver() == 2)
            {
                game.Pc_Input();
                game.PrintBoard();
                if (game.IsGameOver() == -1)
                {
                    Console.WriteLine("Vyhral PC");
                    break;
                }

                game.User_Input();
                game.PrintBoard();
                if (game.IsGameOver() == 1)
                {
                    Console.WriteLine("Vyhral srac");
                    break;
                }




            }

            Console.ReadLine();













        }

    }
}
