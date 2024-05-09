

using System.ComponentModel.DataAnnotations;

public class ProductSaleDTO
{
    [Required]
    public string ProdId { get; set; }
    [Required]
    [DateValidation(ErrorMessage = $"Date should be later than today")]
    public DateTime StartDate { get; set; }
    [Required]
    [DateValidation(ErrorMessage = $"Date should be later than today")]
    public DateTime EndDate { get; set; }
    [Required]
    public float SlaeRate { get; set; }
}