

using System.ComponentModel.DataAnnotations;

public class OrderDTO
{
    [Required]
    [AllowedValues(OrderTypes.PurchaseOrder, OrderTypes.ReturnOrder, ErrorMessage = "Invalid Order Type order type must be purchase or return")]
    public string OrderType { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Streat { get; set; }
    [Required]
    [Length(11, 11)]
    [PhoneNumber(ErrorMessage = "Invalid Phone Number")]
    public string PhoneNumber { get; set; }
}