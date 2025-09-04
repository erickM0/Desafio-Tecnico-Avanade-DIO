using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockService.Domain;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default;
    public required string Name { get; set; }
    private bool Active { get; set; } = true;

    private DateTime CratedAt { get; set; }
    private DateTime LastModifiedAt { get; set; }
    

 
}
