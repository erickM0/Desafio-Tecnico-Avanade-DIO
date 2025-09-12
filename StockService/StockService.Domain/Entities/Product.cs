using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockService.Domain.Interfaces;

namespace StockService.Domain.Entities;


public class Product : IAuditableModified
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default;
    [Required]
    [StringLength(50)]
    public required string Sku { get; set; }
    [StringLength(500)]
    public string? Description { get; set; } = default;
    [Required]
    [StringLength(200)]
    public required string Name { get; set; }
    public double Price { get; set; } = 0;
    [Required]
    [Column(TypeName = "bit")]
    private bool Active { get; set; } = true;
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; }
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime LastModifiedAt { get; set; }
   }
