using MemoryMatch.Models;

namespace MemoryMatch.Core.ApplicationStates
{
    public interface IStateManagable
    {
        void ChangeStateTo(StateIndex stateId, params object[] args);

        void StartLoadScene(StateIndex stateId, params object[] args);
    }
}