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

        public static async void LoadsTeamList()
        {
            var file = new FileInfo(@"C:\Users\darkx\source\repos\FaCup\FaCup\Resources\FinalTeams.xlsx");
            TeamModel.TeamList = await DataAccess.LoadRemainingTeams(file);
        }


        //Reads from Excel file and turns into objects
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
                    t.KnockedOut = (bool)worksheet.Cells[row, col + 4].Value;
                    output.Add(t);
                    row += 1;
                }
                return output;
            }  
        }

        //Similar to the function above but only returns teams that are still in the competition
        //##Modify later into one function with additional paramaters
        public static async Task<List<TeamModel>> LoadRemainingTeams(FileInfo file)
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
                    if(worksheet.Cells[row, col + 4].Value.ToString().ToLower() == "false")
                    {   
                        TeamModel t = new TeamModel();
                        t.TeamName = worksheet.Cells[row, col].Value.ToString();
                        t.LeaugeName = worksheet.Cells[row, col + 1].Value.ToString();
                        t.LeaugeId = (double)worksheet.Cells[row, col + 2].Value;
                        t.InCup = (bool)worksheet.Cells[row, col + 3].Value;
                        t.KnockedOut = (bool)worksheet.Cells[row, col + 4].Value;
                        output.Add(t);
                        
                    }
                    row += 1;
                }
                return output;

            }

            


        }

    }
}