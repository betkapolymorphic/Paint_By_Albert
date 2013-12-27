using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint.Class
{
    public class History
    {

        public History(int max_saved_info,int heightPicture)
        {
            this.maxSavedInfo = max_saved_info;

            this.height = heightPicture;

            UndoSet = new Queue<HelpfulClass.X_Y_Set>();
            //UndoSet.Enqueue(new HelpfulClass.X_Y_Set(heightPicture));

            RedoSet = new Queue<HelpfulClass.X_Y_Set>();
            //RedoSet.Enqueue(new HelpfulClass.X_Y_Set(heightPicture));
            this.count = 0;
        }
        public void recreate(int max_saved_info,int heightPicture)
        {
            this.maxSavedInfo = max_saved_info;

            this.height = heightPicture;

            UndoSet = new Queue<HelpfulClass.X_Y_Set>();
            UndoSet.Enqueue(new HelpfulClass.X_Y_Set(heightPicture));

        }
        public void beginEvent()
        {
            if (count < maxSavedInfo - 1)
            {
                
                UndoSet.Enqueue(new HelpfulClass.X_Y_Set(height));
                RedoSet.Enqueue(new HelpfulClass.X_Y_Set(height));
                
            }
            else
            {
                UndoSet.Dequeue();
                UndoSet.Enqueue(new HelpfulClass.X_Y_Set(height));
                RedoSet.Dequeue();
                RedoSet.Enqueue(new HelpfulClass.X_Y_Set(height));

            }
           UndoSet.ElementAt(count).clear();
           RedoSet.ElementAt(count).clear();
        }
        public void endEvent()
        {
            count++;
            used = count;
        }
        public void addEvent(int x, int y, Color oldColor, Color newColor)
        {
            //if(count==1)
            //if(count==1)
            UndoSet.ElementAt(count).add(x, y, oldColor);
            RedoSet.ElementAt(count).add(x, y, newColor);
        }
        public bool Undo(ref Image im)
        {
            if(count<=0)
                return false;
            count--;
            foreach (var i in UndoSet.ElementAt(count))
            {
                HelpfulClass.X_Y_Set.x_y_color tmp = i as HelpfulClass.X_Y_Set.x_y_color;
                im.setPixel(tmp.x, tmp.y, tmp.c);
            }
            
            return true;
        }
        public void Redo(ref Image image)
        {
            if(count < maxSavedInfo - 1 && count < used)
            {

                
                foreach (var i in RedoSet.ElementAt(count))
                {
                    HelpfulClass.X_Y_Set.x_y_color tmp = i as HelpfulClass.X_Y_Set.x_y_color;
                    image.setPixel(tmp.x, tmp.y, tmp.c);
                }
                count++;
            }
        }
        public HelpfulClass.X_Y_Set getLastSet()
        {
            return this.UndoSet.ElementAt(UndoSet.Count - 1);          
        }
        public int getSize()
        {
            return this.UndoSet.ElementAt(count).getSize();
        }
        
        Queue<HelpfulClass.X_Y_Set> UndoSet;
        Queue<HelpfulClass.X_Y_Set> RedoSet;
        int maxSavedInfo=0;
        int count = 0;
        int used = 0;
        int height;

        
    }
}
