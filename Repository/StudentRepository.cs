using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TestWEBAPI.Entities;

namespace TestWEBAPI.Repository
{
    public class StudentRepository : CollegeRepository<Student>, IStudentRepository
    {
        private readonly CollegeDB _dbCOntext;
        public StudentRepository(CollegeDB DbCOntext):base(DbCOntext)
        {
            _dbCOntext = DbCOntext;       
        }
        public Task<List<Student>> GetStudentsByFeeStatusAsync(int feeStatus)
        {
            //Write code to return students having fee status pending
            return null;
        }

    }
}
