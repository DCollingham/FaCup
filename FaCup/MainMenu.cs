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
            Image myimage = new Bitmap(@"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\facupbackground.png");
            this.BackgroundImage = myimage;
            InitializeComponent(); 
        }

        private async void Form1_Load(object sender, EventArgs e)
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

