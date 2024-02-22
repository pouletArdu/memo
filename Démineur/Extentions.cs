using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Démineur
{
    public static class Extentions
    {
        public static void Shuffle<T>(this T[,] array)
        {
            Random rand = new Random();
            int lengthRow = array.GetLength(0);
            int lengthCol = array.GetLength(1);
            for (int i = 0; i < lengthRow; i++)
            {
                for (int j = 0; j < lengthCol; j++)
                {
                    int i1 = rand.Next(i, lengthRow);
                    int j1 = rand.Next(j, lengthCol);

                    // Échange
                    T temp = array[i, j];
                    array[i, j] = array[i1, j1];
                    array[i1, j1] = temp;
                }
            }
        }

    }
}
