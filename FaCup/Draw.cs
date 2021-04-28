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
        List<int> DrawNumbers = new List<int>();

        public Draw()
        {
            InitializeComponent();

            lbInfolLeauge.Text = "";
            lblInfoClub.Text = "";
            lblInfoLevel.Text = "";
            lblInfoNumber.Text = "";
            Image myimage = new Bitmap(@"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\facupbackground.png");
            this.BackgroundImage = myimage; 
        }
        //Populates a list with integers in range of 1 to list size
        private void PopList()
        {
            for (int i = 0; i < 32; i++)
            {
                DrawNumbers.Add(i);
            }
        }

        private int GetRandomNumber()
        {
            var random = new Random();
            int randomindex = random.Next(DrawNumbers.Count);
            int rndnumber = DrawNumbers[randomindex];
            DrawNumbers.RemoveAt(randomindex);
            return rndnumber;
        }

        private void LoopLabels()
        {
            int test = GetRandomNumber();
            lblTest2.Text = test.ToString();
            List<Label> TeamLabels = GetTeamLabels();
            //Loops through Labels to display Team Name
            TeamLabels[TeamIndexer].Text = TeamModel.TeamList[test].TeamName;
            DisplayInfoBox(test);
            TeamIndexer++;
            lblTest.Text = DrawNumbers.Count().ToString();

            if(TeamIndexer == 16)
            {
                TeamIndexer = 0;

            }
        }

        private void DisplayInfoBox(int TeamIndexer)
        {
            lbInfolLeauge.Text = "League: " + TeamModel.TeamList[TeamIndexer].LeaugeName;
            lblInfoClub.Text = "Club: " + TeamModel.TeamList[TeamIndexer].TeamName;
            lblInfoLevel.Text = "Club Level: " + TeamModel.TeamList[TeamIndexer].LeaugeId.ToString();
            lblInfoNumber.Text = "Drawn Number: " + TeamModel.TeamList[TeamIndexer].DrawId.ToString();
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
            PopList();
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
