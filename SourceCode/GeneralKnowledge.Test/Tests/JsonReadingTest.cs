using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
/// <summary>
/// 
/// </summary>
namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public string Name { get { return "JSON Reading Test";  } }

        public void Run()
        {
            var jsonData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            PrintOverview(jsonData);
        }

        /// <summary>
        /// convert the json data to list of object of predfine
        /// class
        /// solution depends on make mapping classes 
        /// match the json structure then mapping the json data to it
        /// </summary>
        /// <param name="data">byte array of json data</param>
        /// <remarks></remarks>
        private void PrintOverview(byte[] data)
        {
            //help help method convert form from json to class
            var pointsLst = data.ConvertJsonByteArrayToObject<RootObject>().Points;


            //start printing statistics 
            //for future it need to be generic 
            // function should be smart to read the prop of the class and return
            // the statistic or send param name to function and it collect the statistics


            Console.WriteLine("parameter \t LOW \t Avg \t Max");
            //statistic for temperature
            Console.WriteLine("temperature \t {0}\t {1}\t{2}"
                              , pointsLst.Min(a => a.Temperature)
                              , pointsLst.Average(a => a.Temperature).Value.ToString(Constant.TwoDecimalPointFormat)
                              , pointsLst.Max(a => a.Temperature));
            //statistic for pH
            Console.WriteLine("PH \t\t {0}\t {1}\t{2}"
                              , pointsLst.Min(a => a.PH)
                              , pointsLst.Average(a => a.PH).Value.ToString(Constant.TwoDecimalPointFormat)
                              , pointsLst.Max(a => a.PH));
            //statistic for Chloride
            Console.WriteLine("Chloride \t {0}\t {1}\t{2}"
                              , pointsLst.Min(a => a.PH)
                              , pointsLst.Average(a => a.Chloride).Value.ToString(Constant.TwoDecimalPointFormat)
                              , pointsLst.Max(a => a.Chloride));
            //statistic for Phosphate
            Console.WriteLine("Phosphate\t {0}\t {1}\t{2}"
                              , pointsLst.Min(a => a.Phosphate)
                              , pointsLst.Average(a => a.Phosphate).Value.ToString(Constant.TwoDecimalPointFormat)
                              , pointsLst.Max(a => a.Phosphate));
            //statistic for Nitrate
            Console.WriteLine("Nitrate \t {0}\t {1}\t{2}"
                              , pointsLst.Min(a => a.Nitrate)
                              , pointsLst.Average(a => a.Nitrate).Value.ToString(Constant.TwoDecimalPointFormat)
                              , pointsLst.Max(a => a.Nitrate));

          
        }
    }
}
