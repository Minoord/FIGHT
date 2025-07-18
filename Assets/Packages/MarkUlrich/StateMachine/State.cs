using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MarkUlrich.GenericStateMachine
{
    /// <summary>
    /// Represents a base class for game states in the game state machine.
    /// </summary>
    public abstract class State
    {
        private State _nextState;

        public string Name => GetType().Name;
        public Action OnStateEnter;
        public Action OnStateExit;

        public StateMachine OwningStateMachine { get; set; }

        public void InitState(StateMachine stateMachine)
        {
            OwningStateMachine = stateMachine;
            OwningStateMachine.Subscribe(this);
        }

        public abstract void Enter();

        public abstract void Exit();

        /// <summary>
        /// Executes code related to entering the state and invokes related events.
        /// </summary>
        public void EnterState()
        {
            OnStateEnter?.Invoke();

            OwningStateMachine.DebugLog
            (
                $"<color=cyan>Entering - {Name}({GetHashCode()}) in StateMachine({OwningStateMachine.GetHashCode()})</color>"
            );

            Enter();
        }

        /// <summary>
        /// Executes code related to leaving the state and invokes related events.
        /// </summary>
        public void ExitState()
        {
            OnStateExit?.Invoke();

            OwningStateMachine.DebugLog
            (
                $"<color=orange>Leaving - {Name}({GetHashCode()}) in StateMachine({OwningStateMachine.GetHashCode()})</color>"
            );

            Exit();
        }

        /// <summary>
        /// Triggers the Owning StateMachine to move to the next state.
        /// </summary>
        public void MoveToNextState()
        {
            if (_nextState == null)
            {
                Debug.LogError
                (
                    "Next State variable was not set! Use 'SetNextState<TState>()' to set it. Cancelling..."
                );
                return;
            }

            OwningStateMachine.SetState(_nextState);
        }

        protected void SetNextState<TState>() where TState : State, new()
            => _nextState = OwningStateMachine.GetState<TState>();

        /// <summary>
        /// Loads a scene by name, optionally forcing a reload if the scene is already active.
        /// </summary>
        protected void LoadScene(string sceneName, bool forceReload = false)
        {
            if (forceReload)
            {
                SceneManager.LoadScene(sceneName);
                OwningStateMachine.DebugLog($"Loaded Scene ({sceneName})");
                return;
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(sceneName))
                return;

            SceneManager.LoadScene(sceneName);
            OwningStateMachine.DebugLog($"Loaded Scene ({sceneName})");
        }
    }
}
