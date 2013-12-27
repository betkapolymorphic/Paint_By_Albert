using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class.Shapes
{
    class Circle : Shape
    {
        public Circle(Color c,int lineSize,History his):base(c,lineSize,his)
        {

        }
        public override void Event(int x, int y, Image im)
        {
            base.history.endEvent();
            base.history.Undo(ref im);
            base.history.beginEvent();
            this.endEvent(x, y, im);

        }
        public override void endEvent(int x, int y, Image im)
        {
            int w = x - x0;
            int h = y - y0;
            this.DrawCircle(x0, y0, w, h, im);
        }

        private void DrawCircle(int x, int y, int w, int h, Image im)
        {
            int radius = Math.Min(Math.Abs(w), Math.Abs(h)) / 2;

            int x0 = x + w / 2;
            int y0 = y + h / 2;
            int X = 0;
            int Y = radius;
            int delta = 1 - 2 * radius;
            int error = 0;
            while (Y >= 0)
            {
                base.DrawPoint(x0 + X, y0 + Y, size / 2, im);
                base.DrawPoint(x0 - X, y0 + Y, size / 2, im);
                base.DrawPoint(x0 + X, y0 - Y, size / 2, im);
                base.DrawPoint(x0 - X, y0 - Y, size / 2, im);

                error = 2 * (delta + Y) - 1;
                if (delta < 0 && error <= 0)
                {
                    ++X;
                    delta += 2 * X + 1;
                    continue;
                }
                error = 2 * (delta - X) - 1;
                if (delta > 0 && error > 0)
                {
                    --Y;
                    delta += 1 - 2 * Y;
                    continue;
                }
                ++X;
                delta += 2 * (X - Y);
                --Y;

            }

        }
    }
}
