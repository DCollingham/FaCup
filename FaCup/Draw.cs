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

        private void Draw_Load(object sender, EventArgs e)
        {
            DataAccess.LoadsTeamList();
            txtTeamList.GotFocus += txtTeamList_GotFocus;
        }
       


        //Changes focus away form text box to remove unwanted cursor
        private void txtTeamList_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }

        //Testing shuffle button
        private async void btnShuffle_Click(object sender, EventArgs e)
        {
            txtTeamList.Text = null;
            TeamModel.TeamList.ShuffleTeams();
            btnShuffle.Text = "SHUFFLE";
            int counter = 1;

            foreach (var team in TeamModel.TeamList)
            {
                team.DrawId = counter;
                txtTeamList.Text += counter +") " + team.TeamName +  Environment.NewLine;
                counter++;
            }
            
        }
        //Testing Randomising a single team
        private void btnDrawTeams_Click(object sender, EventArgs e)
        {
            var TeamDrawIdList = Shuffle.TeamDrawList(TeamModel.TeamList);

            foreach (Control x in this.Controls)
            {
                if((string)x.Tag == "LabelTeams")
                {
                    x.Text = "Test";
                }
            }
        }
    }
}
