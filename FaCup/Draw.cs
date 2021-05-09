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
        //Class Variables
        int LabelIndex = 0;
        List<int> DrawNumbers = new List<int>();
        List<string> Fixtures = new List<string>();
        bool DrawComplete = false;

   
        public Draw()
        {
            InitializeComponent();
            DataAccess.LoadsTeamList();
            PopList();
        }

        //Populates a list with integers in range of 1 to list size
        private void PopList()
        {
            for (int i = 0; i < 32; i++)
            {
                DrawNumbers.Add(i);
            }
        }


        private void DisplayClubOnLabel()
        {
            int index = Utility.GetDrawId(DrawNumbers);
            List<Label> TeamLabels = GetTeamLabels();
            //Loops through Labels to display Team Name
            TeamLabels[LabelIndex].Text = TeamModel.TeamList[index].TeamName.ToUpper();
            DisplayInfoBox(index);
            SaveFixture(index);
            LabelIndex++;
        }

        private void DisplayInfoBox(int index)
        {
            lbInfolLeauge.Text = "League: " + TeamModel.TeamList[index].LeaugeName;
            lblInfoClub.Text = "Club: " + TeamModel.TeamList[index].TeamName;
            lblInfoLevel.Text = "Club Level: " + TeamModel.TeamList[index].LeaugeId.ToString();
            lblInfoNumber.Text = "Drawn Number: " + TeamModel.TeamList[index].DrawId.ToString();
        }

        private void SaveFixture(int index)
        {
            Fixtures.Add(TeamModel.TeamList[index].TeamName);
        }


        //Returns a list with the tag 'LabelTeams'
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

        //Removes focus from text box, sets background. Happens before form is displayed.
        private void Draw_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@".\Resources\facupbackground.png");
            if (File.Exists(@".\Resources\facupbackground.png"))
            {
                this.BackgroundImage = myimage;
            }
            else
            {
                BackColor = Color.FromArgb(145, 16, 13);
            }

            ClearInfoBox();
            txtTeamList.GotFocus += txtTeamList_GotFocus;

        }

        //Changes focus away form text box to remove unwanted blinking cursor
        private void txtTeamList_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }

        //Displays and shuffles teams
        public void btnShuffle_Click(object sender, EventArgs e)
        {
            if (DataAccess.FileFound == true)
            {
                txtTeamList.Text = null;
                TeamModel.TeamList.ShuffleTeams();
                btnShuffle.Text = "SHUFFLE";
                DisplayTeamsLeft();
                btnDrawTeams.Enabled = true;
            }
            else
            {
                btnShuffle.Enabled = false;
                btnShuffle.Text = "Error";
            }
        }

        //Displays teams on board and saves if there are no more draws
        private void btnDrawTeams_Click(object sender, EventArgs e)
        {

            DisplayBoard();
            btnShuffle.Enabled = false;
            if(DrawNumbers.Count() == 0)
            {
                btnDrawTeams.Text = "Save";
                Utility.FixtureToFile(Fixtures);
                DrawComplete = true;

            }

        }

        private void DisplayBoard()
        {
            if (DrawComplete == false)
            {

   
            switch (LabelIndex)
            {
                case 15:
                    btnDrawTeams.Text = "Next 16";
                    DisplayClubOnLabel();
                    break;
                case 16:
                    var newlabel = GetTeamLabels();
                    foreach (var label in newlabel)
                    {
                        label.Text = null;
                    }
                    LabelIndex = 0;
                    btnDrawTeams.Text = "Draw Team";
                    break;
                default:
                    DisplayClubOnLabel();
                    break;
            }
            }
        }

        //Assigns the clubs a DrawId and displays them in the left text box
        private void DisplayTeamsLeft()
        {
            int counter = 1;
            foreach (var team in TeamModel.TeamList)
            {
                team.DrawId = counter;
                txtTeamList.Text += counter + ") " + team.TeamName + Environment.NewLine;
                counter++;
            }
        }
        private void ClearInfoBox()
        {
            lbInfolLeauge.Text = "";
            lblInfoClub.Text = "";
            lblInfoLevel.Text = "";
            lblInfoNumber.Text = "";
        }

    }
}
