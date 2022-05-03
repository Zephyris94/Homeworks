using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonOne.Models
{
    public class HealthCareRegister
    {
        private List<HealthcareBuilding> _hcBuildings  = new List<HealthcareBuilding>();

        public HealthCareRegister()
        {
            
        }

        public HealthCareRegister(List<HealthcareBuilding> buildings)
        {
            _hcBuildings.AddRange(buildings);
        }

        public void AddNewBuilding(BuildingType type, int carCount, int floorCount, int maxPatients)
        {
            HealthcareBuilding b;

            switch (type)
            {
                case BuildingType.Clinic:
                    ValidateCount(carCount, Clinic.MinCars, Clinic.MaxCars, "Car");
                    ValidateCount(floorCount, Clinic.MinFloors, Clinic.MaxFloors, "Floor");

                    b = new Clinic(floorCount, carCount, maxPatients);
                    break;
                case BuildingType.Hospital:
                    ValidateCount(carCount, Hospital.MinCars, Hospital.MaxCars, "Car");
                    ValidateCount(floorCount, Hospital.MinFloors, Hospital.MaxFloors, "Floor");

                    b = new Hospital(floorCount, carCount, maxPatients);
                    break;
                case BuildingType.Infirmary:
                    ValidateCount(carCount, Infirmary.MinCars, Infirmary.MaxCars, "Car");
                    ValidateCount(floorCount, Infirmary.MinFloors, Infirmary.MaxFloors, "Floor");

                    b = new Infirmary(floorCount, carCount, maxPatients);
                    break;
                default:
                    throw new Exception("Wrong building type");
            }

            _hcBuildings.Add(b);
        }

        public void AddPatientToBuilding(Patient p, HealthcareBuilding b)
        {
            b.RegisterPatient(p);
        }

        public void AddPatientsToBuilding(List<Patient> p, HealthcareBuilding b)
        {
            b.RegisterPatients(p);
        }

        public HealthcareBuilding FindBiggest(BuildingType type)
        {
            var myResult = FilterByType(type)
                .OrderByDescending(x => x.FloorCount)
                .First();

            return myResult;
        }

        public HealthcareBuilding FindMostEmpty(BuildingType type)
        {
            var myResult = FilterByType(type)
                .OrderBy(x => x.PatientCount)
                .First();

            return myResult;
        }

        public HealthcareBuilding FindWithFreeCar(BuildingType type)
        {
            var myResult = FilterByType(type)
                .FirstOrDefault(x => x.FreeCars > 0);

            if (myResult == null)
            {
                throw new Exception("No place with cars");
            }

            return myResult;
        }

        public string GetInformation(HealthcareBuilding building)
        {
            return building.ReturnInformation();
        }

        public string GetWholeInformation()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var healthcareBuilding in _hcBuildings)
            {
                sb.Append(healthcareBuilding.ReturnInformation());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private IEnumerable<HealthcareBuilding> FilterByType(BuildingType type)
        {
            return _hcBuildings
                .Where(x => x.Type == type);
        }

        private void ValidateCount(int number, int minCount, int maxCount, string entity)
        {
            if (number > maxCount && number < minCount)
            {
                throw new Exception($"{entity} count is wrong");
            }
        }
    }
}
