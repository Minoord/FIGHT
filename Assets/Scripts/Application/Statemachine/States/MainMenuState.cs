using MarkUlrich.GenericStateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application.Statemachine.States
{
    public class MainMenuState : State 
    {
        private const string _loadSceneName = "MainMenu";

        public override void Enter()
        {
            LoadScene(_loadSceneName);
            
            bool isStoryMode = PlayerPrefs.GetInt("StoryMode") == 1;

            if (isStoryMode)
            {
                SetNextState<Phase1State>();
            }
            else
            {
                SetNextState<EndlessState>();
            }
        }

        public override void Exit()
        {
            SceneManager.UnloadSceneAsync(_loadSceneName);
        }
    }
}