using System;
using System.Collections.Generic;

namespace StoneGoose.Model;

public struct State
{
    // Piece Data Summary
    // 0-5   Piece Info
    // 6-11  Attack
    // 12-17 Life
    // 18-19 Level
    // 20-21 Experience
    // 22-27 Effect
    // 28-31 Extra Info
    const uint ant      = 0b000001_000010_000001_01_00_000000_0000;
    const uint pig      = 0b000010_000100_000001_01_00_000000_0000;
    const uint fish     = 0b000011_000010_000011_01_00_000000_0000;
    const uint duck     = 0b000100_000010_000011_01_00_000000_0000;
    const uint cricket  = 0b000101_000001_000010_01_00_000000_0000;
    const uint mosquito = 0b000110_000010_000010_01_00_000000_0000;
    const uint beaver   = 0b000111_000011_000010_01_00_000000_0000;
    const uint otter    = 0b001000_000001_000011_01_00_000000_0000;
    const uint horse    = 0b001000_000010_000001_01_00_000000_0000;
    const uint mouse    = 0b001001_000010_000001_01_00_000000_0000;

    private uint pieceA = 0;
    private uint pieceB = 0;
    private uint pieceC = 0;
    private uint pieceD = 0;
    private uint pieceE = 0;

    private uint shopA = 0;
    private uint shopB = 0;
    private uint shopC = 0;
    private uint shopD = 0;
    private uint shopE = 0;
    private uint shopF = 0;

    private byte turn = 1;
    private byte life = 5;
    private byte gold = 10;
    
    private float prob = 0;
    private float aval = 0;

    public State() { }

    public IEnumerable<State> NextIterator
    {
        get
        {
            yield break;
        }
    }

    public void Swap(int i, int j)
    {
        var piece1 = get(i);
        var piece2 = get(j);
        set(i, piece2);
        set(j, piece1);
    }

    public void Refill()
    {
        if (gold < 1)
            return;
        
        gold -= 1;
        shopA = rand();
        shopB = rand();
        shopC = rand();
    }

    public State Clone()
        => new()
        {
            pieceA = pieceA,
            pieceB = pieceB,
            pieceC = pieceC,
            pieceD = pieceD,
            pieceE = pieceE,
            shopA  = shopA,
            shopB  = shopB,
            shopC  = shopC,
            shopD  = shopD,
            shopE  = shopE,
            shopF  = shopF,
            prob   = prob,
            aval   = aval
        };

    public float Probability => prob;
    public float Avaliation  => aval;

    private int maxTier()
        => turn switch
        {
            <12 => (turn + 1) / 2,
            _   => 6
        };

    private uint rand()
    {
        var randTier = 
            Random.Shared.Next(1, maxTier());
        return rand(randTier);
    }

    private uint rand(int tier)
    {
        int randValue = 10 * (tier - 1) +
            Random.Shared.Next(10);
        return randValue switch
        {
            0 => ant,
            1 => pig,
            2 => fish,
            3 => duck,
            4 => cricket,
            5 => mosquito,
            6 => beaver,
            7 => otter,
            8 => horse,
            9 => mouse, 
            _ => 0
        };
    }

    private uint get(int i)
        => i switch
        {
            0 => pieceA,
            1 => pieceB,
            2 => pieceC,
            3 => pieceD,
            _ => pieceE
        };
    
    private void set(int i, uint value)
    {
        switch (i)
        {
            case 0:
                pieceA = value;
                break;
            case 1:
                pieceB = value;
                break;
            case 2:
                pieceC = value;
                break;
            case 3:
                pieceD = value;
                break;
            default:
                pieceE = value;
                break;
        }
    }
}