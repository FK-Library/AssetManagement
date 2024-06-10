namespace AssetManagement.Models;

public record Asset
{
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string ISIN { get; set; }
}