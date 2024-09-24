using System;
using System.Collections.Generic;

namespace StoneGoose.Model.Events;

/// <summary>
/// Represents a queue of events throwed by game.
/// </summary>
public class GameEventQeueu
{
    readonly List<GameEvent> events = new();

    /// <summary>
    /// Push a Event on event queue with a calling phase,
    /// a GameEventArgs object and a delegate Handler.
    /// </summary>
    public void Push(
        GameEventPhase phase,
        GameEventArgs args,
        GameEventHandler handler
    )
    {
        ArgumentNullException.ThrowIfNull(args, nameof(args));
        ArgumentNullException.ThrowIfNull(phase, nameof(phase));
        ArgumentNullException.ThrowIfNull(handler, nameof(handler));

        events.Add(new(phase, args, handler));
    }

    /// <summary>
    /// Get the next event that needs to run and remove
    /// it from the queue.
    /// </summary>
    public GameEvent Pop()
    {
        throw new NotImplementedException();
    }
}