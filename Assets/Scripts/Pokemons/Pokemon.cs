using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pokemon 
{
    PokemonBase _base;
    int level;

    public int HP { get; private set; }

    public List<PokemonMove> Moves { get; private set; }

    public Pokemon(PokemonBase pbase, int plevel)
    {
        _base = pbase;
        level = plevel;
        HP = _base.MaxHP;

        //Generate Moves unpon contact/spawn
        Moves = new List<PokemonMove>();
        foreach(var move in _base.LearnableMoves)
        {
            if (move.Level <= level)
                Moves.Add(new PokemonMove(move.Base));

            if (Moves.Count > 4)
                break;
        }
    }

    public int Attack
    {
        get { return Mathf.FloorToInt(_base.Attack * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int Defense
    {
        get { return Mathf.FloorToInt(_base.Defense * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt(_base.SpAttack * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int SpDefense
    {
        get { return Mathf.FloorToInt(_base.SpDefense * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int Speed
    {
        get { return Mathf.FloorToInt(_base.Speed * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int MaxHP
    {
        get { return Mathf.FloorToInt(_base.MaxHP * level) / 100 + 10; } //Offical Pokemon Formula
    }
}
