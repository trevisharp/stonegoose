namespace StoneGoose.Model.Events;

/// <summary>
/// Represents a single game event.
/// </summary>
public record GameEvent(
    GameEventPhase Phase,
    GameEventArgs Args,
    GameEventHandler Handler
);