namespace egyszemelyes_2
{
    public class Program
    {
        public const char LEFTARROW      = '←';
        public const char UPLEFTARROW    = '↖';
        public const char UPARROW        = '↑';
        public const char UPRIGHTARROW   = '↗';
        public const char RIGHTARROW     = '→';
        public const char DOWNRIGHTARROW = '↘';
        public const char DOWNARROW     = '↓';
        public const char DOWNLEFTARROW  = '↙';
        public const char CIRCLE         = '⬤';
        public const char SQUARE         = '□';

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            State state = new State();

            BackTrack solve = new BackTrack(state);

            Console.ReadLine();
        }
    }
}