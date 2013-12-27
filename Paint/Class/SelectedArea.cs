using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Class
{
   public class SelectedArea :  ITool
    {

	    public int Startedx;
        public int Startedy;
        Canvas canvas;
        Rectangle rect;
        const int margin = 10;
        public SelectedArea(Canvas s)
        {
            this.canvas = s;
        }

        
	    public virtual Image Copy()
	    {
		    throw new System.NotImplementedException();
	    }

	    public virtual bool Fill(Color c)
	    {
		    throw new System.NotImplementedException();
	    }
       

	    public virtual void Delete()
	    {
		    throw new System.NotImplementedException();
	    }

	    public virtual void beginEvent(int x, int y, Image im)
	    {
            rect = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Startedx = 10 + x;
            Startedy = 10 + y;
            Canvas.SetLeft(rect, 10+x);
            Canvas.SetTop(rect, 10+y);
            

            canvas.Children.Add(rect);
	    }

	    public virtual void endEvent(int x, int y, Image im)
	    {
           canvas.Children.Remove(rect);
            
	    }

	    public virtual void Event(int x, int y, Image im)
	    {
           
            if(x > Startedx && y > Startedx)
            {
                rect.Width = Math.Abs(x - Startedx) ;
                rect.Height = Math.Abs(y - Startedy);
            }
            //else  if(x < Startedx && y > Startedx)
            //{
            //    Canvas.SetRight(rect, 10 + x);
            //    Canvas.SetTop(rect, 10 + y);

            //    rect.Width = Math.Abs(x - Startedx);
            //    rect.Height = Math.A(y - Startedy);
            //}

            //var X = Math.Min(x, Startedx);
            //var Y = Math.Min(y, Startedy);

            //var w = Math.Max(x, Startedx) - x;
            //var h = Math.Max(y, Startedy) - y;

            //rect.Width = w;
            //rect.Height = h;

            //Canvas.SetLeft(rect, x);
            //Canvas.SetTop(rect, y);
	    }

	    public virtual int getSize()
	    {
		    throw new System.NotImplementedException();
	    }

	    public virtual bool setSize(int size)
	    {
		    throw new System.NotImplementedException();
	    }

	    public virtual Color getColor()
	    {
		    throw new System.NotImplementedException();
	    }

	    public virtual bool setColor(Color color)
	    {
		    throw new System.NotImplementedException();
	    }

    }

}
