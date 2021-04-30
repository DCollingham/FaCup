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
        int LabelIndex = 0;
        List<int> DrawNumbers = new List<int>();
        List<string> Fixtures = new List<string>();
        public Draw()
        {
            InitializeComponent();
            ClearInfoBox();
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


        private void Draw_Load(object sender, EventArgs e)
        {
            DataAccess.LoadsTeamList();
            txtTeamList.GotFocus += txtTeamList_GotFocus;
            PopList();
        }

        //Changes focus away form text box to remove unwanted blinking cursor
        private void txtTeamList_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }

        //Displays and shuffles teams
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            txtTeamList.Text = null;
            TeamModel.TeamList.ShuffleTeams();
            btnShuffle.Text = "SHUFFLE";
            DisplayTeamsLeft();
            btnDrawTeams.Enabled = true;
        }
        //Calls method to draw team
        private void btnDrawTeams_Click(object sender, EventArgs e)
        {
            DisplayBoard();
            btnShuffle.Enabled = false;
            if(DrawNumbers.Count() == 0)
            {
                btnDrawTeams.Text = "Save";
                Utility.FixtureToFile(Fixtures);
                

            }
            if(btnDrawTeams.Text == "Save")
            {
                Reset();
            }
        }

        private void DisplayBoard()
        {
            switch (LabelIndex)
            {
                case 15:
                    btnDrawTeams.Text = "Clear";
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

        //Assigns the clubs a DrawId and displays then in the left text box
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

        private void Reset()

        {
            var newlabel = GetTeamLabels();
            foreach (var label in newlabel)
            {
                label.Text = null;
            }
            ClearInfoBox();
            DrawNumbers.Clear();
            Fixtures.Clear();
            txtTeamList.Text = null;
            LabelIndex = 0;
            PopList();
            btnShuffle.Enabled = true;
            btnDrawTeams.Text = "Draw Team";
            btnDrawTeams.Enabled = false;

        }

    }
}
