using MemoryMatch.Models;

namespace MemoryMatch.Core.ApplicationStates
{
    public interface IStateManagable
    {
        void StartLoadScene(StateIndex stateId, params object[] args);
    }
}