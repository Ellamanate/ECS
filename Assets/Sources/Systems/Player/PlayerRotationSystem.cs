using Entitas;
using LamaGamma.Services;
using UnityEngine;

namespace LamaGamma.Systems
{
    public class PlayerRotationSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _inputs;

        public PlayerRotationSystem(Contexts contexts)
        {
            _contexts = contexts;
            _players = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
			_inputs = _contexts.input.GetGroup(InputMatcher.AllOf(InputMatcher.Keyboard));
		}

        public void Execute()
        {
			foreach (var input in _inputs)
			foreach (var player in _players)
            {
                if (player.hasRotationAngle)
                    CalculateRotationAngle(input, player);
            }
        }

        private void CalculateRotationAngle(InputEntity input, GameEntity player)
        {
            float newHorizontalInput = input.lookAt.Value.x;
            float newVerticalInput = input.lookAt.Value.y;
            float currentXAngle = player.rotationAngle.Value.x;
            float currentYAngle = player.rotationAngle.Value.y;
            float speed = player.hasSpeed ? player.speed.Value : 1;

            Smooth(input, player, ref newHorizontalInput, ref newVerticalInput);

            currentXAngle += newHorizontalInput * speed;
            currentYAngle -= newVerticalInput * speed;

            CalculateBorders(player, ref currentXAngle, ref currentYAngle);

            var angle = new Vector2(currentXAngle, currentYAngle);
            var rotation = Quaternion.Euler(new Vector2(angle.y, angle.x));

            player.ReplaceRotationAngle(angle);
            player.ReplaceRotation(rotation);
        }

        private void Smooth(InputEntity input, GameEntity player, ref float newHorizontalInput, ref float newVerticalInput)
        {
            if (player.hasSmoothingFactor && input.hasPreviousLookAt)
            {
                float oldHorizontalInput = input.previousLookAt.Value.x;
                float oldVerticalInput = input.previousLookAt.Value.y;
                float smoothingFactor = player.smoothingFactor.Value;
                newHorizontalInput = Mathf.Lerp(oldHorizontalInput, newHorizontalInput, Time.deltaTime * smoothingFactor);
                newVerticalInput = Mathf.Lerp(oldVerticalInput, newVerticalInput, Time.deltaTime * smoothingFactor);
            }
        }

        private void CalculateBorders(GameEntity player, ref float currentXAngle, ref float currentYAngle)
        {
            if (player.hasBorders)
            {
                var borders = player.borders.Value;
                CalculateHorizontalLimit(borders, ref currentXAngle);
                currentYAngle = Mathf.Clamp(currentYAngle, -borders.UpperVerticalLimit, borders.LowerVerticalLimit);
            }
            else
            {
                currentYAngle = Mathf.Clamp(currentYAngle, -180, 180);
            }
        }

        private void CalculateHorizontalLimit(ViewBorders borders, ref float currentXAngle)
		{
			float maxHorizontalAngle = 180 + borders.AngleXOrigin;
			float minHorizontalAngle = -180 + borders.AngleXOrigin;

			if (currentXAngle > maxHorizontalAngle)
			{
				currentXAngle = minHorizontalAngle + currentXAngle % 180;
			}
			else if (currentXAngle < minHorizontalAngle)
			{
				currentXAngle = maxHorizontalAngle + currentXAngle % 180;
			}

			currentXAngle = Mathf.Clamp(currentXAngle, -borders.LeftHorizontalLimit + borders.AngleXOrigin,
				borders.RightHorizontalLimit + borders.AngleXOrigin);
		}
	}
}
