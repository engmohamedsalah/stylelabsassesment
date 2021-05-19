using CsvHelper;
using CsvHelper.Configuration;
using Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using WebExperience.DAL;
using WebExperience.Repository;
using WebExperience.Service;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// using package CSVHelp
    /// </summary>
    public class CsvProcessingTest : ITest
    {


        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted

            var csvFile = Resources.AssetImport;
            //read the file
            TextReader sr = new StringReader(csvFile);
            //usign CsvReader from CSVHelp package
            using (CsvReader csv = new CsvReader(sr, true))
            {
                //get instance form Repository with new data base context
                IAssetRepository assetRepository = new AssetRepository(new AssetContext());

                //variable for restore the assets from csv file  
                List<Asset> records = new List<Asset>();
                //comma delimiter as we use CSV
                csv.Configuration.Delimiter = ",";
                //make mapper from class AssetCSVMapper
                csv.Configuration.RegisterClassMap<AssetCSVMapper>();
                //read to end of file
                while (csv.Read())
                {

                    var record = csv.GetRecord<Asset>();
                    record.CreatedDate = DateTime.Now;
                    records.Add(record);

                }
                
                //clear data if from table before insert
                assetRepository.DeleteWhere(a => true);

                //new stop watch for debug purpose
                Stopwatch sp = new Stopwatch();
                sp.Start();
                assetRepository.AddBulk(records);
                sp.Stop();
                Console.WriteLine("Time=" + string.Format("{0:h\\:mm\\:ss}", sp.Elapsed));



                //new stop watch for debug purpose
                //clear data if from table before insert
                //assetRepository.DeleteAll();
                //assetRepository.DeleteWhere(a => true);
                //sp.Start();
                //assetRepository.AddBulkWithoutPackage(records);
                //sp.Stop();
                //Console.WriteLine("Time=" + string.Format("{0:h\\:mm\\:ss}", sp.Elapsed));

            }

        }

    }
    /// <summary>
    /// class mapper used to map column names to 
    /// class prop names
    /// </summary>
    /// <remarks></remarks>
    public class AssetCSVMapper : ClassMap<Asset>

    {
        public AssetCSVMapper()
        {
            Map(m => m.Id).Name("asset id");
            Map(m => m.FileName).Name("file_name");
            Map(m => m.MimeType).Name("mime_type");
            Map(m => m.CreatedBy).Name("created_by");
            Map(m => m.Email).Name("email");
            Map(m => m.Country).Name("country");
            Map(m => m.Description).Name("description");


        }


    }


}
