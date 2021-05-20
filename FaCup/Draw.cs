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
        List<TeamModel> TeamList = new List<TeamModel>();
        bool DrawComplete = false;

   
        public Draw()
        {
            var file = new FileInfo(@".\resources\finalteams.xlsx");
            InitializeComponent();
            DataAccess.LoadRemainingTeams(file, TeamList, false);
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
            TeamLabels[LabelIndex].Text = TeamList[index].TeamName.ToUpper();
            DisplayInfoBox(index);
            SaveFixture(index);
            LabelIndex++;
        }

        private void DisplayInfoBox(int index)
        {
            lbInfolLeauge.Text = "League: " + TeamList[index].LeaugeName;
            lblInfoClub.Text = "Club: " + TeamList[index].TeamName;
            lblInfoLevel.Text = "Club Level: " + TeamList[index].LeaugeId.ToString();
            lblInfoNumber.Text = "Drawn Number: " + TeamList[index].DrawId.ToString();
        }

        private void SaveFixture(int index)
        {
            Fixtures.Add(TeamList[index].TeamName);
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
            int HowManyTeams = TeamCounter();
            if (DataAccess.FileFound == true)

            {
                if(HowManyTeams == 32)
                {
                    txtTeamList.Text = null;
                    TeamList.ShuffleTeams();
                    btnShuffle.Text = "SHUFFLE";
                    DisplayTeamsLeft();
                    btnDrawTeams.Enabled = true;
                } 
                else
                {
                    MessageBox.Show($"Error: {HowManyTeams} teams currently in draw but 32 teams are needed.");
                    btnShuffle.Text = "Error";
                    btnShuffle.Enabled = false;
                    btnDrawTeams.Text = "Error";
                }
            }
   
            else
                {
                    btnShuffle.Text = "Error";
                    btnShuffle.Enabled = false;
                    btnDrawTeams.Text = "Error";
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
            foreach (var team in TeamList)
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

        private int TeamCounter()
        {
            int counter = 0;
            foreach (var team in TeamList)
            {
                counter++;
            }
            return counter;

        }

    }
}
