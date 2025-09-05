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
    [StringLength(200)]
    public required string Name { get; set; }
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    [Required]
    [Column(TypeName = "bit")]
    private bool Active { get; set; } = true;

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CratedAt { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime LastModifiedAt { get; set; }
   }
