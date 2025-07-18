using MarkUlrich.Utils;
using UnityEngine;

namespace MarkUlrich.GenericStateMachine
{
    public abstract class StateMachineBehaviour : SingletonInstance<StateMachineBehaviour>
    {
        [SerializeField] private bool _debugMode = true;

        public bool DebugMode
        {
            get => _debugMode;
            private set
            {
                _debugMode = value;
                StateMachine.DebugMode = value;
            }
        }

        public StateMachine StateMachine { get; private set; } = new();

        public StateMachineBehaviour() => StateMachine.Instance = this;

        /// <summary>
        /// Set the initial state of the state machine.
        /// </summary>
        /// <remarks>
        /// This is where you would typically set the first state to be executed.
        /// </remarks>
        protected abstract void SetInitialState();

        protected virtual void Awake() => SetInitialState();
    }
}
