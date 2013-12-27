using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class
{
    class Filler:Drawable
    {
        public Filler(Color c,History his):base(c,his)
        {

        }
        private bool compareColor(Color c1,Color c2)
        {
            float delta=10;
           
            if (!(c1.B < c2.B + delta && c1.B > c2.B - delta))
                return false;
            if (!(c1.R < c2.R + delta && c1.R > c2.R - delta))
                return false;
            if (!(c1.G < c2.G + delta && c1.G > c2.G - delta))
                return false;
            return true;
        }
        public void fill(int x, int y, Image im)
        {
            Color c = im.getColor(x, y);
            if (c == this.color)
                throw new Exception("can't fill same color!");
            
            Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>();
            stack.Push(new KeyValuePair<int, int>(x, y));
             
            try
            {
                while (stack.Count != 0)
                {
                    var pos = stack.Pop();
                    base.Draw(ref im, pos.Key, pos.Value);

                    if (pos.Key - 1 >= 0 && compareColor(im.getColor(pos.Key - 1, pos.Value),c))
                        stack.Push(new KeyValuePair<int, int>(pos.Key - 1, pos.Value));

                    if (pos.Key + 1 < im.width && compareColor(im.getColor(pos.Key + 1, pos.Value),c))
                        stack.Push(new KeyValuePair<int, int>(pos.Key + 1, pos.Value));

                    if (pos.Value + 1 < im.height && compareColor(im.getColor(pos.Key, pos.Value + 1),c))
                        stack.Push(new KeyValuePair<int, int>(pos.Key, pos.Value + 1));

                    if (pos.Value - 1 >= 0 && compareColor(im.getColor(pos.Key, pos.Value - 1),c))
                        stack.Push(new KeyValuePair<int, int>(pos.Key, pos.Value - 1));
                }
            }
            catch(Exception ex)
            {
                throw new Exception("stack over flow fill!");
            }

        }

        public override void beginEvent(int x, int y, Image im)
        {
            this.fill(x, y, im);
        }

    }
}
