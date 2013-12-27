using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class.Shapes
{
    class Arrow:Shape
    {
        public Arrow(Color c,int lineSize,History his):base(c,lineSize,his)
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
            this.DrawArrow(x0, y0, w, h, im);
        }

        private void DrawArrow(int x, int y, int w, int h, Image im)
        {
            KeyValuePair<int, int>[] arr = new KeyValuePair<int, int>[7];
            arr[0] = new KeyValuePair<int, int>(x + w / 4, y + h);
            arr[1] = new KeyValuePair<int, int>(x + w / 4,
                y + (int)(((double)h * 4.0 / 10.0)));
            arr[2] = new KeyValuePair<int, int>(x,
                y + (int)(((double)h * 4.0 / 10.0)));
            arr[3] = new KeyValuePair<int, int>(x + w / 2,
                y);
            arr[4] = new KeyValuePair<int, int>(x + w,
                y + (int)(((double)h * 4.0 / 10.0)));
            arr[5] = new KeyValuePair<int, int>(x + w - w / 4,
                y + (int)(((double)h * 4.0 / 10.0)));
            arr[6] = new KeyValuePair<int, int>(x + w - w / 4,
                y + h);
            for (int i = 0; i < arr.Length - 1; i++)
                base.DrawLine(arr[i].Key, arr[i].Value, arr[i + 1].Key, arr[i + 1].Value, im);
            base.DrawLine(arr[6].Key, arr[6].Value, arr[0].Key, arr[0].Value, im);

        }
    }
}
