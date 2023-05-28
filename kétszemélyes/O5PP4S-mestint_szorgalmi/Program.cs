using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O5PP4S_mestint_szorgalmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int difficulty = -1;

            Console.WriteLine("Select your difficulty:");

            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Hard");
            do
            {
                Console.Write("Your choice: ");
                int.TryParse(Console.ReadLine(), out difficulty);
            } while (difficulty < 1 || difficulty > 3);

            int depth = -1;

            switch (difficulty)
            {
                case 1:
                    depth = 0;
                    break;
                case 2:
                    depth = 1;
                    break;
                case 3:
                    depth = 5;
                    break;
            }

            Console.Clear();

            MiniMax game = new MiniMax(new State(), depth);

            game.Play();


            Console.ReadLine();
        }
    }
}
