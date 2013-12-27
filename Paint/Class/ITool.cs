using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class
{
    public interface  ITool 
    {
	    void beginEvent(int x, int y, Image im);

	    void endEvent(int x, int y, Image im);

	    void Event(int x, int y, Image im);

	    int getSize();

	    bool setSize (int size);

	    Color getColor();

        bool setColor(Color color);

    }
}
