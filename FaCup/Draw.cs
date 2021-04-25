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
    public partial class Draw : Form
    {
        public Draw()
        {

            InitializeComponent();
            Image myimage = new Bitmap(@"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\facupbackground.png");
            this.BackgroundImage = myimage;
        }

        private async void Draw_Load(object sender, EventArgs e)
        {
            txtTeamList.GotFocus += txtTeamList_GotFocus;
            var file = new FileInfo(@"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\FinalTeams.xlsx");
            List<TeamModel> TeamListFromExcel = await DataAccess.LoadRemainingTeams(file);

            foreach(var team in TeamListFromExcel)
            {
                txtTeamList.Text += team.TeamName + Environment.NewLine;
            }
            
        }
        //Changes focus away form text box to remove unwanted cursor
        private void txtTeamList_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }
    }
}
