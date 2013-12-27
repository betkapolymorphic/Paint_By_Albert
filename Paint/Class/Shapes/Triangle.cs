using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class.Shapes
{
    class Triangle:Shape
    {
        public Triangle(Color c,int lineSize,History his):base(c,lineSize,his)
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
            this.DrawTriange(x0, y0, w, h, im);
        }

        private void DrawTriange(int x, int y, int w, int h, Image im)
        {
            int x0 = x;
            int y0 = y + h;

            int x1 = x + w;
            int y1 = y + h;

            int x2 = x + w / 2;
            int y2 = y;
            //base.drawCircle( x0,y0,size/2,im);
            //base.drawCircle(x1, y1, size / 2, im);
            //base.drawCircle(x2, y2, size / 2, im);
            base.DrawLine(x0, y0, x1, y1, im);
            base.DrawLine(x1, y1, x2, y2, im);
            base.DrawLine(x2, y2, x0, y0, im);
        }
    }
}
