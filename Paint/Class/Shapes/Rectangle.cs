using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class.Shapes
{
    class Rectangle:Shape
    {
        public Rectangle(Color c,int lineSize,History his):base(c,lineSize,his)
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
            this.DrawRectangle(x0, y0, w, h, im);
        }

        private void DrawRectangle(int x, int y, int w, int h, Image im)
        {
            base.DrawLine(x, y, x + w, y, im);
            base.DrawLine(x, y + h, x + w, y + h, im);
            base.DrawLine(x, y, x, y + h, im);
            base.DrawLine(x + w, y, x + w, y + h, im);
        }
    }
}
