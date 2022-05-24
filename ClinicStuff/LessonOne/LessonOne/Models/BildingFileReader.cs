using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LessonOne.Models
{
    public class BildingFileReader
    {


        public List<HealthcareBuilding> GetBuildings()
        {
            var buildings = ReadBuildigs();
            var parsedBuildings = ParseBuilding(buildings);

            return parsedBuildings;

        }
        private List<string> ReadBuildigs()
        {
            Console.WriteLine("Enter path to file");
            string path = Console.ReadLine();
            var result = new List<string>();
            try
            {            
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (var br = new StreamReader(fs))
                    {
                        string line;
                        while ((line = br.ReadLine()) != null)
                        {
                            result.Add(line);
                        }

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return result;

        }

        private List<HealthcareBuilding> ParseBuilding(List<string> buildings)
        {
            var result = new List<HealthcareBuilding>();
            
            foreach(var building in buildings)
            {
                string[] dataArray = building.Split(';');
                var stringType = dataArray[0];
                var floorCount = int.Parse(dataArray[2]);
                var carCount = int.Parse(dataArray[3]);
                var maxPatients = int.Parse(dataArray[4]);
                var enumType = Enum.Parse<BuildingType>(stringType);
                switch (enumType)
                {
                    case BuildingType.Clinic:
                        result.Add(new Clinic(floorCount,carCount,maxPatients));
                        break;
                    case BuildingType.Hospital:
                        result.Add(new Hospital(floorCount, carCount, maxPatients));
                        break;
                    case BuildingType.Infirmary:
                        result.Add(new Infirmary(floorCount, carCount, maxPatients));
                        break;

                }
            }
            return result;
        }
    }
}
           
