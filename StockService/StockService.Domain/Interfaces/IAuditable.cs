namespace StockService.Domain.Interfaces;

public interface IAuditable
{
    DateTime CreatedAt { get; set; }
    
}

public interface IAuditableModified : IAuditable
{
    DateTime LastModifiedAt { get; set; }   

}