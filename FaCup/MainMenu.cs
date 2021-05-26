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



        //Opens fourth round draw page
        private void btnDraw_Click(object sender, EventArgs e)
        {
            Draw draw = new Draw();
            draw.ShowDialog();
        }
    }
    }

