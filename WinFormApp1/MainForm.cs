﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnMessage_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            //MessageBox.Show($"Hell World! {now}");

            TxtCurrentDate.Text = now.ToString();


        }

        private void TxtCurrentDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
