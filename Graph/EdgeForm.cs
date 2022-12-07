using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class EdgeForm : Form
    {
        Edge edge;
        public EdgeForm(Edge edge, MyGraph graph)
        {
            InitializeComponent();
            this.edge = edge;
            textBox1.Text = edge.a.ToString();
            if (edge.Orientation == true) radioButton2.Checked = true;
            StartNode.Text = edge.StartVertexName;
            EndNode.Text = edge.EndVertexName;

          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            edge.a = Int32.Parse(textBox1.Text);
            if (radioButton1.Checked) edge.Orientation = false;
            else
                edge.Orientation = true;
            edge.StartVertexName = StartNode.Text;
            edge.EndVertexName = EndNode.Text;
            //edge.bezierPoints.Reverse();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string s = StartNode.Text;
            StartNode.Text = EndNode.Text;
            EndNode.Text = s;
           
        }
    }
}
