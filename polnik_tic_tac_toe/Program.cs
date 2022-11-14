using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace polnik_tic_tac_toe
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
         * Na vstupe sa pytam hraca , ake velke ma byt pole 
         * Po zadaní vstupu od uzivatela, vytvorim funkciu pre vypisanie pola 
         * Potrebujem funkciu , ktore overy spravnost vstupov od uzivatela alebo do PC - Is_inputValid()
         * po overerení vstupu, zapise vstup od PC/uzivatela do pola - User_Input(), PC_Input() 
         * Po zapise znaku od Uzivatela/Pc skontrolujem , ci hra pokracuje , alebo ma vitaza
         */
    internal class Program
    {
        
        static void Main(string[] args)
        {



            Game game = new Game(3);


            while (game.IsGameOver(game.Array2D) == 2)
            {
                List<int> list = game.findBestMove(game.Array2D);
                game.Pc_Input(list[0], list[1]);
                game.PrintBoard();
                if (game.IsGameOver(game.Array2D) == -1)
                {
                    Console.WriteLine("Vyhral PC");
                    break;
                }

                game.User_Input();
                game.PrintBoard();
                if (game.IsGameOver(game.Array2D) == 1)
                {
                    Console.WriteLine("Vyhral srac");
                    break;
                }

            }

            Console.ReadLine();



        }


    }
}
