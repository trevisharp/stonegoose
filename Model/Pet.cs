using System;

namespace StoneGoose.Model;

/// <summary>
/// Represents a Game Piece.
/// </summary>
public class Pet
{
    public int Attack { get; protected set; }
    public int Life { get; protected set; }
    public int Experience { get; protected set; }
}