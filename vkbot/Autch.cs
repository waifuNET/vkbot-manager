﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vkbot
{
    public partial class Autch : Form
    {
        public Autch()
        {
            InitializeComponent();
        }

        private void Autch_Load(object sender, EventArgs e)
        {

        }
        public string TheValue
        {
            get { return richTextBox1.Text; }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
