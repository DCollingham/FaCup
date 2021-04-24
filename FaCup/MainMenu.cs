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


            var file = new FileInfo(@"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\FinalTeams.xlsx");
            List<TeamModel> TeamListFromExcel = await DataAccess.LoadExcelFile(file);

            foreach (var team in TeamListFromExcel)
            {
                rtbTeams.Text += team.TeamName.ToString() + team.InCup.ToString() + "\n";
            }



        }




    }
    }

