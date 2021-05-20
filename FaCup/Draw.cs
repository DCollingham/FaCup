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
        int labelIndex = 0;
        List<int> drawNumbers = new List<int>();
        List<string> fixtures = new List<string>();
        List<TeamModel> teamList = new List<TeamModel>();
        bool drawComplete = false;

        //Gets teams from excel and populates list
        public Draw()
        {
            var file = new FileInfo(@".\resources\finalteams.xlsx");
            InitializeComponent();
            DataAccess.LoadRemainingTeams(file, teamList, false);
            PopList();
        }

        //Populates a list with integers in range of 0-31 used for indexing
        private void PopList()
        {
            for (int i = 0; i < 32; i++)
            {
                drawNumbers.Add(i);
            }
        }

        //Displays club on label then increases label index
        private void DisplayClubOnLabel()
        {
            int index = Utility.GetDrawId(drawNumbers);
            List<Label> TeamLabels = GetTeamLabels();
            //Loops through Labels to display Team Name
            TeamLabels[labelIndex].Text = teamList[index].TeamName.ToUpper();
            DisplayInfoBox(index);
            SaveFixture(index);
            labelIndex++;
        }
        //Displays team info in infobox
        private void DisplayInfoBox(int index)
        {
            lbInfolLeauge.Text = "League: " + teamList[index].LeaugeName;
            lblInfoClub.Text = "Club: " + teamList[index].TeamName;
            lblInfoLevel.Text = "Club Level: " + teamList[index].LeaugeId.ToString();
            lblInfoNumber.Text = "Drawn Number: " + teamList[index].DrawId.ToString();
        }
        //Saves fixture to file
        private void SaveFixture(int index)
        {
            fixtures.Add(teamList[index].TeamName);
        }


        //Returns a list with the tag 'LabelTeams'
        private List<Label> GetTeamLabels()
        {
            List<Label> lbls = this.Controls.OfType<Label>().ToList();
            List<Label> teamLabels = new List<Label>();
            foreach (var label in lbls)
            {
                if (label.Tag != null && label.Tag.ToString() == "LabelTeams")
                {
                    teamLabels.Add(label);
                }
            }
            teamLabels.Reverse();
            return teamLabels;
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
            int howManyTeams = TeamCounter();
            if (DataAccess.FileFound == true)

            {
                if(howManyTeams == 32)
                {
                    txtTeamList.Text = null;
                    teamList.ShuffleTeams();
                    btnShuffle.Text = "SHUFFLE";
                    DisplayTeamsLeft();
                    btnDrawTeams.Enabled = true;
                } 
                else
                {
                    MessageBox.Show($"Error: {howManyTeams} teams currently in draw but 32 teams are needed.");
                    btnShuffle.Text = "Error";
                    btnShuffle.Enabled = false;
                    btnDrawTeams.Text = "Error";
                }
            }
            //if FileFound = false
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
            if (drawComplete == false)
            {
                DisplayBoard();
                btnShuffle.Enabled = false;
                if (drawNumbers.Count() == 0)
                {
                    btnDrawTeams.Text = "Save";
                    drawComplete = true;
                }
            }
            else
            {
                Utility.FixtureToFile(fixtures);
            }
        }
        //Checks certain cases and displays teams on board
        private void DisplayBoard()
        {
            if (drawComplete == false)
            {

   
            switch (labelIndex)
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
                    labelIndex = 0;
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
            foreach (var team in teamList)
            {
                team.DrawId = counter;
                txtTeamList.Text += counter + ") " + team.TeamName + Environment.NewLine;
                counter++;
            }
        }
        //Clears the infobox
        private void ClearInfoBox()
        {
            lbInfolLeauge.Text = "";
            lblInfoClub.Text = "";
            lblInfoLevel.Text = "";
            lblInfoNumber.Text = "";
        }
        //Counts the number of teams
        private int TeamCounter()
        {
            int counter = 0;
            foreach (var team in teamList)
            {
                counter++;
            }
            return counter;

        }

    }
}
