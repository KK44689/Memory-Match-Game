using UnityEngine.Events;

namespace MemoryMatch.Core.ApplicationStates.ControllerInterfaces
{
    public interface ICardControllable
    {
        UnityAction OnAllCardFliped { get; set; }

        void GenerateCards();
    }
}