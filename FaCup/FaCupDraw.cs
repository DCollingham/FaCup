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
    public partial class FaCupDraw : Form
    {
        public FaCupDraw()
        {
            InitializeComponent(); 
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            var file = new FileInfo(@"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\FinalTeams.xlsx");
            List<TeamModel> TeamListFromExcel = await DataAccess.LoadExcelFile(file);

            List<TeamModel> TeamObjectList = DataAccess.MakeObjectList();
            foreach (var team in TeamListFromExcel)
            {
                rtbTeams.Text += team.TeamName.ToString() + "\n";
            }



        }




    }
    }

