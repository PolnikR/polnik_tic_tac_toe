using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace polnik_tic_tac_toe
{
    internal class Game
    {
        int arraySize;
        char[,] arr2D;

        public Game(int arraySize)
        {
            this.arraySize = arraySize;
            arr2D = new char[arraySize, arraySize];

            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    arr2D[i, j] = '-';
                }
            }

        }

        public void PrintBoard()
        {
            Console.Write("  0 1 2");
            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                
                Console.WriteLine();
                Console.Write(i + " ");
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    
                    Console.Write(arr2D[i, j] + " ");
                }
            }
            Console.WriteLine();

        }

        public bool Is_Input_Valid(int x, int y)
        {
            if (x >arraySize || x<0 || y>arraySize || y<0) return false;
            if (arr2D[x,y] == 'X' || arr2D[x,y]=='O') return false;
            return true;
        }

        public void Pc_Input()
        { 
            Random random = new Random();

            int x = random.Next(0,arraySize);
            int y = random.Next(0, arraySize);
            while (!Is_Input_Valid(x, y))
            {
                int a = random.Next(0, arraySize);
                int b = random.Next(0, arraySize);

                x = a;
                y = b;
            }
            if (Is_Input_Valid(x, y)) arr2D[x, y] = 'O';
        }
        public void User_Input()
        {
            try
            {
                Console.WriteLine("Zadaj riadok: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Zadaj stlpec: ");
                int y = Convert.ToInt32(Console.ReadLine());
                while (!Is_Input_Valid(x, y))
                {
                    Console.WriteLine("Zadaj validne suradnice: ");
                    Console.WriteLine("Zadaj riadok: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Zadaj stlpec: ");
                    int b = Convert.ToInt32(Console.ReadLine());

                    x = a;
                    y = b;
                }
                if(Is_Input_Valid(x,y)) arr2D[x, y] = 'X';
            }
            catch 
            {
                Console.WriteLine("Zle zadane suradnice");
                User_Input();
            }
        }

        public int IsGameOver()
        {
            //kontola riadkov
            List<char> riadok = new List<char>();
            List<char> stlpec = new List<char>();
            List<char> uhlopriecka1 = new List<char>();
            List<char> uhlopriecka2 = new List<char>();
            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                int pocetRX=0;
                int pocetRO=0;

                int pocetSX = 0;
                int pocetSO = 0;
                riadok.Clear();
                stlpec.Clear();
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    //riadky
                    riadok.Add(arr2D[i, j]);
                    stlpec.Add(arr2D[j, i]);
                }
                pocetRX = riadok.Count(s => s == 'X');
                pocetRO = riadok.Count(s => s == 'O');

                pocetSX = stlpec.Count(s => s == 'X');
                pocetSO = stlpec.Count(s => s == 'O');

                if (pocetRX == arraySize ||  pocetSX == arraySize)
                {
                    return 1;
                }
                if (pocetRO == arraySize || pocetSO == arraySize) return -1;
            }
            int u1 = 0;
            int u2 = 2;
            for (int a = 0; a < arr2D.GetLength(0); a++)
            {
                uhlopriecka1.Add(arr2D[a, a]);
                uhlopriecka2.Add(arr2D[u1, u2]);
                u1++;
                u2--;
            }

            if(uhlopriecka1.Count(s=>s=='X') == arraySize || uhlopriecka2.Count(s => s == 'X') == arraySize)
            {
                return 1;
            }
            if (uhlopriecka1.Count(s => s == 'O') == arraySize || uhlopriecka1.Count(s => s == 'O') == arraySize)
            {
                return -1;
            }

            return 2;

        }


    }
}
