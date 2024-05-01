

using System.ComponentModel.DataAnnotations;

public class OrderDTO
{
    [Required]
    public string City { get; set; }
    [Required]
    public string Streat { get; set; }
    [Required]
    [Length(11, 11)]
    public string PhoneNumber { get; set; }
}