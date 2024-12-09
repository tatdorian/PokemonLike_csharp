using System;
using System.Collections.Generic;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp.Model;

public class Monster
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string ImageUrl { get; set; }
    public int Health { get; set; }
    public ICollection<Spell> Spells { get; set; } = new List<Spell>();
    public ICollection<Player> Players { get; set; } = new List<Player>();
}



