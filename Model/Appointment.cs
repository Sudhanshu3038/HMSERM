namespace HMSERM.Model
{
    public class Appointment: Base
    {
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }


        public int? ClinicId { get; set; }
        public int? PractitionerId { get; set; }
        public int? PatientId { get; set; }
        public int? LocationId { get; set; }


        public virtual Clinic? Clinic { get; set; }
        public virtual Practitioner? Practitioner { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual Location? Location { get; set; }
    }
}
