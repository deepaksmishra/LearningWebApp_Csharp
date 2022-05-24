using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace LWAJWTLOG.Models
{
   
        public  class Output
        {
            [Key]
            public int AppointmentId { get; set; }
            public int ReturnCode { get; set; }
            public DateTime SubmittedTime { get; set; }
        }
    }


