namespace AssetManagement.Models;

public record Price(Guid Id, Guid AssetId, string Source, decimal Value,DateTime Created);

