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
        int TeamIndexer = 0;

        public Draw()
        {
            InitializeComponent();
            Image myimage = new Bitmap(@"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\facupbackground.png");
            this.BackgroundImage = myimage; 
        }



        private void LoopLabels()
        {
            var random = new Random();
            int index = random.Next(TeamModel.TeamList.Count);
            List<Label> TeamLabels = GetTeamLabels();
            TeamLabels[TeamIndexer].Text = TeamModel.TeamList[TeamIndexer].TeamName;
            TeamIndexer++;

        }
        //Returns a list with the tag LabelTeams
        private List<Label> GetTeamLabels()
        {
            List<Label> lbls = this.Controls.OfType<Label>().ToList();
            List<Label> TeamLabels = new List<Label>();
            foreach (var label in lbls)
            {
                if (label.Tag != null && label.Tag.ToString() == "LabelTeams")
                {
                    TeamLabels.Add(label);
                }
            }
            TeamLabels.Reverse();
            return TeamLabels;
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
        private void btnShuffle_Click(object sender, EventArgs e)
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
            LoopLabels(); 
        }
    }
}
