using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockService.Domain.Interfaces;
using StockService.Domain.Enums;

namespace StockService.Domain.Entities;

public class StockMovement : IAuditable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public MovementTypes MovementType { get; set; }
    public string? Observations { get; set; } = null;
}