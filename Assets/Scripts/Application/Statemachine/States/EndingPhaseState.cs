using MarkUlrich.GenericStateMachine;
using UnityEngine.SceneManagement;

namespace Application.Statemachine.States
{
    public class EndingPhaseState : State
    {
        private const string _loadSceneName = "EndingPhase";
        private const string _previousLoadSceneName = "Phase2";
        
        public override void Enter()
        {
            SceneManager.LoadSceneAsync(_loadSceneName);
        }
        
        public void UnLoadPreviousStates()
        {
            SceneManager.UnloadSceneAsync(_previousLoadSceneName);
        }

        public override void Exit()
        {
           
        }
    }
}