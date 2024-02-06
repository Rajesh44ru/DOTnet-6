using System.ComponentModel.DataAnnotations;
using TestWEBAPI.Validators;

namespace TestWEBAPI.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }
        //[Required(ErrorMessage ="Student Name is Required")]
       // [Required()]
        public string StudentName { get; set; }
        //[EmailAddress(ErrorMessage ="Please Enter The valid Email")]
       // [EmailAddress()]
        public string Email { get; set; }
      //  [Required]
        public string Address { get; set; }

        //   [DateCheck]  // custom Vallidation
        //  public DateTime AddmissionDate { get; set; }

        //[Range(10,25)]
        // public int Age { get; set; }

        // public string Password { get; set; }
        // [Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }
        public DateTime DOB { get; set; }
        public int? DepartmentId { get; set; }


    }
}
