using HMSERM.Data;
using HMSERM.Interface.Repository;
using HMSERM.Model;

namespace HMSERM.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task Delete(Patient entity)
        {
            _dbContext.Set<Patient>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
