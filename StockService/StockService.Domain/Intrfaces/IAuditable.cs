namespace StockService.Domain.Intrfaces;

public interface IAuditable
{
    DateTime CreatedAt { get; set; }
    DateTime LastModifiedAt { get; set; }    
}
