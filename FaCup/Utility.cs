﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaCup
{
    class Utility
    {
        //Saves fixtures to MyDocs
        public static void FixtureToFile(List<string> argFixtureList)
        {
            int lenght = argFixtureList.Count();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Fixtures.txt")))

                for (int i = 0; i < argFixtureList.Count(); i+=2)
                {
                    outputFile.WriteLine(argFixtureList[i] + " vs " + argFixtureList[i + 1]);
                }
            MessageBox.Show($@"Fixtures saved to: {docPath}\Fixtures.txt");

        }
        //Gets list lenght, finds value at random index
        public static int GetDrawId(List<int>argDrawNumbers)
        {
            var random = new Random();
            int randomindex = random.Next(argDrawNumbers.Count);
            int rndnumber = argDrawNumbers[randomindex];
            argDrawNumbers.RemoveAt(randomindex);
            return rndnumber;
        }
    }
}
