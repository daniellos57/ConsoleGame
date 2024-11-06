using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somewirdsht
{
    public static class RandomNumbers
    {
        public static int randomnumber(int min, int max)
        {
            Random random = new Random();

            // Generate a random integer between min and max
            int randomNumber = random.Next(min, max);
            return randomNumber;
        }
    }
}
