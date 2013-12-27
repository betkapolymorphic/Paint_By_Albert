using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class
{
    class Brush:Drawable
    {
        public Brush(Color c ,History his,int size):base(c,his)
        {
            this.setSize(size);
            matrix = HelpfulClass.MatrixGenerator.generate("circle", size);
        }
        public void Begin_Path()
        {
            x_lastPosit = -1;
            y_lastPosit = -1;
        }
        public void EndPath()
        {

           
        }

        public void Draw(Image im, int x, int y)
        {
            //if (x_lastPosit == -1 && y_lastPosit == -1)
            //     this.DrawPoint(ref im, x, y);
            ////else if (Math.Abs(x - x_lastPosit) > size || Math.Abs(y - y_lastPosit) > size)
            //else   
            //    Connect_Two_Points(x_lastPosit, y_lastPosit, x, y, ref im);
            //im.drawCircle(x, y, size/2);
            //else
              //  this.DrawPoint(ref im, x, y);
            if (x_lastPosit == -1 && y_lastPosit == -1)
                this.DrawPoint(x, y, size / 2, im);
            else
                this.DrawLine(x_lastPosit, y_lastPosit, x, y, im);
                //Connect_Two_Points(x_lastPosit, y_lastPosit, x, y, ref im);
            x_lastPosit = x;
            y_lastPosit = y;

        }
        
        protected void DrawPoint(int x0, int y0, int radius,Image im)
        {
            int x = 0;
            int y = radius;
            int delta = 1 - 2 * radius;
            int error = 0;
            while (y >= 0)
            {
                for (int X = x0 - x; X <= x + x0; X++)
                    base.Draw(ref im,X, y0 + y);
                for (int X = x0 - x; X <= x + x0; X++)
                    base.Draw(ref im, X, y0 - y);

                error = 2 * (delta + y) - 1;
                if (delta < 0 && error <= 0)
                {
                    ++x;
                    delta += 2 * x + 1;
                    continue;
                }
                error = 2 * (delta - x) - 1;
                if (delta > 0 && error > 0)
                {
                    --y;
                    delta += 1 - 2 * y;
                    continue;
                }
                ++x;
                delta += 2 * (x - y);
                --y;

            }
        }
        protected void  DrawLine(int x1, int y1, int x2, int y2,Image im) 
        {
            int deltaX =(int)Math.Abs(x2 - x1);
            int deltaY = (int)Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            //
            int error = deltaX - deltaY;
            //
            this.DrawPoint(x2, y2, size / 2, im);
            while(x1 != x2 || y1 != y2) {
                this.DrawPoint(x1, y1, size / 2, im);
                int error2 = error * 2;
                //
                if(error2 > -deltaY) {
                    error -= deltaY;
                    x1 += signX;
                }
                if(error2 < deltaX) {
                    error += deltaX;
                    y1 += signY;
                }
            }
 
        }


        #region Override function

        public override bool setSize(int size)
        {
            //matrix = new bool[size, size];
            this.size = size;
            //matrix = Class.HelpfulClass.MatrixGenerator.generate("circle", size);
            //for (int i = 0; i < size; i++)
            //    for (int j = 0; j < size; j++)
            //    {
            //        matrix[i, j] = true;
            //    }
            return true;
        }

        public override int getSize()
        {
            return this.size;
        }

        public override void beginEvent(int x, int y, Image im)
        {
            this.Begin_Path();
            this.Draw(im, x, y);
        }
        public override void endEvent(int x, int y, Image im)
        {
           
            this.EndPath();
        }
        public override void Event(int x, int y, Image im)
        {
            this.Draw(im, x, y);
        }
        #endregion

        #region SHIIT
        //private void Connect_Two_Points(int x1, int y1, int x2, int y2, ref Image im)
        //{

        //    if (Math.Abs(x2 - x1) > Math.Abs(y2 - y1))
        //    {
        //        if (x1 < x2)
        //            for (int x = x1; x <= x2; x++)
        //            {
        //                double p1 = (x - x1) * (y2 - y1);
        //                double p2 = p1 / (x2 - x1);
        //                int y = (int)p2 + y1;

        //                this.DrawPoinT(ref im, x, y);
        //            }
        //        else
        //            for (int x = x1; x >= x2; x--)
        //            {
        //                double p1 = (x - x1) * (y2 - y1);
        //                double p2 = p1 / (x2 - x1);
        //                int y = (int)p2 + y1;

        //                this.DrawPoinT(ref im, x, y);
        //            }
        //    }
        //    else
        //    {
        //        if (y1 < y2)
        //            for (int y = y1; y <= y2; y++)
        //            {
        //                double p1 = (y - y1) * (x2 - x1);
        //                double p2 = p1 / (y2 - y1);
        //                int x = (int)p2 + x1;
        //                this.DrawPoinT(ref im, x, y);
        //            }
        //        else
        //            for (int y = y1; y > y2; y--)
        //            {
        //                double p1 = (y - y1) * (x2 - x1);
        //                double p2 = p1 / (y2 - y1);
        //                int x = (int)p2 + x1;
        //                this.DrawPoinT(ref im, x, y);
        //            }
        //    }
        //}
        //private void DrawPoinT(ref Image im,int x,int y)
        //{
        //    for (int i = 0; i < size; i++)
        //        for (int j = 0; j < size; j++)
        //        {
        //            if (matrix[i, j] == true)
        //            {
        //                if (x + j >= 0 && x + j < im.width && y + i >= 0 && y + i < im.height)
        //                {
        //                    ////im.setPixel(x, y, color);
        //                    base.Draw(ref im, x+j, y+i);
        //                }
        //            }
        //        }
        //}
        //protected void relaxEdge(HelpfulClass.X_Y_Set set, Image im, double percent)
        //{

        //    Color a = this.color;
        //    this.color = Colors.White;
        //    //this.color.A = (byte)(((double)this.color.A / 100) * percent);

        //    foreach (var i in set)
        //    {
        //        var val = i as HelpfulClass.X_Y_Set.x_y_color;

        //        int count = 0;
        //        int[] dx = { 0, 1, -1, 0 };
        //        int[] dy = { -1, 0, 0, 1 };
        //        for (int j = 0; j < 4; j++)
        //            if (!set.isContain(val.x + dx[j], val.y + dy[j]))
        //                count++;

        //        if (count >= 2)
        //        {
        //            // Color tmp = set[val.x, val.y];
        //            // tmp.A = (byte)(((double)tmp.A / 100) * percent);
        //            // set[val.x, val.y] = Colors.Red;
        //            base.Draw(ref im, val.x, val.y);
        //        }
        //    }
        //    this.color = a;
        //}
        #endregion

        public bool[,] matrix;
        public int size;
        private int x_lastPosit=-1, y_lastPosit=-1;
    }
}
