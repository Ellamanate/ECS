using Entitas;
using UnityEngine;

namespace LamaGamma.Systems
{
    public class PlayerMoveSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _inputs;

        public PlayerMoveSystem(Contexts contexts)
        {
            _contexts = contexts;
            _players = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
            _inputs = _contexts.input.GetGroup(InputMatcher.AllOf(InputMatcher.Keyboard));
        }

        public void Execute()
        {
            foreach (var input in _inputs) 
            {
                foreach (var player in _players)
                {
                    if (player.hasRigidbody)
                    {
                        player.rigidbody.Value.position += (Vector3)input.movement.Value;
                        player.rigidbody.Value.rotation 
                            = Quaternion.Euler(player.rigidbody.Value.rotation.eulerAngles + (Vector3)input.lookAt.Value);
                    }
                }
            }
        }
    }
}
