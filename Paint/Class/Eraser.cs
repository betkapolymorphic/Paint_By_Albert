using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class
{
    class Eraser: Brush
    {
        public Eraser(int size,History his):base(Colors.White,his,size)
        {
            
        }

        public override bool setColor(Color color)
        {
            throw new Exception("Can't change color in Eraser\n");
        }
        public override Color getColor()
        {
            throw new Exception("Can't get collor, erase color is White\n");
        }
       
    }
}
