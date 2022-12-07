using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Graph
{
    public partial class Form1 : Form
    {
        public List<MyGraph> listUndoRedo;
        MyGraph graph;
        string MoveNodeName = null;
        string NodeName = null;
        string StartNode = null;
        int EdgeNumber = -1;
        //string EndNode = null;
        int BezieMarkerNumber = -1;
        bool BezieEdit = false;
        int UndoRedoNumber = 0;
        public Form1()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).SetValue(panel1, true, null);
            graph = new MyGraph();
            listUndoRedo = new List<MyGraph>();
            SaveToUndoRedo();
        //graph.ListVertex.Add(new Vertex("1", 100, 20));
        //graph.ListVertex.Add(new Vertex("2", 210, 60));
        //graph.ListVertex.Add(new Vertex("3", 40, 120));
        //graph.ListVertex.Add(new Vertex("4", 50, 320));
        //graph.ListEdge.Add(new Edge(1, 2, 3, 10, true));
        //graph.ListEdge.Add(new Edge(2, 2, 1, 10, true));
        //graph.ListEdge.Add(new Edge(3, 1, 3, 10, true));
    }


        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ОткрытьГрафToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String[] array = openFileDialog1.FileName.Split('.');
                //проверка на тип файла
                if (array[array.Length-1] == "gsm" ) graph.ReadGraphFromFileConnectivMatrix(openFileDialog1.FileName, panel1.Width, panel1.Height);
                else if (array[array.Length - 1] == "gin") graph.ReadGraphFromFileIncendMatrix(openFileDialog1.FileName, panel1.Width, panel1.Height);
                else if (array[array.Length - 1] == "grb") graph.ReadGraphFromFileListEdge(openFileDialog1.FileName, panel1.Width, panel1.Height);
                // int a = 10;
                panel1.Invalidate();
            }
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm form1 = new AboutProgramForm();
            form1.ShowDialog();
        }

        private void ОбАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutAutorForm form1 = new AboutAutorForm();
            form1.ShowDialog();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            graph.Draw(g);
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            TurnOffAllButtons();
            toolStripButtonCreateNode.Checked = true;
        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (toolStripButtonCreateNode.Checked)
                {
                    graph.AddVertexNotName(e.X, e.Y);
                    SaveToUndoRedo();
                    panel1.Invalidate();
                }
                else if (toolStripButtonRemove.Checked)
                {
                    graph.RemoveNodeByXY(e.X, e.Y);
                    panel1.Invalidate();
                }
                else if (toolStripButtonCreateEdges.Checked)
                {
                    String node = graph.GetNodeNameByXY(e.X, e.Y);
                    if (node != null)
                    {
                        if (StartNode == null) StartNode = node;
                        else
                        {
                            graph.ListEdge.Add(new Edge(graph.FreeEdgeNumber(), StartNode, node, 1, true));
                            graph.UpdateBezierPointsFromLineEdge(graph.ListEdge.Count-1);
                            StartNode = null;
                            panel1.Invalidate();
                        }
                    }
                }
            }
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            TurnOffAllButtons();
            toolStripButtonRemove.Checked = true;

        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (graph.SelectNodeByXY(e.X, e.Y)) panel1.Invalidate();
            else if (MoveNodeName != null)
            {
                Vertex node = graph.GetVertexByName(MoveNodeName);
                node.x = e.X;
                node.y = e.Y;

            }
            if (BezieMarkerNumber != -1)
            {
                graph.ListEdge[EdgeNumber].bezierPoints[BezieMarkerNumber].X = e.X;
                graph.ListEdge[EdgeNumber].bezierPoints[BezieMarkerNumber].Y = e.Y;
                panel1.Invalidate();
            }
        }



        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (toolStripButtonMouse.Checked) MoveNodeName = graph.GetNodeNameByXY(e.X, e.Y);
                if (BezieEdit)
                {
                   int i = graph.GetMarkerNumberByXY(EdgeNumber, e.X, e.Y);
                    if (i != -1)
                    {
                        BezieMarkerNumber = i;
                       // MessageBox.Show("+");
                    }
                }
           
            }
            else if (e.Button == MouseButtons.Right)
            {
                NodeName = graph.GetNodeNameByXY(e.X, e.Y);
                if (NodeName != null) contextMenuStripNode.Show(panel1, e.X, e.Y);
                else
                {
                    EdgeNumber = graph.GetEdgeNumberByXY(e.X, e.Y);
                    if (EdgeNumber != -1) contextMenuStripEdge.Show(panel1, e.X, e.Y);
                }
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MoveNodeName != null) MoveNodeName = null;
                if (BezieMarkerNumber != -1) BezieMarkerNumber = -1;
            }

        }
        void TurnOffAllButtons()
        {
            toolStripButtonMouse.Checked = false;
            toolStripButtonCreateNode.Checked = false;
            toolStripButtonRemove.Checked = false;
            toolStripButtonCreateEdges.Checked = false;
            
        }

        private void ToolStripButtonMouse_Click(object sender, EventArgs e)
        {
            TurnOffAllButtons();
            toolStripButtonMouse.Checked = true;
        }

        private void ПереименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRenameNode form = new FormRenameNode(NodeName);
            form.ShowDialog();
            if (!graph.RenameNode(NodeName, form.NodeName)) MessageBox.Show("Невозможно переименовать, так как вершина с именем " + form.NodeName + " существует!", "Ошибка переименования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else panel1.Invalidate();
        }

       

        private void ToolStripButtonCreateEdges_Click(object sender, EventArgs e)
        {
            TurnOffAllButtons();
            toolStripButtonCreateEdges.Checked = true;
  
        }

        private void ContextMenuStripNode_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ToolStripButtonBez_Click(object sender, EventArgs e)
        {
            TurnOffAllButtons();
            
        }

        private void ИзменитьФормуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.EditEdge = true;
            graph.EditEdgeNumber = EdgeNumber;
            BezieEdit = true;
            panel1.Invalidate();
        }

        private void ContextMenuStripEdge_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ОтключитьРедактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.EditEdge = false;
            graph.EditEdgeNumber = -1;
            BezieEdit = false;
            panel1.Invalidate();
        }

        private void СвойстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdgeForm formedge = new EdgeForm(graph.ListEdge[EdgeNumber], graph);
            formedge.ShowDialog();
            panel1.Invalidate();
        }

        private void УдалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.ListEdge.RemoveAt(EdgeNumber);
            panel1.Invalidate();

        }

        private void ToolStripButtonUndo_Click(object sender, EventArgs e)
        {
            
            if (UndoRedoNumber >= 2)
            {
                UndoRedoNumber--;
                graph = listUndoRedo[UndoRedoNumber - 1].Copy();
                panel1.Invalidate();
            }
        }

        private void ToolStripButtonRedo_Click(object sender, EventArgs e)
        {
            
            if (UndoRedoNumber <= listUndoRedo.Count-1)
            {
                UndoRedoNumber++;
                graph = listUndoRedo[UndoRedoNumber - 1].Copy();
                panel1.Invalidate();
            }
        }

        public void SaveToUndoRedo()
        {
          listUndoRedo.Add(graph.Copy());
            UndoRedoNumber = listUndoRedo.Count;
        }
    }

    public class Edge
    {
        public int id; //Номер ребра
        public double a; //вес
        public string StartVertexName;
        public string EndVertexName;
        public bool Orientation;
        
        PointF start = new PointF(100.0F, 100.0F);
        PointF control1 = new PointF(200.0F, 10.0F);
        PointF control2 = new PointF(350.0F, 50.0F);
        PointF end1 = new PointF(500.0F, 100.0F);
        PointF control3 = new PointF(600.0F, 150.0F);
        PointF control4 = new PointF(650.0F, 250.0F);
        PointF end2 = new PointF(500.0F, 300.0F);
        
        public PointF[] bezierPoints;
        public Edge(int id, string StartVertexName, string EndVertexName, double a, bool Orientation)
        {
            this.id = id;
            this.StartVertexName = StartVertexName;
            this.EndVertexName = EndVertexName;
            this.a = a;
            this.Orientation = Orientation;
            bezierPoints = new PointF[7];
            //PointF[] bezierPoints2 = { start, control1, control2, end1, control3, control4, end2 };
            
            //for (int i = 0; i < bezierPoints.Length; i++)
            //{
            //    bezierPoints[i] = bezierPoints2[i];
            //}

        }
        
    }


    public class Vertex
    {
        public string Name; //номер вершины
        public int x, y;
        public bool Selected = false; //выделение
        public Vertex(string Name, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Name = Name;
        }
    }
   public class MyGraph
    {
        public List<Vertex> ListVertex;
        public List<Edge> ListEdge;
        int R = 7;
        int SelectedVertexNumber = -1;
        int R2 = 10; //размер маркера Кривой Безье
        public bool EditEdge = false;
        public int EditEdgeNumber;
        public MyGraph()
        {
            ListVertex = new List<Vertex>();
            ListEdge = new List<Edge>();
        }
        public MyGraph Copy()
        {
            MyGraph mygraph = new MyGraph();
            mygraph.R = R;
            mygraph.SelectedVertexNumber = SelectedVertexNumber;
            mygraph.R2 = R2;
            mygraph.EditEdge = EditEdge;
            mygraph.EditEdgeNumber = EditEdgeNumber;
            for (int i = 0; i < ListVertex.Count; i++)
            {
                mygraph.ListVertex.Add(ListVertex[i]);

            }
            for (int i = 0; i < ListEdge.Count; i++)
            {
                mygraph.ListEdge.Add(ListEdge[i]);

            }
            return mygraph;
        }

        public void Draw(Graphics g)
        {
            Brush brush;
            Brush brushBlack = new SolidBrush(Color.Black);
            Brush brushYellow = new SolidBrush(Color.Yellow);
            Pen pen = new Pen(Color.Blue);
        
            for (int i = 0; i < ListEdge.Count; i++)
            {
                //Vertex vertex =  GetVertexByName(ListEdge[i].StartVertexName);
                //Vertex endvertex = GetVertexByName(ListEdge[i].EndVertexName);
                //g.DrawLine(pen, vertex.x, vertex.y, endvertex.x, endvertex.y);
                if(i == EditEdgeNumber) DrawEdge(g, i, EditEdge);
                else DrawEdge(g, i, false);

            }
            for (int i = 0; i < ListVertex.Count; i++)
            {
                if (ListVertex[i].Selected) brush = brushYellow;
                else brush = brushBlack;
                g.FillEllipse(brush, ListVertex[i].x - R, ListVertex[i].y - R, 2*R, 2 * R);
                Font font = new Font("Arial", 12, FontStyle.Regular);
                g.DrawString(ListVertex[i].Name, font, Brushes.Black, ListVertex[i].x + R, ListVertex[i].y - (int)(3 * R)); ;

            }


            


        }
        public Vertex GetVertexByName(string Name)
        {
            for (int i = 0; i < ListVertex.Count; i++)
            {
                if (ListVertex[i].Name == Name) return ListVertex[i];

            }
            return null;
        }

        public void ReadGraphFromFileConnectivMatrix(string filename, int width, int height) //Матрица смежности
        {
            ListEdge.Clear();
            ListVertex.Clear();
            StreamReader fin = new StreamReader(filename);
            int EdgeId = 0;
            int StartVertexId = 0;
            //string s2 = fin.ReadLine();
            //int F = Int32.Parse("52");
            //int N = Int32.Parse(fin.ReadLine());
            int K = 0;
            int N = -1;
            int ReadVertex = -1;

            while (!fin.EndOfStream)
            {
                String s = fin.ReadLine();
                s = NotComment(s);
                if (s.Length == 0) continue;
                if (N == -1)
                {
                    N = Int32.Parse(s);
                    continue;
                }
                if (ReadVertex == -1)
                {
                    ReadVertex = Int32.Parse(s);
                    if (ReadVertex == 0)
                    {
                        Random r = new Random();
                        for (int i = 1; i <= N; i++)
                        {
                            string name = i.ToString();
                            int x = r.Next(50, width - 50); // от 10 до 400
                            int y = r.Next(50, height - 50);
                            ListVertex.Add(new Vertex(name, x, y));
                        }
                    }
                    continue;
                }
                K++;
                if ((ReadVertex == 1) && (K <= N))
                {
                        String[] array = s.Split(' ');
                        string name = array[0];
                        int x = Int32.Parse(array[1]);
                        int y = Int32.Parse(array[2]);
                        ListVertex.Add(new Vertex(name, x, y));
                }
                else
                {
                    String[] array = s.Split(' ');
                    if (N == -1) N = array.Length;
                    for (int i = 0; i < array.Length; i++)
                    {
                        double a = double.Parse(array[i]);
                        if (a != 0)
                        {
                            ListEdge.Add(new Edge(EdgeId++, ListVertex[StartVertexId].Name, ListVertex[i].Name, a, true));
                            //UpdateBezierPointsFromLineEdge(ListEdge.Count - 1);
                        }

                    }
                    StartVertexId++;
                }
               
            
            }
            fin.Close();
            for (int i = 0; i < ListEdge.Count; i++)
            {
                UpdateBezierPointsFromLineEdge(i);
            }
        }

        public void ReadGraphFromFileListEdge(string filename, int width, int height) //Cписок рёбер
        {
            Random r = new Random();
            ListEdge.Clear();
            ListVertex.Clear();
            StreamReader fin = new StreamReader(filename);
            int EdgeId = 0;
            int StartVertexId = 0;
            int K = 0;
            int N = -1;
            int ReadVertex = -1;

            while (!fin.EndOfStream)
            {
                String s = fin.ReadLine();
                s = NotComment(s);
                if (s.Length == 0) continue;
                if (N == -1)
                {
                    N = Int32.Parse(s);
                    continue;
                }
                if (ReadVertex == -1)
                {
                    ReadVertex = Int32.Parse(s);
                    //if (ReadVertex == 0)
                    //{
                    //    Random r = new Random();
                    //    for (int i = 1; i <= N; i++)
                    //    {
                    //        string name = i.ToString();
                    //        int x = r.Next(50, width - 50); // от 10 до 400
                    //        int y = r.Next(50, height - 50);
                    //        ListVertex.Add(new Vertex(name, x, y));
                    //    }
                    //}
                    continue;
                }
                K++;
                if ((ReadVertex == 1) && (K <= N))
                {
                    String[] array = s.Split(' ');
                    string name = array[0];
                    int x = Int32.Parse(array[1]);
                    int y = Int32.Parse(array[2]);
                    ListVertex.Add(new Vertex(name, x, y));
                }
                else
                {
                    String[] array = s.Split(' ');
                    int id = Int32.Parse(array[0]);
                    double value = double.Parse(array[1]);
                    string StartVertexName = array[2];
                    string EndVertexName = array[3];
                    bool orientation = Int32.Parse(array[4]) == 1 ? true : false;
                    ListEdge.Add(new Edge(id, StartVertexName, EndVertexName, value, orientation));
                    
                    if (ReadVertex == 0)
                    {
                        if (GetVertexByName(StartVertexName) == null)
                        {
                           
                            int x = r.Next(50, width - 50); // от 10 до 400
                            int y = r.Next(50, height - 50);
                            ListVertex.Add(new Vertex(StartVertexName, x, y));
                        }
                        if (GetVertexByName(EndVertexName) == null)
                        {
                            int x = r.Next(50, width - 50); // от 10 до 400
                            int y = r.Next(50, height - 50);
                            ListVertex.Add(new Vertex(EndVertexName, x, y));
                        }
                    }                   

                    StartVertexId++;
                 }


            }
            fin.Close();
            for (int i = 0; i < ListEdge.Count; i++)
            {
                UpdateBezierPointsFromLineEdge(i);
            }
        }

        public void ReadGraphFromFileIncendMatrix(string filename, int width, int height) //Cписок рёбер
        {
            ListEdge.Clear();
            ListVertex.Clear();
            StreamReader fin = new StreamReader(filename);
            int EdgeId = 0;
            int StartVertexId = 0;
            //string s2 = fin.ReadLine();
            //int F = Int32.Parse("52");
            //int N = Int32.Parse(fin.ReadLine());
            int K = 0;
            int N = -1;
            int ReadVertex = -1;

            while (!fin.EndOfStream)
            {
                String s = fin.ReadLine();
                s = NotComment(s);
                if (s.Length == 0) continue;
                if (N == -1)
                {
                    N = Int32.Parse(s);
                    continue;
                }
                if (ReadVertex == -1)
                {
                    ReadVertex = Int32.Parse(s);
                    if (ReadVertex == 0)
                    {
                        Random r = new Random();
                        for (int i = 1; i <= N; i++)
                        {
                            string name = i.ToString();
                            int x = r.Next(50, width - 50); // от 10 до 400
                            int y = r.Next(50, height - 50);
                            ListVertex.Add(new Vertex(name, x, y));
                        }
                    }
                    continue;
                }
                K++;
                if ((ReadVertex == 1) && (K <= N))
                {
                    String[] array = s.Split(' ');
                    string name = array[0];
                    int x = Int32.Parse(array[1]);
                    int y = Int32.Parse(array[2]);
                    ListVertex.Add(new Vertex(name, x, y));
                }
                else
                {
                    String[] array = s.Split(' ');
                    if (N == -1) N = array.Length;
                    for (int i = 0; i < array.Length; i++)
                    {
                        double a = double.Parse(array[i]);
                        if (a != 0) ListEdge.Add(new Edge(EdgeId++, ListVertex[StartVertexId].Name, ListVertex[i].Name, a, true));
                    }
                    StartVertexId++;
                }


            }
            fin.Close();
        }

        public string NotComment(string s) //Возвращает строку, отбрасывая символы после %
        {
            int index = s.IndexOf("%"); //в строке s найдёт номер процента
            if (index >= 0) s = s.Substring(0, index); // возвратит строку от 0 до индекса
            return s;
        }

        public void AddVertexNotName(int x, int y) //добавляет вершину с координатами xy и автоматически вставляет номер вершины
        {
            for (int i = 1; ; i++)
            {
                if (GetVertexByName(i.ToString()) == null)
                {
                    ListVertex.Add(new Vertex(i.ToString(), x, y));
                    break;
                }

            }
           
        }

        public void RemoveNodeByXY(int x, int y) //Удаляет вершину, если в неё попадает указатель мыши
        {
            for(int i = 0; i < ListVertex.Count; i++)
            {
                if (IsPointInCircle(ListVertex[i].x, ListVertex[i].y, R, x, y))
                {
                    RemoveAllEdgesByNodeName(ListVertex[i].Name);
                    RemoveAllEdgesByNodeName(ListVertex[i].Name); //ошибка с удалением рёбер
                    ListVertex.RemoveAt(i);
                    break;
                }
            }

        }

        public bool IsPointInCircle(double xCircle, double yCircle, int R, int x, int y)
        {
            double dX = xCircle - x;
            double dY = yCircle - y;
            double d = Math.Sqrt(dX *dX + dY * dY);
            if (R >= d) return true;
            else return false;
        }

        public void RemoveAllEdgesByNodeName(string name) //удалить все, связанные с вершиной name, рёбра
        {
            for (int i = 0; i < ListEdge.Count; i++)
            {
                if ((ListEdge[i].StartVertexName == name) || (ListEdge[i].EndVertexName == name)) ListEdge.RemoveAt(i);
            }
            int a = ListEdge.Count;
        }

        public bool SelectNodeByXY(int x, int y)
        {
            bool f = false;
            for (int i = 0; i < ListVertex.Count; i++ )
            {
                ListVertex[i].Selected = false;
                if (IsPointInCircle(ListVertex[i].x, ListVertex[i].y, R, x, y))
                {
                    ListVertex[i].Selected = true;
                    SelectedVertexNumber = i;
                    f = true;
                }
                 
                
            }
            if ((!f) && (SelectedVertexNumber != -1))
            {
                SelectedVertexNumber = -1;
                return true;
            }
            return f;
        }

        public string GetNodeNameByXY(int x, int y)
        {
            for (int i = 0; i < ListVertex.Count; i++)
            {
                if (IsPointInCircle(ListVertex[i].x, ListVertex[i].y, R, x, y))
                return ListVertex[i].Name;
            }
            return null;
        }

        public bool RenameNode(string OldName, string NewName)
        {
            Vertex node = GetVertexByName(OldName);
            if (node == null) return false;
            if (GetVertexByName(NewName) == null)
            {
                for (int i = 0; i < ListEdge.Count; i++)
                {
                    if (ListEdge[i].StartVertexName == OldName) ListEdge[i].StartVertexName = NewName;
                    if (ListEdge[i].EndVertexName == OldName) ListEdge[i].EndVertexName = NewName;
                }
                node.Name = NewName;
                return true;
            }
            return false;

        }

        public Edge GetEdgeById(int id)
        {
            for (int i = 0; i < ListEdge.Count; i++)
            {
                if (ListEdge[i].id == id) return ListEdge[i];
            }
            return null;
        }

        public int FreeEdgeNumber()  //возвращает номер свободного ребра
        {
            for (int i = 0; i < ListEdge.Count+1; i++)
            {
                if (GetEdgeById(i) == null) return i;
            }
            return 0;
        }
        public void SetStartEndBezierPoint(int id)
        {
           // bezierPoints[0]
        }

        public void DrawEdge(Graphics g, int number, bool DrawMarker = true)
        {
            //В массиве точек Безье обновляем начальную и конечную точку
            Vertex vertex = GetVertexByName(ListEdge[number].StartVertexName);
            Vertex endvertex = GetVertexByName(ListEdge[number].EndVertexName);
            ListEdge[number].bezierPoints[0].X = vertex.x;
            ListEdge[number].bezierPoints[0].Y = vertex.y;
            int count = ListEdge[number].bezierPoints.Length;
            ListEdge[number].bezierPoints[count-1].X = endvertex.x;
            ListEdge[number].bezierPoints[count-1].Y = endvertex.y;

            Brush brushYellow = new SolidBrush(Color.Yellow);
            Brush brushGreen = new SolidBrush(Color.Green);
            Pen blackPen = new Pen(Color.Blue, 2);

            Pen GreyPen = new Pen(Color.Gray, 1);

            g.DrawBeziers(blackPen, ListEdge[number].bezierPoints);
            if (DrawMarker)
            {
                g.DrawLine(GreyPen, vertex.x, vertex.y, ListEdge[number].bezierPoints[1].X, ListEdge[number].bezierPoints[1].Y);
                g.DrawLine(GreyPen, ListEdge[number].bezierPoints[2].X, ListEdge[number].bezierPoints[2].Y, ListEdge[number].bezierPoints[3].X, ListEdge[number].bezierPoints[3].Y);
                g.DrawLine(GreyPen, ListEdge[number].bezierPoints[3].X, ListEdge[number].bezierPoints[3].Y, ListEdge[number].bezierPoints[4].X, ListEdge[number].bezierPoints[4].Y);
                g.DrawLine(GreyPen, endvertex.x, endvertex.y, ListEdge[number].bezierPoints[5].X, ListEdge[number].bezierPoints[5].Y);
                for (int i = 0; i < ListEdge[number].bezierPoints.Length; i++)
                {
                    g.FillEllipse(brushYellow, ListEdge[number].bezierPoints[i].X - R2 / 2, ListEdge[number].bezierPoints[i].Y - R2 / 2, R2, R2);
                }
            }
            //else
            //{
            g.FillEllipse(brushGreen, ListEdge[number].bezierPoints[3].X - R2 / 2, ListEdge[number].bezierPoints[3].Y - R2 / 2, R2, R2);
            Font font = new Font("Arial", 12, FontStyle.Regular);
            g.DrawString(ListEdge[number].a.ToString(), font, Brushes.Black, ListEdge[number].bezierPoints[3].X - R2 / 2, ListEdge[number].bezierPoints[3].Y - R2 / 2 + 20) ;
            //}
            if (ListEdge[number].Orientation)
            {
                double alpha;
                GetLineAlpha(ListEdge[number].bezierPoints[count-1].X, ListEdge[number].bezierPoints[count - 1].Y, ListEdge[number].bezierPoints[count - 2].X, ListEdge[number].bezierPoints[count - 2].Y, out alpha);
                float dx = (float)(R * Math.Cos(alpha));
                float dy = (float)(R * Math.Sin(alpha));
                float x = ListEdge[number].bezierPoints[count - 1].X + dx;
                float y = ListEdge[number].bezierPoints[count - 1].Y + dy;
                //g.FillEllipse(brushYellow, (float)(x - 5), (float)(y - 5), R2, R2);
                float dx2 = (float)(2 * R * Math.Cos(alpha));
                float dy2 = (float)(2 * R * Math.Sin(alpha));
                float x2 = ListEdge[number].bezierPoints[count - 1].X + dx2;
                float y2 = ListEdge[number].bezierPoints[count - 1].Y + dy2;
                Pen pen = new Pen(Color.Blue, 8);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                g.DrawLine(pen, x2, y2, x, y);
            }

        }
        public int GetMarkerNumberByXY(int EdgeNumber, int x, int y)
        {
            for (int i = 1; i < ListEdge[EdgeNumber].bezierPoints.Length-1; i++)
            {
               if (IsPointInCircle(ListEdge[EdgeNumber].bezierPoints[i].X, ListEdge[EdgeNumber].bezierPoints[i].Y, R2, x, y))
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateBezierPointsFromLineEdge(int edgenumber)
        {
            Vertex vertex = GetVertexByName(ListEdge[edgenumber].StartVertexName);
            Vertex endvertex = GetVertexByName(ListEdge[edgenumber].EndVertexName);
            if (vertex.Name != endvertex.Name)
            { 
                double dx = (endvertex.x - vertex.x) / 6; // делим на 6 частей ребро
                double dy = (endvertex.y - vertex.y) / 6;
                for (int i = 1; i <= 5; i++)
                {
                ListEdge[edgenumber].bezierPoints[i].X = (int)(vertex.x + i * dx);
                ListEdge[edgenumber].bezierPoints[i].Y = (int)(vertex.y + i * dy);
                }
            }
            else
            {
                ListEdge[edgenumber].bezierPoints[1].X = vertex.x - 60;
                ListEdge[edgenumber].bezierPoints[1].Y = vertex.y + 8;
                ListEdge[edgenumber].bezierPoints[2].X = vertex.x - 54;
                ListEdge[edgenumber].bezierPoints[2].Y = vertex.y + 45;
                ListEdge[edgenumber].bezierPoints[3].X = vertex.x + 2;
                ListEdge[edgenumber].bezierPoints[3].Y = vertex.y + 54;
                ListEdge[edgenumber].bezierPoints[4].X = vertex.x + 61;
                ListEdge[edgenumber].bezierPoints[4].Y = vertex.y + 44;
                ListEdge[edgenumber].bezierPoints[5].X = vertex.x + 54;
                ListEdge[edgenumber].bezierPoints[5].Y = vertex.y - 3;
            }
            /*
             0, 0
    -60, 8
    -54, 45
    2, 54
    61, 44
    54, -3
    0, 0

             */
        }

        public int GetEdgeNumberByXY (int x, int y)
        {
        
          for (int i = 0; i < ListEdge.Count; i++)
             {
                if (IsPointInCircle(ListEdge[i].bezierPoints[3].X, ListEdge[i].bezierPoints[3].Y, R2, x, y))
                return i;
              }
         return -1;
          
        }

        public void GetLineAlpha (double x1, double y1, double x2, double y2, out double alpha)
        {
           alpha = Math.Atan2((y2 - y1), (x2 - x1));

        }

    }
    public class UndoRedo
    {
       public List<MyGraph> listUndoRedo;
        public UndoRedo()
        {
            listUndoRedo = new List<MyGraph>();
        }

    }
}
