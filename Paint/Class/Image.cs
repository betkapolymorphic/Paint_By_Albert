using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Paint.Class
{
    public class Image
    {
        public Image(BitmapImage im)
        {
            this.location = im.UriSource.AbsolutePath;
            this.width = im.PixelWidth;
            this.height = im.PixelHeight;


            int stride = im.PixelWidth * 4;
            MatrixOfColor= new byte[stride * im.PixelHeight];
            im.CopyPixels(MatrixOfColor, stride, 0);
           
        }
        public Image(int w,int h,Color cs)
        {
            MatrixOfColor = new byte[w * h * 4];
            for(int i=0;i< w*h*4 ;i+=4)
            {
                MatrixOfColor[i] = cs.B;
                MatrixOfColor[i + 1] = cs.G;
                MatrixOfColor[i + 2] = cs.R;
                MatrixOfColor[i + 3] = cs.A;
            }
            this.width = w;
            this.height = h;
        }
        


        public Color getColor(int x, int y)
        {
            if (x > width || x < 0 || y > height || y < 0)
                throw new Exception("Out from image!");

            Color c = new Color();
            int pos = (y * width * 4) + (x * 4);
            c.B = MatrixOfColor[pos];
            c.G = MatrixOfColor[pos + 1];
            c.R = MatrixOfColor[pos + 2];
            c.A = MatrixOfColor[pos + 3];
            return c;

        }
        public byte[] getBytes_RGB()
        {
            return this.MatrixOfColor;
        }
        public BitmapSource getImage()
        {

            var pixelFormat = PixelFormats.Pbgra32; // for example
            var bytesPerPixel = (pixelFormat.BitsPerPixel + 7) / 8;
            var stride = bytesPerPixel * width;

            var bitmap = BitmapSource.Create(width, height, 72, 72,
                                             pixelFormat, null, MatrixOfColor, stride);
            return bitmap;
            //BitmapImage im = new BitmapImage();
            //im.SourceRect = bitmap;
            //return bitmap;

        }
        public bool setPixel(int x, int y, Color c)
        {
            if (x > width || x < 0 || y > height || y < 0)
                return false;

            int pos = (y * width * 4) + (x * 4);

           

            MatrixOfColor[pos] = c.B;
            MatrixOfColor[pos + 1] = c.G;
            MatrixOfColor[pos + 2] = c.R;
            MatrixOfColor[pos + 3] = c.A;
            return true;


        }
        public string getLocation()
        {
            return this.location;
        }
        public void setLocation(string location)
        {
            this.location = location;
        }
        #region Fields

        private string location="";
        private byte[] MatrixOfColor;
        public int height;
        public int width;
        #endregion
    }
}
