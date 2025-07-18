using MarkUlrich.GenericStateMachine;
using UnityEngine.SceneManagement;

namespace Application.Statemachine.States
{
    public class Phase2State : State
    {
        private const string _loadSceneName = "Phase2";
        private const string _previousLoadSceneName = "Phase1";
        
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