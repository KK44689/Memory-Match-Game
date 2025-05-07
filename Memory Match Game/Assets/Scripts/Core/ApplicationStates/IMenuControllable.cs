using UnityEngine.Events;

namespace MemoryMatch.Core.ApplicationStates
{
    public interface IMenuControllable
    {
        UnityAction OnGameplayStarted { get; set; }
    }
}