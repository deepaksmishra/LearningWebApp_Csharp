using System.Collections.Generic;
using System.Threading.Tasks;
using LWAJWTLOG.Model;
using LWAJWTLOG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using static LWAJWTLOG.Models.Output;

namespace LWAJWTLOG.Model
{
    [Route("api/[controller]")]
    [ApiController]
    public class outputsController : ControllerBase
    {
        private readonly StoredDbContext _context;
        Logger loggerx = LogManager.GetCurrentClassLogger();


        public outputsController(StoredDbContext context)
        {
            _context = context;
        }
        //[HttpGet]
        ////public async Task<ActionResult<IEnumerable<Output>>> Getoutput()
        ////{
        ////    return await _context.Output.ToListAsync();
        ////}
        //public async Task<ActionResult<IEnumerable<Output>>> Getoutput()
        //{
        //    return await _context.Output.ToListAsync();
        //}
        // POST: api/outputs
        [HttpPost]

        public async Task<ActionResult<IEnumerable<Output>>> Getoutput(Input input)

        {
            loggerx.Info("Output Controller Loaded");
            string StoredProc = "exec CreateAppointment " +
                    "@ClinicID = " + input.ClinicId + "," +
                    "@AppointmentDate = '" + input.AppointmentDate + "'," +
                    "@FirstName= '" + input.FirstName + "'," +
                    "@LastName= '" + input.LastName + "'," +
                    "@PatientID= " + input.PatientId + "," +
                    "@AppointmentStartTime= '" + input.AppointmentStartTime + "'," +
                    "@AppointmentEndTime= '" + input.AppointmentEndTime + "'";

            //return await _context.output.ToListAsync();
            return await _context.Output.FromSqlRaw(StoredProc).ToListAsync();
        }

    }
}