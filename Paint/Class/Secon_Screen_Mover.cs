using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Paint.Class
{
    class Secon_Screen_Mover_Shape
    {
        public Secon_Screen_Mover_Shape(Image im, System.Windows.Controls.Image imageBox,int realPosX, int realPosY)
        {
           
            this.image = im;
            this.x = realPosX;
            this.y = realPosY;
            
        }
        public void Began()
        {
            System.Windows.Controls.Image imageBox = new System.Windows.Controls.Image();
            imageBox.Width = image.width;
            imageBox.Height = image.height;

            main_window.Canvas_ImageBox.Children.Add(imageBox);
            main_window.imageBox.IsEnabled = false;

            imageBox.MouseDown+=imageBox_MouseDown;
            imageBox.MouseMove += imageBox_MouseMove;
            imageBox.MouseUp += imageBox_MouseUp;
            imageBox.MouseRightButtonDown += imageBox_MouseRightButtonDown;
        }

        void imageBox_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
                   
        }

        void imageBox_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        void imageBox_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
        }

        private void imageBox_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }
        MainWindow main_window;
        Image image;
        int x;
        int y;
    }
}
