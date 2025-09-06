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
    public required string Sku { get; set; }
    [Required]
    [StringLength(200)]
    public required string Name { get; set; }
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
