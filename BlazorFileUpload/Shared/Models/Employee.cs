using System.ComponentModel.DataAnnotations;

namespace BlazorFileUpload.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; }
       
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
      

    }
}
