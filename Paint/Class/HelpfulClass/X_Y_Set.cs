using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class.HelpfulClass
{
    public class X_Y_Set
    {
        public class  x_y_color
        {
            public x_y_color(int x,int y,Color x_y_color)
            {
                this.x = x;
                this.y = y;
                this.c = x_y_color;
            }
            public Color c;
            public int x;
            public int y;
        }
        public X_Y_Set (X_Y_Set t)
        {
            
            
        }
        public X_Y_Set(int h)
        {
            dict = new Dictionary<int, Color>[h];
            for (int i = 0; i < h; i++)
                dict[i] = new Dictionary<int, Color>();
        }
        public bool add(int x, int y, Color c)
        {
            if (dict[y].ContainsKey(x))
                return false;
            dict[y].Add(x, c);
            return true;
        }
        public void clear()
        {
            for (int i = 0; i < dict.Length; i++)
                dict[i] = new Dictionary<int, Color>();

        }
        public int getSize()
        {
            int size = 0;

            for (int i = 0; i < dict.Length; i++)
                size += dict[i].Count;
            return size;
        }
        public Dictionary<int, Color>[] getDict()
        {
            return this.dict;
        }
        public bool isContain(int x,int y)
        {
            if (dict[y].ContainsKey(x))
                return true;
            return false;
        }
        
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < dict.Length; i++)
                foreach (var j in dict[i])
                    yield return new x_y_color(j.Key, i , j.Value);
        }
        public Color this[int x,int y]
        {
            get
            {
                return dict[y][x];
            }
            set
            {
                if (dict[y].ContainsKey(x))
                    dict[y][x] = value;
                else
                    throw new Exception("X_Y_Set not contain : y = " + y.ToString()
                        + "  ,x = " + x.ToString());
            }
        }
        Dictionary<int, Color>[] dict;
    }
        
}
