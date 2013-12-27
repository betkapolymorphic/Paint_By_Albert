
using System;
using System.Collections.Generic;
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

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        private Class.Image image;
        
        private Class.HelpfulClass.Color_Area colorArea;
        
        private Class.Toolbox toolBox;
        private Color color;
        private Class.HelpfulClass.Menu menu;


        bool isMouseDown = false;
       

        public void setUpToolBox()
        {
            toolBox = new Class.Toolbox(image);

            this.color = toolBox.getColor();

            

            toolBox.addTool("Brush", new Class.Brush(color,history,1));
            toolBox.addTool("Filler", new Class.Filler(color, history));
            toolBox.addTool("Eraser", new Class.Eraser(1, history));
            //toolBox.addTool("Shape", new Class.Shape(color, 1, history,Class.Shape.E_Shapes.Circle));
            toolBox.addTool("Rectangle", new Class.Shapes.Rectangle(color,1,history));
            toolBox.addTool("Arrow", new Class.Shapes.Arrow(color, 1, history));
            toolBox.addTool("Heart", new Class.Shapes.Heart(color, 1, history));
            toolBox.addTool("Line", new Class.Shapes.Line(color, 1, history));
            toolBox.addTool("Circle", new Class.Shapes.Circle(color, 1, history));
            toolBox.addTool("Triangle", new Class.Shapes.Triangle(color, 1, history));
            


            toolBox.addTool("Color Picker", new Class.ColorPicker(delegate(object c)
            {
                rectangle_SelectedColor.Fill = new SolidColorBrush((Color)(c));
                toolBox.setColor((Color)(c));
            }));

            toolBox.addTool("Selected Area", new Class.SelectedArea(Canvas_ImageBox));
            //(toolBox.getTool("Brush") as Class.Brush).matrix = Class.HelpfulClass.MatrixGenerator.generate("circle", 13, 13);
            //            (toolBox.getTool("Brush") as Class.Brush).setSize(2);

            toolBox.setTool("Brush");

        }
        public Class.History history;
        public void canvas_ImageBoxCreate(Class.Image im)
        {
            this.image = im;

            //history = new Class.History(5, image.height);
            imageBox.Source = image.getImage();
            imageBox.Width = image.width;
            imageBox.Height = image.height;
            

            Canvas_ImageBox.Width = image.width + 20;
            Canvas_ImageBox.Height = image.height + 20;
        }


        
        public MainWindow()
        {
            InitializeComponent();
            //var s = Environment.CurrentDirectory+@"\null.jpg";
            //Uri uri = new Uri(s);
            //BitmapImage im = new BitmapImage(uri);
            //image = new Class.Image(im);

            color = Colors.Black;

            
            image = new Class.Image(300, 300,Colors.White);
            history = new Class.History(15, image.height);
            
            

            menu = new Class.HelpfulClass.Menu(image, this);

            this.canvas_ImageBoxCreate(this.image);
            setUpToolBox();


            colorArea = new Class.HelpfulClass.Color_Area(16);
            
            imageBox_Colors.Source = colorArea.getImageSource(10, 3);
            imageBox_Colors.Width = colorArea.Width;
            imageBox_Colors.Height = colorArea.Height;
            canvas_ColorsArea.Height = colorArea.Height + 20;

            comboBox_SizeBrush.SelectedIndex = 0;

            
            
        }
       

        private void imageBox_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(!isMouseDown)
                return;
            try
            {
                int x = (int)e.GetPosition(imageBox).X;
                int y = (int)e.GetPosition(imageBox).Y;
                toolBox.Event(x, y);
                imageBox.Source = image.getImage();
            }
            catch (Exception ex)
            {
                //if(ex.Message=="Out from image!")
                //{
                //    int x = (int)e.GetPosition(imageBox).X;
                //    int y = (int)e.GetPosition(imageBox).Y;
                //    isMouseDown = false;
                //    toolBox.endEvent(x, y);
                //    history.endEvent();

                //    imageBox.Source = image.getImage(2);
                //}
                //else   
                MessageBox.Show(ex.Message);
            }
        	// TODO: Add event handler implementation here.
        }

        private void imageBox_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(isMouseDown)
            {
                int x = (int)e.GetPosition(imageBox).X;
                int y = (int)e.GetPosition(imageBox).Y;
                isMouseDown=false;
                toolBox.endEvent(x, y);
                history.endEvent();

                imageBox.Source = image.getImage();
            }
        	// TODO: Add event handler implementation here.
        }

        private void imageBox_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int x = (int)e.GetPosition(imageBox).X;
            int y = (int)e.GetPosition(imageBox).Y;
            isMouseDown = true;
            try
            {
                history.beginEvent();
                toolBox.beginEvent(x, y);
                imageBox.Source = image.getImage();
            }
            catch(Exception ex)
            {
            //    MessageBox.Show(ex.Message);
            }
                
            
        	// TODO: Add event handler implementation here.
        }

        private void button_toolBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                button_Brush.IsEnabled = true;
                button_ColorPicker.IsEnabled = true;
                button_Filler.IsEnabled = true;
                button_Eraser.IsEnabled = true;
                button_Shape.IsEnabled = true;
                
                string sender_name = ((Button)sender).Name;
                switch (sender_name)
                {
                    case "button_Brush":
                        toolBox.setTool("Brush");
                        button_Brush.IsEnabled = false;
                        break;
                    case "button_Eraser":
                        toolBox.setTool("Eraser");
                        button_Eraser.IsEnabled = false;
                        break;
                    case "button_Filler":
                        toolBox.setTool("Filler");
                        button_Filler.IsEnabled = false;
                        break;
                    case "button_ColorPicker":
                        toolBox.setTool("Color Picker");
                        button_ColorPicker.IsEnabled = false;
                        break;
                    case "button_Shape":
                        toolBox.setTool("Shape");
                        button_Shape.IsEnabled = false;
                        break;
                }
            }
            catch(Exception ex)
            {
         //       MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_SizeBrush_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var comboBox = sender as ComboBox;
                var str = comboBox.SelectedItem.ToString().Split(' ')[1].Split('p')[0];
                toolBox.setSize(Convert.ToInt32(str));
            }
             catch(Exception ex)
            {
           //     MessageBox.Show(ex.Message);
            }
        }

        private void imageBox_Colors_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int x = (int)e.GetPosition(imageBox_Colors).X;
                int y = (int)e.GetPosition(imageBox_Colors).Y;

                toolBox.setColor(colorArea.image.getColor(x, y));
                //color = colorArea.image.getColor(x, y);
                rectangle_SelectedColor.Fill = new SolidColorBrush(colorArea.image.getColor(x, y));
            }
            catch(Exception ex)
            {

            }
        }


        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                char c = Convert.ToChar(e.Key);
                if (c == 69)//ctrl+z
                {
                    history.Undo(ref image);
                    imageBox.Source = image.getImage();
                }
                if (c == 68)//ctrl+u
                {
                    history.Redo(ref image);
                    imageBox.Source = image.getImage();

                }
                if (c == 62)//ctrl+s
                {
                    menu.Save();
                }
                if (c == 58)//ctrl+o
                {
                    menu.Open();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void Menu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                string str = ((MenuItem)sender).Header.ToString();
                switch (str)
                {
                    case "Save":
                        menu.Save();
                        MessageBox.Show("Saved!");
                        break;
                    case "SaveAs...":
                        menu.Save_As();
                        break;
                    case "New":
                        menu.New();
                        comboBox_SizeBrush.SelectedIndex = 0;
                        break;
                    case "Open":
                        menu.Open();
                        comboBox_SizeBrush.SelectedIndex = 0;
                        break;
                    case "Undo":
                        history.Undo(ref image);
                        imageBox.Source = image.getImage();
                        break;
                    case "Redo":
                        history.Redo(ref image);
                        imageBox.Source = image.getImage();
                        break;
                    case "Exit":
                        this.Close();
                        break;

                }
            }
             catch(Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        
        }

        private void Main_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var res=MessageBox.Show("Save image? ", " ", MessageBoxButton.YesNoCancel);
            if (res == MessageBoxResult.Yes)
                this.menu.Save();
            else if (res == MessageBoxResult.Cancel)
                e.Cancel = true;
            
        }

        

        private void comboBox_ShapeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //toolBox.setTool("Shape");
                var comboBox = sender as ComboBox;
                var str = comboBox.SelectedItem.ToString().Split(' ')[1].Split('p')[0];
                toolBox.setTool(str);
            }
            catch(Exception ex)
            {
                comboBox_ShapeType.SelectedIndex = -1;
               // MessageBox.Show(ex.Message);
            }

        }

        private void Main_Window_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
        //  e.Handled = false;

            // TODO: Add event handler implementation here.
        }



    }
}
