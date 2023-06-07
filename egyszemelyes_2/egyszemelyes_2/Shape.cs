using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
{
    public enum Shape
    {
        NONE,
        CIRCLE,
        SQUARE,
        GOAL,
        START
    }

    public static class Bovito
    {
        public static char Write(this Shape shape) => shape switch
        {
            Shape.NONE => '_',
            Shape.CIRCLE => Program.CIRCLE,
            Shape. SQUARE => Program.SQUARE,
            Shape.GOAL => 'G',
            Shape.START => 'S',
            _ => '_'
        };
    }
}
