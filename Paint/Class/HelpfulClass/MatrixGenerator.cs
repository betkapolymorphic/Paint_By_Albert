using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Class.HelpfulClass
{                            
    //for (int i = 0; i < h; i++)
    //    for (int j = 0; j < w; j++)
    //        matrix[i, j] = true;

    //for (int i = 0; i < 3; i++)
    //    matrix[0, i] = false;
    //for (int i = 0; i < 3; i++)
    //    matrix[0, i+5] = false;
    //for (int i = 0; i < 3; i++)
    //    matrix[7, i] = false;
    //for (int i = 0; i < 3; i++)
    //    matrix[7, i + 5] = false;

    //matrix[1, 0] = false;
    //matrix[1, 7] = false;
    //matrix[6, 0] = false;
    //matrix[6, 7] = false;
    static class MatrixGenerator
    {
        public static  bool[,] generate(string name,int radius)
        {
           
            bool[,] matrix = new bool[radius, radius];
            for(int i=0;i<radius;i++)
                for(int j=0;j<radius;j++)
                    matrix[i,j]=false;
            switch(name)
            {
                case "rectangle":
                case "rect":
                    {

                        for(int i=0;i<radius;i++)
                        {
                            matrix[0, i] = true;
                            matrix[radius-1, i]=true;
                        }
                        for (int i = 0; i < radius; i++)
                        {
                            matrix[i, 0] = true;
                            matrix[i, radius-1] = true;
                        }
                    }
                    break;
                case "Diamond":
                case "diamond":
                    {
                        int y1=radius/2;
                        int y2=radius/2;
                        for(int x=0;x<radius/2 && y1 < radius && y2 >=0;x++)
                        {
                            matrix[y1++, x] = true;
                            matrix[y2--, x] = true;
                        }
                        
                        for (int x = radius/2; x < radius ; x++)
                        {
                            matrix[y1--, x] = true;
                            matrix[y2++, x] = true;
                        }
                    }
                    break;
                case "Circle":
                case "circle":
                    {
                        if (radius == 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {

                                matrix[1, i] = true;
                                matrix[i, 1] = true;
                            }
                        }
                        if (radius == 5 || radius==8 )
                        {
                            for (int i = 0; i < radius; i++)
                            for (int j = 0; j < radius; j++)
                                matrix[i, j] = true;
                            int yupi = radius / 2;
                            int margin = (radius - yupi) / 2;

                            for(int y=0;y<radius;y++)
                            {
                                if (y == (radius - yupi) / 2)
                                    y += yupi;
                                if (y >= (radius - yupi) / 2)
                                {
                                    margin++;
                                }
                                for(int x=0;x<radius;x++)
                                {
                                    if (x == margin)
                                        x += yupi + ((radius - yupi) / 2 - margin) + 1;
                                    matrix[y, x] = false;
                                   
                                }
                                margin--;
                                
                            }

                        }
                        else 
                            return generate("rect", 8);
                    }
                    break;
                default:
                    throw new Exception("bad name of matrix!\n");
            }

            return matrix;
        }
    }
}
