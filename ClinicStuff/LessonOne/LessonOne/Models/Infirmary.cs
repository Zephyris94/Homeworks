using System.Collections.Generic;
using System.Text;

namespace LessonOne.Models
{
    public class Infirmary : HealthcareBuilding
    {
        public const int MaxCars = 20;
        public const int MinCars = 5;

        public const int MaxFloors = 7;
        public const int MinFloors = 3;

        public override BuildingType Type => BuildingType.Infirmary;

        public Infirmary(int floorCount, int carCount, int maxPatients)
            : base(floorCount, carCount, maxPatients)
        {
            
        }

        public override void RegisterPatient(Patient patient)
        {
            Patients.Add(patient);
        }

        public override void RegisterPatients(List<Patient> patients)
        {
            Patients.AddRange(patients);
        }

        public override string ReturnInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"This Infirmary is {FloorCount} floors tall.");
            sb.AppendLine($"It has {CarCount} cars");
            sb.AppendLine($"It is occupied by {PatientCount} both {PatientType.Civilian} and {PatientType.Military} patients");
            return sb.ToString();
        }
    }
}
