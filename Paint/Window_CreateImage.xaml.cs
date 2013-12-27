using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Paint
{
    /// <summary>
    /// Interaction logic for Window_CreateImage.xaml
    /// </summary>
    public partial class Window_CreateImage : Window
    {
        public int height = 200;
        public int width = 200;
        public bool isDialogResultConfirm = false;
        public Color color;
        public Window_CreateImage()
        {
            InitializeComponent();
        }

        private void button_create_Click(object sender, RoutedEventArgs e)
        {
            height = Convert.ToInt32(textBox_height.Text);
            width = Convert.ToInt32(textBox_Width.Text);
            color = Colors.White;
            isDialogResultConfirm = true;
            this.Close();
        }
    }
}
