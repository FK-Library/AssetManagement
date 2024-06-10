namespace AssetManagement.Models;

public record Asset
{
    public required Guid Id;
    public string Name;
    public string Symbol;
    public string ISIN;
}
