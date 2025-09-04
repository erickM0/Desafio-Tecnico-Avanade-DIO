using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace StockService.Infra;

public class DBContext : DbContext
{
    private readonly IConfiguration _configurationAppSettings;
    public DBContext(IConfiguration configurationAppSettings)
    {
        _configurationAppSettings = configurationAppSettings;
    }
}
