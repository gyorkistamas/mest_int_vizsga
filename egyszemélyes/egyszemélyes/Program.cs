namespace egyszemélyes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State state = new State();
            //Solver solver = new BackTrack(state);
            Solver solver = new BreadthFirst(state);
            Console.ReadLine();
        }
    }
}