using System;
using System.Collections.Generic;
using System.Text;

namespace LessonOne.Models
{
    public class Clinic : HealthcareBuilding
    {
        public const int MaxCars = 2;
        public const int MinCars = 1;
        public const int MaxFloors = 3;
        public const int MinFloors = 1;

        public override BuildingType Type => BuildingType.Clinic;

        public Clinic(int floorCount, int carCount, int maxPatients)
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
            sb.AppendLine($"This Clinic is {FloorCount} floors tall.");
            sb.AppendLine($"It has {CarCount} cars");
            sb.AppendLine($"It is occupied by {PatientCount} {PatientType.Civilian} patients");
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
