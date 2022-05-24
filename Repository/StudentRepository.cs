namespace LWAJWTLOG.Repository;
using LWAJWTLOG.Model;
using LWAJWTLOG.Models;
using Microsoft.EntityFrameworkCore;

   
    public class StudentRepository : Student
    {
        readonly DatabaseContext _dbContext = new();

        public StudentRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

     public List<Student> StudentDetails()

    {  
            try
            {
            //linq
                return _dbContext.Student.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
