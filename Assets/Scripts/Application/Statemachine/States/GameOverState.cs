using MarkUlrich.GenericStateMachine;
using UnityEngine.SceneManagement;

namespace Application.Statemachine.States
{
    public class GameOverState : State
    {
        private const string _loadSceneName = "GameOver";
        
        public override void Enter()
        {
            SceneManager.LoadSceneAsync(_loadSceneName);
        }
        
        public void UnLoadPreviousStates(string previousLoadSceneName)
        {
            SceneManager.UnloadSceneAsync(previousLoadSceneName);
        }

        public override void Exit()
        {
           
        }
    }
}