using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class.Shapes
{
    class Line : Shape
    {
        public Line(Color c,int lineSize,History his):base(c,lineSize,his)
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
            this.DrawLine(x0, y0, w, h, im);
        }
        private void DrawLine(int x, int y, int w, int h, Image im)
        {
            base.DrawLine(x, y, x + w, y + h, im);
        }    
    }
}
