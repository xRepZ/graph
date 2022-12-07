﻿using System;
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
    public partial class FormRenameNode : Form
    {
        public string NodeName;
        public FormRenameNode(string NodeName)
        {
            InitializeComponent();
            this.NodeName = NodeName;
            textBox1.Text = NodeName;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            NodeName = textBox1.Text;
            this.Close();
        }
    }
}
