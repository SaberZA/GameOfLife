namespace GameOfLife
{
    public class ThreeAndIsDead : Check
    {
        public ThreeAndIsDead(Game game, int x, int y)
        {
            Game = game;
            Point = new Point(x,y,game.Size);
        }

        public override bool CheckRule()
        {
            var points = SurroundingHighlightedPoints();
            return Game.ValueOfPoint(Point.X, Point.Y) == 0 && points == 3;
        }
    }
}