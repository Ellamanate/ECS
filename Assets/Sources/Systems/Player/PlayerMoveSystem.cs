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
            _inputs = _contexts.input.GetGroup(InputMatcher.AllOf(InputMatcher.Input));
        }

        public void Execute()
        {
            foreach (var player in _players)
            foreach (var input in _inputs)
            {
                if (player.hasRigidbody)
                {
                    var inputDirection = new Vector3(input.movement.Value.x, player.rigidbody.Value.velocity.y, input.movement.Value.y);
                    var rotation = player.hasRotation ? Quaternion.Euler(0, player.rotation.Value.eulerAngles.y, 0) : Quaternion.identity;
                    float speed = player.hasMoveSpeed ? player.moveSpeed.Value : 1;
                    player.rigidbody.Value.velocity = rotation * inputDirection * speed;
                }

                player.ReplacePosition(player.rigidbody.Value.position);
            }
        }
	}
}
