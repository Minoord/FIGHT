using MarkUlrich.GenericStateMachine;
using UnityEngine.SceneManagement;

namespace Application.Statemachine.States
{
    public class Phase1State : State
    {
        private const string _loadSceneName = "Phase1";
        
        public override void Enter()
        {
           SceneManager.LoadSceneAsync(_loadSceneName);
        }

        public override void Exit()
        {
         
        }
    }
}