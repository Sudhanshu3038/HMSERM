namespace HMSERM.Model
{
    public class GlobalType
    {
        public int GlobalTypeId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }


        public int? GlobalTypeCategoryId { get; set; }
        public int? ClinicId { get; set; }


        public virtual GlobalTypeCategory? GlobalTypeCategory { get; set; }
        public virtual Clinic? Clinic { get; set; }
    }
}
