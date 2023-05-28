namespace egyszemelyes_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BackTrack play = new BackTrack(new State(0, 0, 2));
            BreadthFirst game = new BreadthFirst(new State(0, 0, 2));
            Console.ReadKey();
        }
    }
}