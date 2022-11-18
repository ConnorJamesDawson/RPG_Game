using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pokemon 
{
    public PokemonBase Base { get; private set; }
    public int level { get; private set; }

    public int HP { get; private set; }

    public List<PokemonMove> Moves { get; private set; }

    public Pokemon(PokemonBase pbase, int plevel)
    {
        Base = pbase;
        level = plevel;
        HP = MaxHP;

        //Generate Moves unpon contact/spawn
        Moves = new List<PokemonMove>();
        foreach(var move in Base.LearnableMoves)
        {
            if (move.Level <= level)
                Moves.Add(new PokemonMove(move.Base));

            if (Moves.Count > 4)
                break;
        }
    }

    public int Attack
    {
        get { return Mathf.FloorToInt(Base.Attack * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int Defense
    {
        get { return Mathf.FloorToInt(Base.Defense * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt(Base.SpAttack * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int SpDefense
    {
        get { return Mathf.FloorToInt(Base.SpDefense * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int Speed
    {
        get { return Mathf.FloorToInt(Base.Speed * level) / 100 + 5; } //Offical Pokemon Formula
    }
    public int MaxHP
    {
        get { return Mathf.FloorToInt(Base.MaxHP * level) / 100 + 10; } //Offical Pokemon Formula
    }
}
