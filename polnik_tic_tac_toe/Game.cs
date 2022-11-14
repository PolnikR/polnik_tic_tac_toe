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
        private int arraySize;
        private char[,] arr2D;

        public int ArraySize
        {
            get { return arraySize; }
            set { arraySize = value; }
        }

        public char[,] Array2D
        {
            get { return arr2D; }
            set { arr2D=value; }
        }

        public Game(int arraySize)
        {
            this.ArraySize = arraySize;
            Array2D = new char[ArraySize, ArraySize];

            for (int i = 0; i < Array2D.GetLength(0); i++)
            {
                for (int j = 0; j < Array2D.GetLength(1); j++)
                {
                    Array2D[i, j] = '-';
                }
            }

        }

        public void PrintBoard()
        {   
            Console.Write(" ");
            for (int a = 0; a < Array2D.GetLength(0); a++)
            {
                Console.Write($" {a}");
            }
            for (int i = 0; i < Array2D.GetLength(0); i++)
            {
                
                Console.WriteLine();
                Console.Write(i + " ");
                for (int j = 0; j < Array2D.GetLength(1); j++)
                {
                    
                    Console.Write(Array2D[i, j] + " ");
                }
            }
            Console.WriteLine();

        }

        public bool Is_Input_Valid(int x, int y)
        {
            if (x >ArraySize || x<0 || y>ArraySize || y<0) return false;
            if (Array2D[x,y] == 'X' || Array2D[x,y]=='O') return false;
            return true;
        }

        public void Pc_Input()
        { 
            Random random = new Random();

            int x = random.Next(0,ArraySize);
            int y = random.Next(0, ArraySize);
            while (!Is_Input_Valid(x, y))
            {
                int a = random.Next(0, ArraySize);
                int b = random.Next(0, ArraySize);

                x = a;
                y = b;
            }
            if (Is_Input_Valid(x, y)) Array2D[x, y] = 'O';
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
                if(Is_Input_Valid(x,y)) Array2D[x, y] = 'X';
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
            for (int i = 0; i < Array2D.GetLength(0); i++)
            {
                int pocetRX=0;
                int pocetRO=0;

                int pocetSX = 0;
                int pocetSO = 0;
                riadok.Clear();
                stlpec.Clear();
                for (int j = 0; j < Array2D.GetLength(1); j++)
                {
                    //riadky
                    riadok.Add(Array2D[i, j]);
                    stlpec.Add(Array2D[j, i]);
                }
                pocetRX = riadok.Count(s => s == 'X');
                pocetRO = riadok.Count(s => s == 'O');

                pocetSX = stlpec.Count(s => s == 'X');
                pocetSO = stlpec.Count(s => s == 'O');

                if (pocetRX == ArraySize ||  pocetSX == ArraySize)
                {
                    return 1;
                }
                if (pocetRO == ArraySize || pocetSO == ArraySize) return -1;
            }
            int u1 = 0;
            int u2 = 2;
            for (int a = 0; a < Array2D.GetLength(0); a++)
            {
                uhlopriecka1.Add(Array2D[a, a]);
                uhlopriecka2.Add(Array2D[u1, u2]);
                u1++;
                u2--;
            }

            if(uhlopriecka1.Count(s=>s=='X') == ArraySize || uhlopriecka2.Count(s => s == 'X') == ArraySize)
            {
                return 1;
            }
            if (uhlopriecka1.Count(s => s == 'O') == ArraySize || uhlopriecka1.Count(s => s == 'O') == ArraySize)
            {
                return -1;
            }

            return 2;

        }


    }
}
