using System.ComponentModel.DataAnnotations;

namespace Shop.Server.Models.DTO
{
    public class Registration
    {
        [Required]
		[StringLength(10)]
		
        public string Name { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }



    }
}
