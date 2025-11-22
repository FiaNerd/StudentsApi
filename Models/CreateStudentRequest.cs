using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models
{
    public struct CreateStudentRequest
    {
        [Required(ErrorMessage = "Du måste ha ett namn")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Du måste använda minst två tecken i namnet" )]
        public string Name { get; set; }

        [Required(ErrorMessage = "Du måste ha en email")]
        [EmailAddress(ErrorMessage = "Du måste ange en giltig emailadress")]
        public string Email { get; set; }
    }
}
