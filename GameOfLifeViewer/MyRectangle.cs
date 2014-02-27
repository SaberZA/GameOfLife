using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GameOfLifeViewer
{
    public class MyRectangle
    {
        public Rectangle Rectangle { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public MyRectangle()
        {
            Rectangle = new Rectangle();
        }
    }
}
