namespace AssetManagement.Models;

public record Price
{
    public required Guid Id;
    public required Guid AssetId;
    public string Source;
    public decimal Value;
    public DateTime Created;
}

