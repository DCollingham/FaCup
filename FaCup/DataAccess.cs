using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaCup
{
    public static class DataAccess
    {
        //This is work-around for the method below not being able to return a bool due to async method type
        public static bool FileFound = false;



        //Adds Teams from excel file to list of Team Model

        public static async void LoadRemainingTeams(FileInfo file, List<TeamModel>argTeamList, bool argKnockedOut)
        {
            if (File.Exists(file.ToString()))

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
                        //Checks the fouth column 'Knocked Out' (Only last 32 Teams not knocked out)
                        if (worksheet.Cells[row, col + 4].Value.ToString().ToLower() == argKnockedOut.ToString().ToLower())
                        {
                            TeamModel t = new TeamModel();
                            t.TeamName = worksheet.Cells[row, col].Value.ToString();
                            t.LeaugeName = worksheet.Cells[row, col + 1].Value.ToString();
                            t.LeaugeId = (double)worksheet.Cells[row, col + 2].Value;
                            t.InCup = (bool)worksheet.Cells[row, col + 3].Value;
                            t.KnockedOut = (bool)worksheet.Cells[row, col + 4].Value;
                            argTeamList.Add(t);

                        }
                        row += 1;
                    }
                    FileFound = true;
                }
            }

            else
            {
                MessageBox.Show($"Error: {file} cound not be found!");
            }


        }

    }
}