using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shop.Server.Models;

public class Feedback
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [StringLength(maximumLength: 1000, ErrorMessage = "Your comment should not be grater that 1000 charachters")]
    public string Message { get; set; } = null!;
    [Required]
    public string ProductId { get; set; } = null!;
    [Required]
    public string UserId { get; set; }
    [Required]
    [Range(0, 5)]
    public float Rate { get; set; }
    public Product Product { get; set; }
    public virtual IdentityUser User { get; set; }
}
