using Rewired;
using UnityEngine;
using Zenject;

namespace LamaGamma.Services
{
    public class InputService : IInitializable
    {
        private Player _player;

        public bool Initialized { get; private set; }

        public InputService()
        {

        }

        public Vector2 Movement => new Vector3(_player.GetAxis("MoveSide"), _player.GetAxis("MoveForward"));
        public Vector2 LookAt => new Vector2(_player.GetAxis("LookHorizontal"), _player.GetAxis("LookVertical"));

        public void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;
                _player = ReInput.players.GetPlayer(0);

                _player.AddInputEventDelegate(OnCrouchButtonDown, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, "Crouch");
                _player.AddInputEventDelegate(OnPauseButtonDown, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, "Pause");
                _player.AddInputEventDelegate(OnInteractionButtonDown, UpdateLoopType.Update, InputActionEventType.ButtonJustPressed, "Interaction");
            }
        }

        private void OnInteractionButtonDown(InputActionEventData obj)
        {
            
        }

        private void OnPauseButtonDown(InputActionEventData obj)
        {
            
        }

        private void OnCrouchButtonDown(InputActionEventData obj)
        {
            
        }
    }
}
