using System;
using System.ComponentModel.DataAnnotations;

namespace StateTracker
{
    public class Square
    {
        [Range(1, 10, ErrorMessage = "Square Value  must be between 1 and 10.")]
        public int X { get; set; }

        [Range(1, 10, ErrorMessage = "Square Value  must be between 1 and 10.")]
        public int Y { get; set; }

        public bool IsOccupied { get; set; } = false;

        public bool IsHit { get; set; } = false;

        public Square(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
