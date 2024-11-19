using HMSERM.Dtos;
using HMSERM.Model;

namespace HMSERM.Interface.Service
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients();

        Task<Patient> AddPatient(PatientDto dto);

        Task<Patient> UpdatePatient(int id, PatientDto dto);

        Task<bool> DeletePatient(int id);
    }
}
