using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Involved.HTF.Common.Dto
{
    public class QuatrilianDTO
    {
        public string[] quatralianNumbers { get; set; }

        public int calcNumbers()
        {
            int total = 0;
            foreach (var item in quatralianNumbers)
            {
              total +=  calcint(item);
            }
            return total;
        }
        static public int calcint(string quatrilion)
        {
            int complete = 0;
            int index = 1;
            foreach (char number in quatrilion)
            {
                if (number.Equals('.'))
                {
                    if(index == 1) { complete++; }
                    else complete += index - 1 * 20;
                } else if(number.Equals('|'))
                {
                    if (index == 1) complete += 5;
                    else complete += (index - 1) * 20 * 5;
                }
                else { index++; }
            }
            return complete;
        }
        static public string ReverseCalcint(int complete)
        {
            StringBuilder result = new StringBuilder();

            // Variable to keep track of how many pipes (|) we've added in a row
            int pipeCount = 0;

            // Process each base-20 digit
            while (complete > 0)
            {
                int remainder = complete % 20; // Get the remainder (base-20 digit)
                complete /= 20;  // Reduce the number by dividing it by 20

                // Handle the base-20 digits
                if (remainder == 1)
                {
                    result.Insert(0, '.');  // If remainder is 1, add a dot
                }
                else if (remainder == 5)
                {
                    result.Insert(0, '|');  // If remainder is 5, add a pipe
                }
                else if (remainder == 0)
                {
                    // If remainder is 0, that means we should insert a space
                    if (pipeCount == 5)
                    {
                        result.Insert(0, ' '); // Insert space after 5 pipes
                        pipeCount = 0; // Reset pipe count
                    }
                    continue; // Move to the next base-20 digit
                }
            }

            // Return the resulting string
            return result.ToString();
        }
    }
}
