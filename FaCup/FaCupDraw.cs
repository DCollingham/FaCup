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

        private void Form1_Load(object sender, EventArgs e)
        {
            //List<string> TeamList = DataAccess.ReturnTeams();
            //foreach (var team in TeamList)
            //{
            //    rtbTeams.Text += team + "\n";
            //}

            List<TeamModel> TeamObjectList = DataAccess.MakeObjectList();
            foreach (var team in TeamObjectList)
            {
                rtbTeams.Text += team.TeamName.ToString() + "\n";
            }
        }
    }
}
