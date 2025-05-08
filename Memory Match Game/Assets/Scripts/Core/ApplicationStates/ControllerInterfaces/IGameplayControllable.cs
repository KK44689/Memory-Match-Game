using UnityEngine.Events;

namespace MemoryMatch.Core.ApplicationStates.ControllerInterfaces
{
    public interface IGameplayControllable
    {
        UnityAction<string> OnGameplayEnded { get; set; }

        void StartGameplay();
    }
}