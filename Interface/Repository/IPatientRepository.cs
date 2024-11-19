using HMSERM.Model;

namespace HMSERM.Interface.Repository
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task Delete(Patient entity);
    }
}
