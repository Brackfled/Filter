using NArchitecture.Core.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace WebAPI.Entities;

public class Attiribute: Entity<int>
{
    public string Name { get; set; }

    [JsonIgnore]
    public ICollection<AttiributeValue> AttiributeValues { get; set; } = default!;

    public Attiribute()
    {
        Name = string.Empty;
    }

    public Attiribute(string name, ICollection<AttiributeValue> attiributeValues)
    {
        Name = name;
        AttiributeValues = attiributeValues;
    }
}

