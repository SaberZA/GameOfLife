namespace GameOfLife
{
    public class MoreThanThreeCheck : Check
    {
        public MoreThanThreeCheck(Game game, int x, int y)
        {
            Point = new Point(x,y,game.Size);
            Game = game;
        }

        public override bool CheckRule()
        {
            var points = SurroundingHighlightedPoints();
            return points > 3;
        }
    }
}