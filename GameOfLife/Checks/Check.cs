using System.Linq;

namespace GameOfLife
{
    public abstract class Check
    {
        protected Point Point;
        protected Game Game;

        public abstract bool CheckRule();

        protected int SurroundingHighlightedPoints()
        {
            return Point.GetPointsToCheck().Count(p => Game.ValueOfPoint(p.X, p.Y) == 1);
        }
    }
}