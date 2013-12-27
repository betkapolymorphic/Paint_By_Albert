using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Paint.Class.HelpfulClass
{
    class Color_Area
    {
        public Color_Area(int sizeBlock)
        {
            this.sizeBlockPx = sizeBlock;
            colors = new Color[30];

            //Generation ;D
            colors[0] = Colors.Red;
            colors[1] = Colors.Green;
            colors[2] = Colors.Black;
            colors[3] = Colors.Yellow;
            colors[4] = Colors.Gray;
            colors[5] = Colors.White;
            colors[6] = Colors.Black;
            colors[7] = Colors.Blue;
            colors[8] = Colors.Brown;
            colors[9] = Colors.Pink;
            colors[10] = Colors.Snow;
            colors[11] = Colors.Tan;
            colors[12] = Colors.Orange;
            colors[13] = Colors.Violet;
            colors[14] = Colors.Olive;
            colors[15] = Colors.Navy;
            colors[16] = Colors.Gold;
           


        }

        public BitmapSource getImageSource(int w,int h)
        {
            Random r = new Random();
            image = new Image(w * sizeBlockPx, h * sizeBlockPx,Colors.White);
            int X = 0;
            int Y = 0;
            for (int i = 0; i < colors.Length;i++ )
            {
                Color s = colors[i];

                if (i >= enteredColors)
                {
                    s.R = (byte)r.Next(0, 255);
                    s.G = (byte)r.Next(0, 255);
                    s.B = (byte)r.Next(0, 255);
                    s.A = (byte)r.Next(0, 255);
                }

                X = i % w;
                Y = i / w;
                for(int y=0;y<sizeBlockPx;y++)
                {
                    for (int x = 0; x < sizeBlockPx; x++)
                    {
                        image.setPixel(X*sizeBlockPx + x, Y*sizeBlockPx + y, s);
                    }
                }
            }


            Width = image.width;
            Height = image.height;
            return image.getImage();

            

        }
        private void setColor(int index)
        {

        }

        public int Width;
        public int Height;
        public Image image;
        
        private int sizeBlockPx=15;
        private int enteredColors = 16;
        
        private Color[] colors;
    }
}
