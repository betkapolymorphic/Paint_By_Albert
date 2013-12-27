using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class
{
    class Shape:Brush
    {

        public Shape(Color c,int lineSize,History his):base(c,his,lineSize)
        {
        }
        //public void setShape(E_Shapes shape)
        //{
        //    this.type = shape;
        //}

        public override void beginEvent(int x, int y, Image im)
        {
           
            this.x0 = x;
            this.y0 = y;
            
           
        }
        //public override void endEvent(int x, int y, Image im)
        //{
           
        //    int w = x - x0;
        //    int h = y - y0;

        //    switch(this.type)
        //    {
        //        case E_Shapes.Rectangle:
        //            this.DrawRectangle(x0, y0, w, h, im);
        //            break;
        //        case E_Shapes.Circle:
        //            this.DrawCircle(x0, y0, w, h, im);
        //            break;
        //        case E_Shapes.Triangel:
        //            this.DrawTriange(x0, y0, w, h, im);
        //            break;
        //        case E_Shapes.Line:
        //            this.DrawLine(x0, y0, w, h, im);
        //            break;
        //        case E_Shapes.Heart:
        //            this.DrawHeart(x0, y0, w, h, im);
        //            break;
        //        case E_Shapes.Arrow:
        //            this.DrawArrow(x0, y0, w, h, im);
        //            break;
        //    }
        //}
   
        
        //public override void Event(int x, int y, Image im)
        //{
        //    //Drawing Shape
            

        //    base.history.endEvent();
        //    base.history.Undo(ref im);
        //    base.history.beginEvent();
        //    this.endEvent(x, y, im);
        //    //Update screen
        //   // this.update_event(im);
            
        //}
        //private void DrawRectangle(int x,int y,int w ,int h,Image im)
        //{
        //    base.DrawLine(x, y, x + w, y, im);
        //    base.DrawLine(x , y + h, x + w, y +  h, im);
        //    base.DrawLine(x, y, x, y + h,im);
        //    base.DrawLine(x + w, y , x +  w, y + h,im);
        //}
        //private void DrawCircle(int x, int y, int w, int h, Image im)
        //{
        //    int radius = Math.Min(Math.Abs(w), Math.Abs(h))/2;

        //    int x0 = x + w / 2;
        //    int y0 = y + h / 2;
        //    int X = 0;
        //    int Y = radius;
        //    int delta = 1 - 2 * radius;
        //    int error = 0;
        //    while (Y >= 0)
        //    {
        //        base.DrawPoint(x0 + X, y0 + Y,size/2,im);
        //        base.DrawPoint(x0 - X, y0 + Y, size / 2, im);
        //        base.DrawPoint(x0 + X, y0 - Y, size / 2, im);
        //        base.DrawPoint(x0 - X, y0 - Y, size / 2, im);

        //        error = 2 * (delta + Y) - 1;
        //        if (delta < 0 && error <= 0)
        //        {
        //            ++X;
        //            delta += 2 * X + 1;
        //            continue;
        //        }
        //        error = 2 * (delta - X) - 1;
        //        if (delta > 0 && error > 0)
        //        {
        //            --Y;
        //            delta += 1 - 2 * Y;
        //            continue;
        //        }
        //        ++X;
        //        delta += 2 * (X - Y);
        //        --Y;

        //    }

        //}
        //private void DrawTriange(int x,int y,int w,int h,Image im)
        //{
        //    int x0 = x;
        //    int y0 = y + h;

        //    int x1 = x + w;
        //    int y1 = y + h;

        //    int x2 = x + w / 2;
        //    int y2 = y;
        //    //base.drawCircle( x0,y0,size/2,im);
        //    //base.drawCircle(x1, y1, size / 2, im);
        //    //base.drawCircle(x2, y2, size / 2, im);
        //    base.DrawLine(x0, y0, x1, y1, im);
        //    base.DrawLine(x1, y1, x2, y2, im);
        //    base.DrawLine(x2, y2, x0, y0, im);
        //}
        //private void DrawArrow(int x,int y,int w,int h,Image im)
        //{
        //    KeyValuePair<int, int>[] arr = new KeyValuePair<int, int>[7];
        //    arr[0] = new KeyValuePair<int, int>(x + w / 4, y + h);
        //    arr[1] = new KeyValuePair<int, int>(x + w / 4, 
        //        y + (int)(((double)h *4.0/10.0)));
        //    arr[2] = new KeyValuePair<int, int>(x,
        //        y + (int)(((double)h * 4.0 / 10.0)));
        //    arr[3] = new KeyValuePair<int, int>(x + w / 2,
        //        y);
        //    arr[4] = new KeyValuePair<int, int>(x + w,
        //        y + (int)(((double)h * 4.0 / 10.0)));
        //    arr[5] = new KeyValuePair<int, int>(x + w - w / 4,
        //        y + (int)(((double)h * 4.0 / 10.0)));
        //    arr[6] = new KeyValuePair<int, int>(x + w - w / 4,
        //        y + h);
        //    for (int i = 0; i < arr.Length - 1; i++)
        //        base.DrawLine(arr[i].Key, arr[i].Value, arr[i + 1].Key, arr[i + 1].Value, im);
        //    base.DrawLine(arr[6].Key, arr[6].Value, arr[0].Key, arr[0].Value, im);
            
        //}
        //private void DrawLine(int x,int y,int w,int h,Image im)
        //{
        //    base.DrawLine(x, y, x + w, y + h, im);
        //}
        //double f(double x,double factor = 1.0) 
        //{
        //    if (x > 1 ||  x < -1)
        //        throw new Exception("cant get formula to heard reason x = [-1,1]");

        //   if(factor<0) 
        //        return   -(Math.Sqrt(Math.Abs(x)) + Math.Sqrt(1 - Math.Pow(x, 2)*factor));
        //   return -(Math.Sqrt(Math.Abs(x)) + Math.Sqrt(1 - Math.Pow(x, 2) * factor) + 1.3);
            
        //}
        //private void DrawHeart(int x,int y,int w,int h,Image im)
        //{
        //    double gz = 140;
        //    double multiplier = Math.Min(w, h);
        //    for(double X=0; X < 1-0.0001  ; X+=1/gz)
        //    {
        //        for (int factor = -1; factor <= 1;factor+=2)
        //            for (int j = 1; j <= 2; j++)
        //            {
        //                X *= -1.0;
        //                int pos1 = (int)((X - 1 / gz) * multiplier);
        //                int pos2 = (int)((f(X - 1 / gz,factor)) * multiplier);
        //                int pos3 = (int)((X) * multiplier);
        //                int pos4 = (int)((f(X,factor)) * multiplier);
        //                base.DrawLine(x + pos1, y + pos2, x + pos3, y + pos4, im);
        //            }
        //    }
        //    //for(int X = x;X )
        //}

        //History to_draw;

        protected int x0,y0;
       
    }
}
