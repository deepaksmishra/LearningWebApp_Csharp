using System.ComponentModel.DataAnnotations;

namespace LWAJWTLOG.Models
{
    public class CodeFirst
    {
        [Key]
        public int empid { get; set; }
        public string empname { get; set; }
        public string address { get; set; }
    }
}
