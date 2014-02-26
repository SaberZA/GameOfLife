namespace GameOfLife
{
    public class FewerThanTwoCheck
        : Check
    {
        public FewerThanTwoCheck(Game game, int x, int y)
        {
            Point = new Point(x,y, game.Size);
            Game = game;
        }

        public override bool CheckRule() 
        {
            var points = SurroundingHighlightedPoints();
            return points < 2;
        }
    }
}