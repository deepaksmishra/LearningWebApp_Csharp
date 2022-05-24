using LWAJWTLOG.Model;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace LWAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class StudentController : ControllerBase
    {
        Logger loggerx = LogManager.GetCurrentClassLogger();

        public StudentController(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public DatabaseContext DbContext { get; }

        [HttpGet]
        [Route("where")]

        public IQueryable Where()
        {
            try
            {
                loggerx.Info("HTTP GET Request Executed Sucessfully");

                var address = from n in DbContext.Student.Where(n => n.Address == "n")
                              select n;
                return address;
            }
            catch
            {
                loggerx.Error("Error in Student Controller HHTP GEt Method");
                throw new Exception("Id already exixts please enter another id . it should be unique");

            }
            finally
            {
                loggerx.Error("Error in Student Controller HHTP GEt Method");

                throw new Exception("Id already exixts please enter another id ");

            }

        }

        [HttpGet]
        [Route("orderby")]


        public IQueryable orderby()
        {
            var address = from n in DbContext.Student orderby n.Name select n;

            return address;

        }

        [HttpGet]
        [Route("multipleorderby")]
        public IQueryable Get3()
        {



            var mulorderby = from c in DbContext.Student
                             orderby c.City, c.Name descending
                             select new
                             {
                                 Cityname = c.City,
                                 name = c.Name

                             };
            return mulorderby;
        }


        [HttpGet]
        [Route("innerjoin")]
        public IQueryable innerjoin()
        {



            var innerjoin = from s in DbContext.Student
                            join d in DbContext.StudentCourse
                            on s.Rollno equals d.Courseid
                            select new
                            {
                                StudentName = s.Name,
                                Rollno = s.Rollno,
                                Studentadress = s.Address,
                                CourseName = d.CourseName
                            };
            return innerjoin;
        }


        [HttpGet("Leftouterjoin")]
        public IQueryable LeftOut()
        {

            var data5 = from s in DbContext.Student
                        join d in DbContext.StudentCourse
                        on s.Rollno equals d.Courseid into studentdata
                        from gc in studentdata.DefaultIfEmpty()
                        select new
                        {
                            StudentName = s.Name,
                            StudentID = s.Rollno,
                            Studentadress = s.City,
                            Department = gc == null ? "NoCoursename" : gc.CourseName
                        };
            return data5;
        }

        //[HttpGet("GroupBy")]
        //public IQueryable groupby()
        //{

        //    var Result = from s in DbContext.Student
        //                 group s by s.City;



        //    return Result;
        //}



    }
}



