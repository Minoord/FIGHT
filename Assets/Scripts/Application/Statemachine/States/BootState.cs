using MarkUlrich.GenericStateMachine;
using UnityEngine.SceneManagement;

namespace Application.Statemachine.States
{
    public class BootState : State
    {
        private const string _loadSceneName = "Boot";

        public override void Enter()
        {
           SetNextState<MainMenuState>();
            
           MoveToNextState();
        }

        public override void Exit()
        {
            SceneManager.UnloadSceneAsync(_loadSceneName);
        }
    }
}