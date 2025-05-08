using UnityEngine.Events;

namespace MemoryMatch.Core.ApplicationStates.ControllerInterfaces
{
    public interface IGameplayControllable
    {
        UnityAction OnGameplayEnded { get; set; }

        void StartGameplay();
    }
}