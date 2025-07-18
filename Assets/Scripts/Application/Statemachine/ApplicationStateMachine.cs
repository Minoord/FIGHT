using MarkUlrich.GenericStateMachine;
using MarkUlrich.GenericStateMachine.Sample;
using MarkUlrich.GenericStateMachine.Sample.States;
using UnityEngine.SceneManagement;

namespace Application.Statemachine
{
    public class ApplicationStateMachine : StateMachineBehaviour
    {
        protected override void SetInitialState()
        {
            StateMachine.SetState<ExampleBootState>();
        }
    }
}
