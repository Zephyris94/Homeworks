namespace LessonOne.Models
{
    public class Patient
    {
        public int Age { get; set; }

        public string FullName { get; set; }

        public string Diagnosis { get; set; }

        public string Address { get; set; }

        public PatientType PatientType { get; set; }
    }
}
