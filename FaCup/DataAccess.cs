using OfficeOpenXml;
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

        public static async Task<List<TeamModel>> LoadExcelFile(FileInfo file)
        {

            List<TeamModel> output = new List<TeamModel>();
            using (var package = new ExcelPackage(file))
            {
                await package.LoadAsync(file);
                var worksheet = package.Workbook.Worksheets[0];
                int row = 1;
                int col = 1;

                //Checks whether row & column are not null, convert to string if not null
                while (string.IsNullOrWhiteSpace(worksheet.Cells[row, col].Value?.ToString()) == false)
                {
                    TeamModel t = new TeamModel();
                    t.TeamName = worksheet.Cells[row, col].Value.ToString();
                    t.LeaugeName = worksheet.Cells[row, col + 1].Value.ToString();
                    t.LeaugeId = (double)worksheet.Cells[row, col + 2].Value;
                    t.InCup = (bool)worksheet.Cells[row, col + 3].Value;
                    output.Add(t);
                    row += 1;
                }
                return output;
            }
            
        }
    }
}