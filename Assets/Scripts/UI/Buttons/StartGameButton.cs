using Application.Statemachine;
using UnityEngine;

namespace UI.Buttons
{
    public class StartGameButton : MonoBehaviour
    {
        public void StartGame()
        {
           ApplicationStateMachine.Instance.StateMachine.MoveToNextState();
        }
    }
}
