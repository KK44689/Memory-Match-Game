using UnityEngine;

namespace MemoryMatch.Core.ApplicationStates
{
    public abstract class BaseApplicationState
    {
        public BaseApplicationState(AppStateManager manager)
        {
            m_AppStateManager = manager;
        }

        public abstract int ID { get; }

        public abstract string Name { get; }

        protected AppStateManager m_AppStateManager;

        public abstract void StateIn(params object[] args);

        public abstract void StateOut();
    }
}