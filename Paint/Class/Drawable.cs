using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class
{
    public abstract class Drawable:ITool
    {
        public Drawable(Color c,History his)
        {
            this.color = c;
            this.color.A = 0;
            this.history = his;
        }
     
        protected void Draw(ref Image im, int x, int y)
        {
            if (x < 0 || x >= im.width || y < 0 || y >= im.height)
                return;
            if (save_in_history_change)
                history.addEvent(x, y, im.getColor(x, y), color);
            im.setPixel(x, y, color);
        }
        public virtual void beginEvent(int x,int y,Image im) 
        {
            //history.beginEvent();
        }
        public virtual void endEvent(int x, int y, Image im)
        {

        }
        public virtual void Event(int x, int y, Image im)
        {


        }
        public virtual bool setSize(int size)
        {
            return false;
            //throw new Exception("can't change size!");

        }
        public virtual int getSize()
        {
            throw new Exception("can't get Size");
        }
        public virtual Color getColor()
        {
            return this.color;
        }

        public virtual bool setColor(Color color)
        {
            this.color = color;
            return true;
        }

        protected History history;
        public bool save_in_history_change = true;
        public Color color;
        
    }
}
