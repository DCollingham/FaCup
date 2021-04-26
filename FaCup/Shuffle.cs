using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaCup
{

    //Code copied from https://stackoverflow.com/questions/45328423/c-sharp-randomize-list-action
    public static class Shuffle
    {
        private static System.Random rng = new System.Random();

        public static void ShuffleTeams<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}