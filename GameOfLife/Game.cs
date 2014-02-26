namespace GameOfLife
{
    public class Game
    {
        public Game(int size)
        {
            SetBoard(size);
        }

        public int Size { get { return Board.Length; }}
        protected int[][] Board { get; set; }

        public int Width
        {
            get { return Size; }
        }

        public int Height 
        {
            get { return Size; }
        }

        public void SetBoard(int size)
        {
            Board = new int[size][];
            for (int i = 0; i < Board.Length; i++)
                Board[i] = new int[size];
        }

        public void Toggle(int x, int y)
        {
            Board[x][y] = (Board[x][y] + 1)%2;
        }

        public int ValueOfPoint(int x, int y)
        {
            return Board[x][y];
        }

        public bool PointHasFewerThanTwoNeighbours(int x, int y)
        {
            Check hasFewerThanTwoNeighbours = new FewerThanTwoCheck(this, x, y);
            return hasFewerThanTwoNeighbours.CheckRule();
        }

        public bool PointHasTwoOrThreeNighbours(int x, int y)
        {
            Check hasTwoOrThreeNeighbours = new TwoOrThreeCheck(this, x, y);
            return hasTwoOrThreeNeighbours.CheckRule();
        }

        public bool PointHasMoreThanThreeNeighbours(int x, int y)
        {
            Check hasMoreThanThreeNighbours = new MoreThanThreeCheck(this, x, y);
            return hasMoreThanThreeNighbours.CheckRule();
        }

        public bool PointHasThreeNeighboursAndIsDead(int x, int y)
        {
            Check hasThreeNeighboursAndIsDead = new ThreeAndIsDead(this, x, y);
            return hasThreeNeighboursAndIsDead.CheckRule();
        }

        public void Proc()
        {
            for (int colIndex = 0; colIndex < Board.Length; colIndex++)
            {
                int[] col = Board[colIndex];
                for (int rowIndex = 0; rowIndex < col.Length; rowIndex++)
                {
                    int row = col[rowIndex];

                    if (PointHasFewerThanTwoNeighbours(colIndex, rowIndex))
                    {
                        Toggle(colIndex, rowIndex);
                        continue;
                    }
                    if (PointHasTwoOrThreeNighbours(colIndex, rowIndex))
                    {
                        Toggle(colIndex, rowIndex);
                        continue;
                    }
                    if (PointHasMoreThanThreeNeighbours(colIndex, rowIndex))
                    {
                        Toggle(colIndex, rowIndex);
                        continue;
                    }
                    if (PointHasThreeNeighboursAndIsDead(colIndex, rowIndex))
                    {
                        Toggle(colIndex, rowIndex);
                        continue;
                    }
                }
            }

            
            
        }
    }
}