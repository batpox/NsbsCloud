using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoilStoreApi
{

    public class CoilReadingValue
    {
        public CoilReadingValue(int ii, decimal vv)
        {
            Number = ii;
            Value = vv;
        }

        /// <summary>
        /// The reading number (1..NumberOfReading)
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The value
        /// </summary>
        public decimal Value { get; set; }

    }

    /// <summary>
    /// Provides methods to retrieve or update the coil data.
    /// </summary>
    public static class CoilStoreHelpers
    {

        /// <summary>
        /// Given a comma list, return a list of CoilReadings
        /// </summary>
        /// <param name="commalist"></param>
        /// <param name="readingsList"></param>
        /// <param name="explanation"></param>
        /// <returns></returns>
        public static bool GetCoilReadings(string commalist, out List<CoilReadingValue> readingsList, out string explanation)
        {
            explanation = "";
            readingsList = new List<CoilReadingValue>();

            try
            {
                List<decimal> decimals = commalist.Split(',').Select(s => decimal.Parse(s)).ToList();
                int ii = 0;
                foreach ( decimal dd in decimals)
                {
                    CoilReadingValue cr = new CoilReadingValue(++ii, dd);
                    readingsList.Add(cr);
                }
                return true;
            }
            catch (Exception ex)
            {
                explanation = string.Format("CommaList={0} Err={1}", commalist, ex.ToString());
                return false;
            }
        } // method

    } // class
}
