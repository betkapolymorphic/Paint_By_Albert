using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class
{
    class Toolbox
    {
        public Toolbox(Image image)
        {
            choisen_tool = string.Empty;
            this.image = image;
            Tools = new Dictionary<string, ITool>();
        }
        public void addTool(string name,ITool tool)
        {
            Tools.Add(name, tool);
            this.choisen_tool = name;
        }
        public string getChosenTool()
        {
            return this.choisen_tool;
        }
        public void setTool(string name)
        {
            if (!Tools.ContainsKey(name))
                throw new Exception(" toolbox not containe that Tool :(");

            choisen_tool = name;
        }
        public void setImage(Image image)
        {
            this.image = image;
        }
        public void beginEvent(int x, int y)
        {
            
            try
            {
                Tools[choisen_tool].setSize(sizeTool);
            }
            catch
            {
            }
                
            try
            {
                Tools[choisen_tool].setColor(color);
            }
            catch 
            {
            }

            finally
            {
                Tools[choisen_tool].beginEvent(x, y, image);
            }

        }
        public void endEvent(int x, int y)
        {
            Tools[choisen_tool].endEvent(x, y, image);

        }

        
        public void Event(int x, int y)
        {
            Tools[choisen_tool].Event(x, y, image);
        }
        public void setSize(int x)
        {
            this.sizeTool = x;
        }
        public void setColor(Color color)
        {
            this.color = color;
        }
        public ITool getTool(string name)
        {
            if (!Tools.ContainsKey(name))
                throw new Exception(" toolbox not containe that Tool :(");
            return Tools[name];
        }
        public Color getColor()
        {
            return this.color;
        }
        private Image image;
        private string choisen_tool;
        protected Dictionary<string, ITool> Tools;
        private int sizeTool = 1;
        private Color color = Colors.Black;
    }
}
