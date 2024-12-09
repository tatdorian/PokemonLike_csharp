using System;
using System.Collections.Generic;

namespace PokemonLikeCsharp.Model;

public class Spell
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Damage { get; set; }
    public ICollection<Monster> Monsters { get; set; } = new List<Monster>();
}
