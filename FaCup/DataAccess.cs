using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaCup
{
    class DataAccess
    {
        public static List<string> ReturnTeams()
        {
            //Make relative path later
            string filepath = @"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\Last64Teams.txt";
            List<string> TeamList = File.ReadAllLines(filepath).ToList();
            return TeamList;
        }


        public static List<TeamModel> MakeObjectList()
        {
            List<TeamModel> output = new List<TeamModel>();
            List<string> Teams = ReturnTeams();

            foreach (var team in Teams)
            {
                TeamModel t = new TeamModel();
                t.TeamName = team;
                output.Add(t);
            }
            return output;
        }
    }
}
