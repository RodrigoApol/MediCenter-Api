namespace MediCenter.Core.Entities.ValueObjects;

public record Address(
    string PostalCode,
    string State,
    string City,
    string Street,
    int Number);