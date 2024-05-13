using EmployeeManagment.Models;
namespace EmployeeManagment.Repository.StateRepo
{
    public interface iStateRepository
    {   
        Task<IEnumerable<StateModel>> GetAllAsync();


        Task<StateModel?> GetByIdAsync(int Id);


        Task InsertAsync(StateModel stateModel);

        Task UpdateAsync(int Id);

        Task DeleteAsync(int Id);

        Task SaveAsync();

    }
}
