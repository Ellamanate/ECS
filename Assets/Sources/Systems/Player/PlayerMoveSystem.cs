using Entitas;
using LamaGamma.Utils;
using UnityEngine;

namespace LamaGamma.Systems
{
    public class PlayerMoveSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameplayEntity> _players;
        private readonly IGroup<InputEntity> _inputs;

        public PlayerMoveSystem(Contexts contexts)
        {
            _contexts = contexts;
            _players = _contexts.gameplay.GetGroup(GameplayMatcher.AllOf(GameplayMatcher.Player));
            _inputs = _contexts.input.GetGroup(InputMatcher.AllOf(InputMatcher.Input));
        }

        public void Execute()
        {
            foreach (var player in _players)
            foreach (var input in _inputs)
            {
                if (player.hasRigidbody)
                {
                    var inputDirection = new Vector3(input.movement.Value.x, 0, input.movement.Value.y);
                    var rotation = player.hasRotation ? Quaternion.Euler(0, player.rotation.Value.eulerAngles.y, 0) : Quaternion.identity;
                    float speed = player.hasMoveSpeed ? player.moveSpeed.Value : 1;
                    player.rigidbody.Value.velocity = (rotation * inputDirection * speed)
                        .ChangeY(player.rigidbody.Value.velocity.y);
                }

                player.ReplacePosition(player.rigidbody.Value.position);
            }
        }
	}
}
