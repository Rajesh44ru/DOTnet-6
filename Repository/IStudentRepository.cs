using TestWEBAPI.Entities;

namespace TestWEBAPI.Repository
{
    public interface IStudentRepository:ICollegeRepository<Student>
    {

        Task<List<Student>> GetStudentsByFeeStatusAsync(int feeStatus);


    }

}
