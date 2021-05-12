using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaCup
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            InitializeComponent();

            //Checks if background file exists. 
            string filepath = @".\Resources\facupbackground.png";
            if (File.Exists(filepath))
            {
                Image myimage = new Bitmap(filepath);
                this.BackgroundImage = myimage;
            }
            else
            {
                BackColor = Color.FromArgb(145, 16, 13);
            }

        

    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Draw draw = new Draw();
            draw.ShowDialog();

        }
    }
    }

