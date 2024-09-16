using NArchitecture.Core.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace WebAPI.Entities;

public class AttiributeValue: Entity<int>
{
    public int AttiributeId { get; set; }
    public string Value { get; set; }

    public virtual Attiribute? Attiribute { get; set; }
    [JsonIgnore]
    public ICollection<Product> Products { get; set; } = default!;

    public AttiributeValue()
    {
        Value = string.Empty;
    }

    public AttiributeValue(int attiributeId, string value, Attiribute? attiribute, ICollection<Product> products)
    {
        AttiributeId = attiributeId;
        Value = value;
        Attiribute = attiribute;
        Products = products;
    }
}

