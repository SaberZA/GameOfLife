using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Point
    {
        private readonly int _boardSize;

        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }

        public Point(int x, int y, int size)
        {
            X = x;
            Y = y;
            _boardSize = size;
        }

        public int Y { get; private set; }

        public int X { get; private set; }

        public List<Point> GetPointsToCheck()
        {
            var pointLeft = new Point(X - 1, Y);
            var pointTopLeft = new Point(X - 1, Y - 1);
            var pointTop = new Point(X, Y - 1);
            var pointTopRight = new Point(X + 1, Y - 1);
            var pointRight = new Point(X + 1, Y);
            var pointBottomRight = new Point(X + 1, Y + 1);
            var pointBottom = new Point(X, Y + 1);
            var pointBottomLeft = new Point(X - 1, Y + 1);

            var pointsToCheck = new List<Point>
                {
                    pointLeft,
                    pointTopLeft,
                    pointTop,
                    pointTopRight,
                    pointRight,
                    pointBottomRight,
                    pointBottom,
                    pointBottomLeft
                };

            pointsToCheck = pointsToCheck.Where(p => p.X >= 0 && p.Y >= 0 && p.X < _boardSize && p.Y < _boardSize).ToList();
            return pointsToCheck;
        }
    }
}