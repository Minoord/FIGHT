using Application.Statemachine.States;
using UnityEngine;
using StateMachineBehaviour = MarkUlrich.GenericStateMachine.StateMachineBehaviour;

namespace Application.Statemachine
{
    public class ApplicationStateMachine : StateMachineBehaviour
    {
        protected override void SetInitialState()
        {
            if (PlayerPrefs.HasKey("Active"))
            {
                UnityEngine.Application.Quit();
                return;
            }
            
            if (!PlayerPrefs.HasKey("StoryMode"))
            {
                PlayerPrefs.SetInt("StoryMode", 1);
            }
            StateMachine.SetState<BootState>();
        }
    }
}
