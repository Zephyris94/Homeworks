using System;
using System.Collections.Generic;
using System.Text;

namespace LessonOne.Models
{
    public class Hospital : HealthcareBuilding
    {
        public const int MaxCars = 5;
        public const int MinCars = 2;

        public const int MaxFloors = 5;
        public const int MinFloors = 2;

        public override BuildingType Type => BuildingType.Hospital;

        public Hospital(int floorCount, int carCount, int maxPatients)
            : base(floorCount, carCount, maxPatients)
        {
            
        }

        public override void RegisterPatient(Patient patient)
        {
            ValidatePatient(patient.PatientType);

            Patients.Add(patient);
        }

        public override void RegisterPatients(List<Patient> patients)
        {
            foreach (var patient in patients)
            {
                ValidatePatient(patient.PatientType);
            }

            Patients.AddRange(patients);
        }

        public override string ReturnInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"This Clinic is {BildingName} and have {FloorCount} floors tall.");
            sb.AppendLine($"It has {CarCount} cars");
            sb.AppendLine($"It is occupied by {PatientCount} {PatientType.Military} patients");
            return sb.ToString();
        }

        private void ValidatePatient(PatientType type)
        {
            if (type == PatientType.Military)
            {
                throw new Exception("Only civilian allowed");
            }
        }
    }
}
