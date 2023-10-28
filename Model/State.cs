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
    // 22-26 Effect

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

    private byte turn = 0;
    private byte life = 0;
    private byte gold = 0;
    
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