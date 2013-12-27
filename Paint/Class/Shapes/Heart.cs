using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class.Shapes
{
    class Heart : Shape
    {
        public Heart(Color c,int lineSize,History his):base(c,lineSize,his)
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
            this.DrawHeart(x0, y0, w, h, im);
        }

        double f(double x, double factor = 1.0)
        {
            if (x > 1 || x < -1)
                throw new Exception("cant get formula to heard reason x = [-1,1]");

            if (factor < 0)
                return -(Math.Sqrt(Math.Abs(x)) + Math.Sqrt(1 - Math.Pow(x, 2) * factor));
            return -(Math.Sqrt(Math.Abs(x)) + Math.Sqrt(1 - Math.Pow(x, 2) * factor) + 1.3);

        }
        private void DrawHeart(int x, int y, int w, int h, Image im)
        {
            double gz = 140;
            double multiplier = Math.Min(w, h);
            for (double X = 0; X < 1 - 0.0001; X += 1 / gz)
            {
                for (int factor = -1; factor <= 1; factor += 2)
                    for (int j = 1; j <= 2; j++)
                    {
                        X *= -1.0;
                        int pos1 = (int)((X - 1 / gz) * multiplier);
                        int pos2 = (int)((f(X - 1 / gz, factor)) * multiplier);
                        int pos3 = (int)((X) * multiplier);
                        int pos4 = (int)((f(X, factor)) * multiplier);
                        base.DrawLine(x + pos1, y + pos2, x + pos3, y + pos4, im);
                    }
            }
            //for(int X = x;X )
        }
    }
}
