using System.ComponentModel;

namespace MarsRover.Models
{
    public class Position
    {
        public Position()
        {

        }
        public Position(int  x,int  y,Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        /// <summary>
        /// Kuzey
        /// </summary>
        [Description("N")]
        North = 1,
        /// <summary>
        /// Doğu
        /// </summary>
        [Description("E")]
        East = 2,
        /// <summary>
        /// Güney
        /// </summary>
        [Description("S")]
        South = 3, 
        /// <summary>
        /// Batı
        /// </summary>
        [Description("W")]
        West = 4
    }

}
