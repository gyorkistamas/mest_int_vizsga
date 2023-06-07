namespace ketszemelyes_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State asd = new State();
            asd.SetStartingState();

            //Console.WriteLine(asd);

            MiniMax solver = new MiniMax(asd, 4);

            solver.Play();

            Console.ReadKey();
        }
    }
}