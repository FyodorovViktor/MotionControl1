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

        public int CircleX = 5;
        public int CircleY = 5;
        public int CircleR = 20;
        int FinX = 20;
        int FinY = 20;
        double worktime = 0;
        public List<path> TruePP = new List<path>();

        
        public int Pos=0;
        public path[] TrueP;
        
        
        public int set = 20;

        List<path> Open = new List<path>();
        List<path> History = new List<path>();
        List<path> Close = new List<path>();
        List<Check> allpoints = new List<Check>();
        

        private double sqr(double a)
        {
            double A = a * a;
            return A;
        }

        public void DrawObst()
        {
            for (int i = 0; i < allpoints.Count; i++)
            {
                if (allpoints[i].Obst == 1)
                {
                    Graphics temp = pictureBox1.CreateGraphics();
                    temp.DrawEllipse(new Pen(Brushes.Red, 8), allpoints[i].X*set - 4, allpoints[i].Y*set - 4, 8, 8);
                }
            }
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            for (int i = 0; i < allpoints.Count; i++)
            {
                if (Math.Sqrt(Math.Pow((allpoints[i].X * set - x), 2) + Math.Pow((allpoints[i].Y * set - y), 2)) < 5)
                {
                    Graphics temp = pictureBox1.CreateGraphics();
                    temp.DrawEllipse(new Pen(Brushes.Red, 8), allpoints[i].X*set - 4, allpoints[i].Y*set - 4, 8, 8);
                    allpoints[i].Obst = 1;

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void DrawMapp()
        {
            Graphics setka = pictureBox1.CreateGraphics();
            for (int i = 0; i < (pictureBox1.Height / set); i++)
            {
                Pen black = new Pen(Brushes.Black);
                setka.DrawLine(black, 0, i * set, pictureBox1.Width, i * set);
            }
            for (int i = 0; i < (pictureBox1.Width / set); i++)
            {
                Pen black = new Pen(Brushes.Black);
                setka.DrawLine(black, i * set, 0, i * set, pictureBox1.Height);
            }
           
        }

        public void SaF()
        {
            Graphics Begin = pictureBox1.CreateGraphics();
            Begin.FillEllipse(Brushes.Green, CircleX * set - CircleR / 2, CircleY * set - CircleR / 2, CircleR, CircleR);
            Begin.FillEllipse(Brushes.Brown, FinX * set - CircleR/2, FinY * set - CircleR / 2, CircleR, CircleR);
        }

        private void DrawMap_Click(object sender, EventArgs e)
        {
            DrawMapp();
            SaF();
            for (int i = 0; i < (pictureBox1.Height / set); i++)
                for (int j = 0; j < (pictureBox1.Width / set); j++)
                {
                    Check TempC = new Check();
                    TempC.X = j ;
                    TempC.Y = i ;
                    TempC.Obst = 0;
                    allpoints.Add(TempC);
                }
        }

        public double h(int x, int y, int X, int Y)
        {
            double h = Math.Sqrt((X - x) * (X - x) + (Y - y) * (Y - y));
            return h;
        }

        private path CreateNewPath(path p, int x, int y, path S)
        {
            path NewPath = new path();
            NewPath.x = p.x + x;
            NewPath.y = p.y + y;
            NewPath.Count = p.Count + 1;
            NewPath.lenght = p.lenght + Math.Sqrt(Math.Abs(x) + Math.Abs(y));
            NewPath.h = NewPath.lenght + h(NewPath.x, NewPath.y,S.x,S.y );
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

        public int Dist = 0;
        int TDist = 0;
        private int CountDist(path p)
        {
            if (p.PrevPath != null)
            {
                Dist = p.weight + CountDist(p.PrevPath);
                TDist=Dist;
            }
            else
            {
                TDist = Dist;
                Dist = 0;
            }
            return TDist;
        }

        public void drawline(path F1, path F2)
        {
            Graphics Test = pictureBox1.CreateGraphics();
            
            Pen red = new Pen(Brushes.Red,3);
            Test.DrawLine(red, F1.x*set, F1.y*set, F2.x*set, F2.y*set);
        }

        public void draw_polygon(path[] TruePa)
        {
            for(int i = 0; i<TruePa.Length-1;i++)
            {
                drawline(TruePa[i], TruePa[i + 1]);
            }
        }

        private path[] Go_A(path S, path F)
        {
            int width = pictureBox1.Width / set;
            int height = pictureBox1.Height / set;
            path[] PathL = new path[40000 * width * height + 1];
            path TruePath = new path();
            path First = new path();
            First.Count = 0;
            First.lenght = 0;
            First.x = S.x;
            First.y = S.y;
            First.weight = 0;
            First.h = h(First.x, First.y,F.x,F.y);
            PathL[1] = First;
            int cc = 0;
            

            Open.Clear();
            Close.Clear();
            Open.Add(First);

            Graphics ob = pictureBox1.CreateGraphics();
            ob.Clear(Color.White);
            DrawMapp();
            DrawObst();
            SaF();
            
            while (Open.Count != 0)
            {
                cc++;
                List<path> OpenSorted = (from t in Open orderby t.h select t).ToList<path>();
                path CurrentPoint = OpenSorted[0];
                CurrentPoint.weight = 1;
                /*
                Rectangle rect = new Rectangle(CurrentPoint.x*set,CurrentPoint.y*set,set,set);
                ob.FillRectangle(Brushes.Green, rect);
                */
                if (CurrentPoint.x == F.x && CurrentPoint.y == F.y)
                {
                    TruePath = CurrentPoint;
                    
                    History.Add(CurrentPoint);
                    break;
                }
                int kk = 0;
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((i != 0 || j != 0) && i*j==0)
                        {
                            path NewP = CreateNewPath(CurrentPoint, i, j,F);
                            int tempx = NewP.x;
                            int tempy = NewP.y;

                            int test=0;
                            foreach(Check TempCh in allpoints)
                            {
                                test += TempCh.Obst;
                                if(TempCh.X==NewP.x && TempCh.Y == NewP.y)
                                {
                                    kk += TempCh.Obst; 
                                    if(TempCh.Obst == 0)
                                    {
                                        NewP.weight = 1;
                                        AddToOpen(NewP);
                                        History.Add(NewP);
                                        
                                    }
                                }
                            }
                            label3.Text = allpoints.Count.ToString();
                  
                            
                            
                        }

                    }
                }
                AddToClose(CurrentPoint);
            }


            labelLen.Text = (TruePath.lenght * set).ToString();
            labelCount.Text = cc.ToString();
            path[] TrueP1 = new path[TruePath.Count + 1];
            Point[] PathPoint = new Point[TruePath.Count + 1];
            TrueP1[TruePath.Count] = TruePath;
            int error = 0;
            PathPoint[TruePath.Count].X = TruePath.x;
            PathPoint[TruePath.Count].Y = TruePath.y;
            for (int i = TruePath.Count - 1; i >= 0; i--)
            {
                TrueP1[i] = TrueP1[i + 1].PrevPath;
                PathPoint[i].X = TrueP1[i].x;
                PathPoint[i].Y = TrueP1[i].y;
                if (PathPoint[i].X == CircleX && PathPoint[i].Y == CircleY)
                {
                    error = i;
                    break;
                }
            }
            TrueP=TrueP1;
            draw_polygon(TrueP);
            TruePP.Clear();
            path[] newpath = new path[TrueP.Count()];
            for (int m = 0; m < TrueP.Count();m++ )
            {
                newpath[m] = TrueP[TrueP.Count() - m - 1];

                TruePP.Add(TrueP[TrueP.Count() - m - 1]);

            }
                return newpath;

        }

        private path[] Continue_A(path S,path F, int i, int j)
        {

            foreach(path p in History)
            {
                if((p.x == S.x-i) && (p.y == S.y-j))
                {
                    p.weight = 9999999;
                }
            }
            path TruePath;
            List<path> Temp = new List<path>();
            if(i==0)
            {
                for (int k = 0; k < History.Count; k++)
                {
                    if ((History[k].x == S.x - 1 && History[k].y == S.y) || (History[k].x == S.x + 1 && History[k].y == S.y) || (History[k].x == S.x && History[k].y == S.y - j * (-1)))
                    {
                        Temp.Add(History[k]);
                    }
                }
            }
            else
            {
                for (int k = 0; k < History.Count; k++)
                {
                    if ((History[k].x == S.x && History[k].y == S.y - 1) || (History[k].x == S.x && History[k].y == S.y + 1) || (History[k].x == S.x - i * (-1) && History[k].y == S.y))
                    {
                        Temp.Add(History[k]);
                    }
                }
            }


            
            
                foreach(path p in Temp)
                {
                    p.h = CountDist(p);
                }
                List<path> TempSorted = (from t in Temp orderby t.h select t).ToList<path>();


                foreach(path checkp in TempSorted)
                {
                    int xxxxx = checkp.x;
                    int yyyyy = checkp.y;
                    double checkh = checkp.h;
                }
  
                if (TempSorted[0].h < 10000)
                {
                    S.PrevPath = TempSorted[0];
                    TruePath = S;
                    path[] TruePt = new path[TruePath.Count + 1];
                    Point[] PathPoint1 = new Point[TruePath.Count + 1];
                    TruePt[TruePath.Count] = TruePath;
                    int error1 = 0;
                    PathPoint1[TruePath.Count].X = TruePath.x;
                    PathPoint1[TruePath.Count].Y = TruePath.y;
                    for (int l = TruePath.Count - 1; l >= 0; l--)
                    {
                        TruePt[l] = TruePt[l + 1].PrevPath;
                        PathPoint1[l].X = TruePt[l].x;
                        PathPoint1[l].Y = TruePt[l].y;
                        if (PathPoint1[l].X == CircleX && PathPoint1[l].Y == CircleY)
                        {
                            error1 = i;
                            break;
                        }
                    }
                    path[] newpt = new path[TruePt.Count()];
                    for (int m = 0; m < TruePt.Count();m++ )
                    {
                        newpt[m] = TruePt[TruePt.Count() - m - 1];
                    }
                    
                        return newpt;
                }
                else
                {
                    History.Clear();
                    Open.Clear();
                    Close.Clear();
                    return Go_A(F, S);
                }

                
                
        }



        private path NewPath(int x, int y)
            {
                path newPath = new path();
                newPath.weight = 0;
                newPath.x = x;
                newPath.y = y;
                newPath.h = 0;
                newPath.lenght = 0;
            return newPath;
            }

        private void AStar_Click(object sender, EventArgs e)
        {

            TrueP = Go_A(NewPath(FinX, FinY) , NewPath(CircleX, CircleY));

        }

        public void DrawPoint(path t)
        {
            Graphics Begin = pictureBox1.CreateGraphics();
            Begin.FillEllipse(Brushes.Green, t.x*set - CircleR / 2, t.y*set - CircleR / 2, CircleR, CircleR);
        }


        private void Deixtr_Click(object sender, EventArgs e)
        {
            var time1 = DateTime.Now;
            path FINISH = new path();
            FINISH.x = FinX;
            FINISH.y = FinY;
            int Temp = 0;
 


            foreach(Check ch in allpoints)
            {

                if(TruePP[Pos+1].x==ch.X && TruePP[Pos+1].y==ch.Y)
                {
                    if(ch.Obst==1)
                    {
                        Temp++;
                    } 
                }

            }
            path[] newP;
            if (Temp == 0)
            {
                TruePP.RemoveAt(0);
                newP = TruePP.ToArray();
            }
            else
            {

                
                newP = Continue_A(TruePP[0], FINISH, TruePP[0].x - TruePP[1].x, TruePP[0].y - TruePP[1].y);
                TruePP.Clear();
                TruePP = newP.ToList();
            }

            var diffTime = DateTime.Now - time1;
            worktime += diffTime.TotalMilliseconds;
            label3.Text = worktime.ToString();
            Graphics ob = pictureBox1.CreateGraphics();
            ob.Clear(Color.White);
            DrawObst();
            draw_polygon(newP);
            DrawMapp();
            DrawPoint(TruePP[0]);
            DrawPoint(FINISH);
           // path TrueP=Continue_A();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var time1 = DateTime.Now;
            path FINISH = new path();
            FINISH.x = FinX;
            FINISH.y = FinY;
            int Temp = 0;



            foreach (Check ch in allpoints)
            {

                if (TruePP[Pos + 1].x == ch.X && TruePP[Pos + 1].y == ch.Y)
                {
                    if (ch.Obst == 1)
                    {
                        Temp++;
                    }
                }

            }
            path[] newP;
            if (Temp == 0)
            {
                TruePP.RemoveAt(0);
                newP = TruePP.ToArray();
            }
            else
            {


                newP = Go_A(FINISH, TruePP[0]);
                TruePP.Clear();
                TruePP = newP.ToList();
            }

            var diffTime = DateTime.Now - time1;
            worktime += diffTime.TotalMilliseconds;
            label3.Text = worktime.ToString();
            Graphics ob = pictureBox1.CreateGraphics();
            ob.Clear(Color.White);
            DrawObst();
            draw_polygon(newP);
            DrawMapp();
            DrawPoint(TruePP[0]);
            DrawPoint(FINISH);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var time1 = DateTime.Now;
            path FINISH = new path();
            FINISH.x = FinX;
            FINISH.y = FinY;
            int Temp = 0;

            path[] newP;

            TruePP.RemoveAt(0);
            newP = Go_A(FINISH, TruePP[0]);
            TruePP.Clear();
            TruePP = newP.ToList();
            

            var diffTime = DateTime.Now - time1;
            worktime += diffTime.TotalMilliseconds;
            label3.Text = worktime.ToString();
            Graphics ob = pictureBox1.CreateGraphics();
            ob.Clear(Color.White);
            DrawObst();
            draw_polygon(newP);
            DrawMapp();
            DrawPoint(TruePP[0]);
            DrawPoint(FINISH);
        }

   
    }
}
