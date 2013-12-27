using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Paint.Class.HelpfulClass
{
    class Menu
    {
        public Menu(Image im,MainWindow w)
        {
            this.image = im;
            this.window = w;
        }
        public void Save()
        {
            if (image.getLocation() != "")
            {
                var source = image.getImage();
                string type = image.getLocation().Split('.')[image.getLocation().Split('.').Length - 1];
                BitmapEncoder encoder;
                switch (type)
                {
                    case "png":
                        encoder = new PngBitmapEncoder();
                        break;
                    case "bmp":
                        encoder = new BmpBitmapEncoder();
                        break;
                    default:
                        encoder = new JpegBitmapEncoder();
                        break;
                }
                encoder.Frames.Add(BitmapFrame.Create(source));

                using (var filestream = new FileStream(image.getLocation(), FileMode.Create))
                    encoder.Save(filestream);
            }
            else
                this.Save_As();
        }
        public void Save_As()
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "*.png|*.png|*.jpg|*.jpg|*.bmp|*.bmp|All files (*.*)|*.*";
            dialog.RestoreDirectory = true;
           
            if(dialog.ShowDialog()== DialogResult.OK)
            {
                var source = image.getImage();
                BitmapEncoder encoder;
                string type = dialog.FileName.Split('.')[dialog.FileName.Split('.').Length - 1];
                switch (type)
                {
                    case "jpg":
                        encoder = new JpegBitmapEncoder();
                        break;
                    case "bmp":
                        encoder = new BmpBitmapEncoder();
                        break;
                    default:
                        encoder = new PngBitmapEncoder();
                        break;
                        
                } 
                encoder.Frames.Add(BitmapFrame.Create(source));
                
                using (var filestream = new FileStream(dialog.FileName, FileMode.Create))
                    encoder.Save(filestream);
                image.setLocation(dialog.FileName);
            }  
        }
        public void Open()
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                Uri uri=new Uri(dialog.FileName);
                var im=new Image(new BitmapImage(uri));
                this.image = im;
                window.history = new History(15, im.height);
                window.canvas_ImageBoxCreate(im);

                window.setUpToolBox();
                
                // window = new MainWindow(uri);
            }

        }
        public void New()
        {
            Window_CreateImage wind = new Window_CreateImage();
            wind.ShowDialog();

            if(wind.isDialogResultConfirm)
            {
                var im = new Image(wind.width, wind.height,wind.color);
                this.image = im;
                window.history = new History(15, im.height);
                window.canvas_ImageBoxCreate(im);
                window.setUpToolBox();

            }

        }
        //public void SaveImage
        private Image image;
        MainWindow window;
    }
}
