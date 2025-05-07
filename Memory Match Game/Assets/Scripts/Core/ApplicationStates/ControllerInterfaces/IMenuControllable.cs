using UnityEngine.Events;

namespace MemoryMatch.Core.ApplicationStates.ControllerInterfaces
{
    public interface IMenuControllable
    {
        UnityAction OnGameplayStarted { get; set; }
    }
}