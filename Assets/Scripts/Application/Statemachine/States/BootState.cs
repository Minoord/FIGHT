using MarkUlrich.GenericStateMachine;
using UnityEngine.SceneManagement;

namespace Application.Statemachine.States
{
    public class BootState : State
    {
        private const string _loadSceneName = "MainMenu";

        public override void Enter()
        {
            SetNextState<Phase1State>();
            LoadScene(_loadSceneName);
        }

        public override void Exit()
        {
            SceneManager.UnloadSceneAsync(_loadSceneName);
        }
    }
}