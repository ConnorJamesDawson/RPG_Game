using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonMove 
{
    public PokemonMovesBase Base { get; set; }
    public int PP { get; set; }

    public PokemonMove(PokemonMovesBase @base)
    {
        Base = @base;
        PP = @base.PP;
    }
}
