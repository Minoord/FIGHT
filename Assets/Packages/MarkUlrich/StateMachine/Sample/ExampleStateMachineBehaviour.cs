using MarkUlrich.GenericStateMachine.Sample.States;
using UnityEngine;

namespace MarkUlrich.GenericStateMachine.Sample
{
    /// <summary>
    /// This class is purely to demonstrate what you can do with a StateMachineInstance.
    /// </summary>
    public class ExampleStateMachineBehaviour : StateMachineBehaviour
    {
        /// <summary>
        /// Set the initial state of the state machine.
        /// </summary>
        /// <remarks>
        /// This is where you would typically set the first state to be executed.
        /// </remarks>
        protected override void SetInitialState()
        {
            StateMachine.SetState<ExampleBootState>();
        }

        protected override void Awake()
        {
            base.Awake();
            // Your code here.
        }

        private void Start()
        {
            // Example of how to subscribe to a state instance's OnStateEnter event.
            // Also showcases when action is triggered in relation to entering the state.
            StateMachine.GetState<ExampleGameState>().OnStateEnter += DebugStateEnterAction;

            // Example of how to subscribe to a state instance's OnStateExit event.
            // Also showcases when action is triggered in relation to exiting the state.
            StateMachine.GetState<ExampleGameState>().OnStateExit += DebugStateExitAction;
        }

        private void DebugStateEnterAction()
        {
            Debug.Log("<color=purple>OnStateEnter</color> action triggered for <color=cyan>ExampleGameState</color>.");
        }

        private void DebugStateExitAction()
        {
            Debug.Log("<color=purple>OnStateExit</color> action triggered for <color=cyan>ExampleGameState</color>.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                StateMachine.MoveToNextState();

            if (Input.GetKeyDown(KeyCode.I))
                DebugPrintStates();
        }

        private void DebugPrintStates()
        {
            Debug.Log("Currently Subscribed States: ");
            int index = 0;
            foreach (var state in StateMachine.States)
            {
                Debug.Log($"{index} : {state.Name} : {state.GetHashCode()}");
                index++;
            }
        }
    }
}
