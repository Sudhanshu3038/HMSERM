namespace HMSERM.Model
{
    public class Location: Base
    {
     public int LocationId { get; set; }    
     public string Address { get; set; }
     public string Name { get; set; }


     public int ClinicId { get; set; }
 
     public virtual Clinic? Clinic { get; set; }

    }
}
