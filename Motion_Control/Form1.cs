using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Motion_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int CircleX = 100;
        public int CircleY = 100;
        public int CircleR = 20;
        int FinX = 20;
        int FinY = 20;
        public int set = 20;

        List<path> Open = new List<path>();
        List<path> Close = new List<path>();
        

        List<Obstacles> SqObst = new List<Obstacles>();


        private double sqr(double a)
        {
            double A = a * a;
            return A;
        }

        private bool cross(double x1, double y1, double x2, double y2, int X1, int Y1, int X2, int Y2)
        {
            if ( X1 == X2)
            {
                if (x1 != x2)
                {
                    if (Y2 > Y1)
                    {
                        int Ytemp = Y2;
                        Y2 = Y1;
                        Y1 = Ytemp;
                    }
                    double Y11 = Y1;
                    double Y22 = Y2;
                    double Y = (y2 - y1) * (X1 - x1) / (x2 - x1) + y1;
                    if (x2 > x1)
                    {
                        double xtemp = x2;
                        x2 = x1;
                        x1 = xtemp;
                    }
                    if (Y <= Y11 && Y >= Y22 && X1>=x2 && X1<=x1)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else
                { return false; }


            }
            else
            {
                if(y1 != y2)
                {
                    if (X2 > X1)
                    {
                        int Xtemp = X2;
                        X2 = X1;
                        X1 = Xtemp;
                    }
                    double X11 = X1;
                    double X22 = X2;
                    double X = (x2 - x1) * (Y1 - y1) / (y2 - y1) + x1;
                    if (y2 > y1)
                    {
                        double ytemp = y2;
                        y2 = y1;
                        y1 = ytemp;
                    }
                    if (X <= X11 && X >= X22 && Y1<=y1 && Y1>=y2)
                    {
                        return true;
                    }
                    else { return false; }

                }
                else { return false; }
            }

        }

        private int[,] MapBuild()
        {
            int width = pictureBox1.Width / set + 1;
            int height = pictureBox1.Height / set + 1;
            int[,] Map = new int[width, height]; 
            for(int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int close = 0;
                    foreach (Obstacles obst in SqObst)
                    {
                        Obstacles NewOb = new Obstacles();

                        NewOb.Xvel = obst.Xvel;
                        NewOb.Yvel = obst.Yvel;
                        NewOb.p1.X = obst.p1.X;
                        NewOb.p2.X = obst.p2.X;
                        NewOb.p3.X = obst.p3.X;
                        NewOb.p4.X = obst.p4.X;
                        NewOb.p1.Y = obst.p1.Y;
                        NewOb.p2.Y = obst.p2.Y;
                        NewOb.p3.Y = obst.p3.Y;
                        NewOb.p4.Y = obst.p4.Y;

                                                
                        if (cross(NewOb.p1.X, NewOb.p1.Y, NewOb.p2.X, NewOb.p2.Y, i*set, j*set, i*set + set,j*set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p2.X, NewOb.p2.Y, NewOb.p3.X, NewOb.p3.Y, i * set, j * set, i * set + set, j * set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p3.X, NewOb.p3.Y, NewOb.p4.X, NewOb.p4.Y, i * set, j * set, i * set + set, j * set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p4.X, NewOb.p4.Y, NewOb.p1.X, NewOb.p1.Y, i * set, j * set, i * set + set, j * set) == true)
                        {
                            close++;
                        }
                        
                        if (cross(NewOb.p1.X, NewOb.p1.Y, NewOb.p2.X, NewOb.p2.Y, i * set + set, j * set, i * set + set, j * set + set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p2.X, NewOb.p2.Y, NewOb.p3.X, NewOb.p3.Y, i * set + set, j * set, i * set + set, j * set + set) == true)
                        {
                            close++;
                        } if (cross(NewOb.p3.X, NewOb.p3.Y, NewOb.p4.X, NewOb.p4.Y, i * set + set, j * set, i * set + set, j * set + set) == true)
                        {
                            close++;
                        } if (cross(NewOb.p4.X, NewOb.p4.Y, NewOb.p1.X, NewOb.p1.Y, i * set + set, j * set, i * set + set, j * set + set) == true)
                        {
                            close++;
                        }

                        if (cross(NewOb.p1.X, NewOb.p1.Y, NewOb.p2.X, NewOb.p2.Y, i * set + set, j * set + set, i * set, j * set + set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p2.X, NewOb.p2.Y, NewOb.p3.X, NewOb.p3.Y, i * set + set, j * set + set, i * set, j * set + set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p3.X, NewOb.p3.Y, NewOb.p4.X, NewOb.p4.Y, i * set + set, j * set + set, i * set, j * set + set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p4.X, NewOb.p4.Y, NewOb.p1.X, NewOb.p1.Y, i * set + set, j * set + set, i * set, j * set + set) == true)
                        {
                            close++;
                        }

                        if (cross(NewOb.p1.X, NewOb.p1.Y, NewOb.p2.X, NewOb.p2.Y, i * set, j * set + set, i * set, j * set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p2.X, NewOb.p2.Y, NewOb.p3.X, NewOb.p3.Y, i * set, j * set + set, i * set, j * set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p3.X, NewOb.p3.Y, NewOb.p4.X, NewOb.p4.Y, i * set, j * set + set, i * set, j * set) == true)
                        {
                            close++;
                        }
                        if (cross(NewOb.p4.X, NewOb.p4.Y, NewOb.p1.X, NewOb.p1.Y, i * set, j * set + set, i * set, j * set) == true)
                        {
                            close++;
                        }
                        
                        
                    }
                    if(close == 0)
                    {
                        Map[i, j] = 1;
                    }
                    else { Map[i, j] = 0; }
                }

            }

            for (int i = 0; i < width; i++ )
            {
                Map[i, 0] = 0;
                Map[i, height - 1] = 0;
            }
            for (int j = 0; j < height; j++)
            {
                Map[0, j] = 0;
                Map[width - 1, j] = 0;
            }
                //1 - ячейка свободна
                //0 - ячейка занята
                return Map;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics ob = pictureBox1.CreateGraphics();
            ob.FillRectangle(Brushes.Green, CircleX, CircleY, set, set);
            ob.FillRectangle(Brushes.Red, FinX*set, FinY*set, set, set);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddRect_Click(object sender, EventArgs e)
        {
            AddRectangle AddRectangles = new AddRectangle();
            if (AddRectangles.ShowDialog() == DialogResult.OK)
            {
                Obstacles NewOb = new Obstacles();

                NewOb.Xvel = Convert.ToInt32(AddRectangles.XVelocity);
                NewOb.Yvel = Convert.ToInt32(AddRectangles.YVelocity);
                NewOb.p1.X = Convert.ToInt32(AddRectangles.X1);
                NewOb.p2.X = Convert.ToInt32(AddRectangles.X2);
                NewOb.p3.X = Convert.ToInt32(AddRectangles.X3);
                NewOb.p4.X = Convert.ToInt32(AddRectangles.X4);
                NewOb.p1.Y = Convert.ToInt32(AddRectangles.Y1);
                NewOb.p2.Y = Convert.ToInt32(AddRectangles.Y2);
                NewOb.p3.Y = Convert.ToInt32(AddRectangles.Y3);
                NewOb.p4.Y = Convert.ToInt32(AddRectangles.Y4);

                SqObst.Add(NewOb);
            }
            else { return; }
        }

        private void DrawObstacles_Click(object sender, EventArgs e)
        {
            Graphics ob = pictureBox1.CreateGraphics();
            
                foreach (Obstacles obst in SqObst)
                {
                    PointF P1 = new PointF(obst.p1.X, obst.p1.Y);
                    PointF P2 = new PointF(obst.p2.X, obst.p2.Y);
                    PointF P3 = new PointF(obst.p3.X, obst.p3.Y);
                    PointF P4 = new PointF(obst.p4.X, obst.p4.Y);
                    PointF[] ArrOb = 
                        {
                            P1,
                            P2,
                            P3,
                            P4,
                            P1
                        };
                    Pen BluePen = new Pen(Color.Blue, 3);
                    ob.DrawPolygon(BluePen, ArrOb);
                }
                System.Threading.Thread.Sleep(100);
                ob.Clear(Color.White);
            
        }

        private void DrawMap_Click(object sender, EventArgs e)
        {
            int width = pictureBox1.Width / set + 1;
            int height = pictureBox1.Height / set + 1;
            Graphics ob = pictureBox1.CreateGraphics();
            
                System.Threading.Thread.Sleep(200);
                ob.Clear(Color.White);
            Pen BlackkPen = new Pen(Color.Black, 1);
                
                    foreach (Obstacles obst in SqObst)
                    {
                        PointF P1 = new PointF(obst.p1.X, obst.p1.Y);
                        PointF P2 = new PointF(obst.p2.X, obst.p2.Y);
                        PointF P3 = new PointF(obst.p3.X, obst.p3.Y);
                        PointF P4 = new PointF(obst.p4.X, obst.p4.Y);
                        PointF[] ArrOb = 
                        {
                            P1,
                            P2,
                            P3,
                            P4,
                            P1
                        };
                        Pen BluePen = new Pen(Color.Blue, 3);
                        ob.DrawPolygon(BluePen, ArrOb);
                    }

                int[,] Map = MapBuild();
                for(int i = 0; i<width; i++)
                {
                    for(int j = 0; j<height; j++)
                    {
                        
                        Rectangle rect = new Rectangle(i * set, j * set, set, set);
                        if (Map[i,j] == 1)
                        {
                            ob.FillRectangle(Brushes.Green, rect);
                        }
                    }
                }
                for (int i = 0; i < width; i++)
                {
                    ob.DrawLine(BlackkPen, i * set, 0, i * set, pictureBox1.Height);
                }
                for (int j = 0; j < width; j++)
                {
                    ob.DrawLine(BlackkPen, 0, j * set, pictureBox1.Width, j * set);
                }
            
        }

        public double h(int x, int y)
        {
            double h = Math.Sqrt((FinX - x) * (FinX - x) + (FinY - y) * (FinY - y));
            return h;
        }

        private path CreateNewPath(path p, int x, int y)
        {
            path NewPath = new path();
            NewPath.x = p.x + x;
            NewPath.y = p.y + y;
            NewPath.Count = p.Count + 1;
            NewPath.lenght = p.lenght + Math.Sqrt(Math.Abs(x)+Math.Abs(y));
            NewPath.h = NewPath.lenght + h(NewPath.x, NewPath.y);
            NewPath.PrevPath = p;
            return NewPath;

        }

        private void AddToOpen(path p)
        {
            Open.Add(p);
        }

        private void AddToClose(path p)
        {
            Close.Add(p);
            for (int i = 0; i < Open.Count; i++)
            {
                if (Open[i].x == p.x && Open[i].y == p.y)
                {
                    Open.RemoveAt(i);
                }
            }

        }
        
        private void AStar_Click(object sender, EventArgs e)
        {
            int width = pictureBox1.Width / set + 1;
            int height = pictureBox1.Height / set + 1;
            path[] PathL = new path[40000 * width * height + 1];
            path TruePath = new path();
            path First = new path();
            First.Count = 0;
            First.lenght = 0;
            First.x = CircleX / set;
            First.y = CircleY / set;
            First.h = h(First.x, First.y);


            int[,] NewMap = new int[width, height];
            NewMap = MapBuild();
            
            PathL[1] = First;

            int cc = 0;

            Open.Clear();
            Close.Clear();
            Open.Add(First);

            Graphics ob = pictureBox1.CreateGraphics();
            ob.Clear(Color.White);

            while (Open.Count != 0)
            {
                cc++;
                List<path> OpenSorted = (from t in Open orderby t.h select t).ToList<path>();
                path CurrentPoint = OpenSorted[0];
                /*
                Rectangle rect = new Rectangle(CurrentPoint.x*set,CurrentPoint.y*set,set,set);
                ob.FillRectangle(Brushes.Green, rect);
                */
                if(CurrentPoint.x==FinX && CurrentPoint.y == FinY)
                {
                    TruePath = CurrentPoint;
                    break;
                }
                for(int i = -1;i<=1;i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i != 0 || j != 0)
                        {
                            path NewP = CreateNewPath(CurrentPoint, i, j);
                            int tempx = NewP.x;
                            int tempy = NewP.y;
                            if (NewMap[NewP.x, NewP.y] == 1)
                            {
                                AddToOpen(NewP);
                            }
                        }
                        
                    }
                }
                AddToClose(CurrentPoint);
                NewMap[CurrentPoint.x, CurrentPoint.y] = 0;
                
            }


            labelLen.Text = (TruePath.lenght*set).ToString();
            labelCount.Text = cc.ToString();
            path[] TrueP = new path[TruePath.Count + 1];
            Point[] PathPoint = new Point[TruePath.Count + 1];
            TrueP[TruePath.Count] = TruePath;
            int error = 0;
            PathPoint[TruePath.Count].X = TruePath.x;
            PathPoint[TruePath.Count].Y = TruePath.y;
            for(int i = TruePath.Count - 1; i>=0; i--)
            {
                TrueP[i] = TrueP[i + 1].PrevPath;
                PathPoint[i].X = TrueP[i].x;
                PathPoint[i].Y = TrueP[i].y;
                if(PathPoint[i].X == CircleX && PathPoint[i].Y == CircleY)
                {
                    error = i;
                    break;
                }
            }





            
            int CurrentX = CircleX;
            int CurrentY = CircleY;
            for (int t = error*set; t < TruePath.Count*set; t++)
            {
                int i = t / set;
                int XMot = PathPoint[i + 1].X - PathPoint[i].X;
                int YMot = PathPoint[i + 1].Y - PathPoint[i].Y;
                ob.FillEllipse(Brushes.Black, CurrentX, CurrentY, CircleR, CircleR);
                CurrentX += XMot;
                CurrentY += YMot;
                foreach (Obstacles obst in SqObst)
                {
                    PointF P1 = new PointF(obst.p1.X, obst.p1.Y);
                    PointF P2 = new PointF(obst.p2.X, obst.p2.Y);
                    PointF P3 = new PointF(obst.p3.X, obst.p3.Y);
                    PointF P4 = new PointF(obst.p4.X, obst.p4.Y);
                    PointF[] ArrOb = 
                        {
                            P1,
                            P2,
                            P3,
                            P4,
                            P1
                        };
                    Pen BluePen = new Pen(Color.Blue, 3);
                    ob.DrawPolygon(BluePen, ArrOb);
                }
                
                //ob.Clear(Color.White);
            }
            
            

        }

        private void Deixtr_Click(object sender, EventArgs e)
        {
            int width = pictureBox1.Width / set + 1;
            int height = pictureBox1.Height / set + 1;
            path[] PathL = new path[40000 * width * height + 1];
            path TruePath = new path();
            path First = new path();
            First.Count = 0;
            First.lenght = 0;
            First.x = CircleX / set;
            First.y = CircleY / set;
            First.h = h(First.x, First.y);


            int[,] NewMap = new int[width, height];
            NewMap = MapBuild();
            
            PathL[1] = First;

            Open.Clear();
            Close.Clear();
            Open.Add(First);

            int cc = 0;
                 

            Graphics ob = pictureBox1.CreateGraphics();
            ob.Clear(Color.White);

            while (Open.Count != 0)
            {
                cc++;
                List<path> OpenSorted = (from t in Open orderby t.lenght select t).ToList<path>();
                path CurrentPoint = OpenSorted[0];
                
                //Rectangle rect = new Rectangle(CurrentPoint.x*set,CurrentPoint.y*set,set,set);
                //ob.FillRectangle(Brushes.Green, rect);
                
                if (CurrentPoint.x == FinX && CurrentPoint.y == FinY)
                {
                    TruePath = CurrentPoint;
                    break;
                }
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i != 0 || j != 0)
                        {
                            path NewP = CreateNewPath(CurrentPoint, i, j);
                            int tempx = NewP.x;
                            int tempy = NewP.y;
                            if (NewMap[NewP.x, NewP.y] == 1)
                            {
                                AddToOpen(NewP);
                            }
                        }

                    }
                }
                AddToClose(CurrentPoint);
                NewMap[CurrentPoint.x, CurrentPoint.y] = 0;

            }

            labelLen.Text = (TruePath.lenght * set).ToString();
            labelCount.Text = cc.ToString();
            path[] TrueP = new path[TruePath.Count + 1];
            Point[] PathPoint = new Point[TruePath.Count + 1];
            TrueP[TruePath.Count] = TruePath;
            int error = 0;
            PathPoint[TruePath.Count].X = TruePath.x;
            PathPoint[TruePath.Count].Y = TruePath.y;
            for (int i = TruePath.Count - 1; i >= 0; i--)
            {
                TrueP[i] = TrueP[i + 1].PrevPath;
                PathPoint[i].X = TrueP[i].x;
                PathPoint[i].Y = TrueP[i].y;
                if (PathPoint[i].X == CircleX && PathPoint[i].Y == CircleY)
                {
                    error = i;
                    break;
                }
            }






            int CurrentX = CircleX;
            int CurrentY = CircleY;
            for (int t = error * set; t < TruePath.Count * set; t++)
            {
                int i = t / set;
                int XMot = PathPoint[i + 1].X - PathPoint[i].X;
                int YMot = PathPoint[i + 1].Y - PathPoint[i].Y;
                ob.FillEllipse(Brushes.Black, CurrentX, CurrentY, CircleR, CircleR);
                CurrentX += XMot;
                CurrentY += YMot;
                foreach (Obstacles obst in SqObst)
                {
                    PointF P1 = new PointF(obst.p1.X, obst.p1.Y);
                    PointF P2 = new PointF(obst.p2.X, obst.p2.Y);
                    PointF P3 = new PointF(obst.p3.X, obst.p3.Y);
                    PointF P4 = new PointF(obst.p4.X, obst.p4.Y);
                    PointF[] ArrOb = 
                        {
                            P1,
                            P2,
                            P3,
                            P4,
                            P1
                        };
                    Pen BluePen = new Pen(Color.Blue, 3);
                    ob.DrawPolygon(BluePen, ArrOb);
                }

                //ob.Clear(Color.White);
            }
        }
    }
}
