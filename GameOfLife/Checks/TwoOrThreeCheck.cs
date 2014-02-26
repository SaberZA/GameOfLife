namespace GameOfLife
{
    public class TwoOrThreeCheck : Check
    {
        public TwoOrThreeCheck(Game game, int x, int y)
        {
            Game = game;
            Point = new Point(x, y, game.Size);
        }

        public override bool CheckRule()
        {
            var points = SurroundingHighlightedPoints();
            return points == 2 || points == 3;
        }
    }
}