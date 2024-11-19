namespace HMSERM.Model
{
    public class GlobalTypeCategory
    {
        public int GlobalTypeCategoryId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; } = true;


        public int? ClinicId { get; set; }

        public virtual Clinic? Clinic { get; set; }
  }
}
