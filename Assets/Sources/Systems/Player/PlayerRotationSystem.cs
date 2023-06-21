﻿using Entitas;
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
			_inputs = _contexts.input.GetGroup(InputMatcher.AllOf(InputMatcher.Input));
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
            Smooth(input, player, out float newHorizontalInput, out float newVerticalInput);

            float currentXAngle = player.rotationAngle.Value.x;
            float currentYAngle = player.rotationAngle.Value.y;
            float speed = player.hasRotationSpeed ? player.rotationSpeed.Value : 1;

            currentXAngle += newHorizontalInput * speed;
            currentYAngle -= newVerticalInput * speed;

            CalculateBorders(player, ref currentXAngle, ref currentYAngle);

            var angle = new Vector2(currentXAngle, currentYAngle);
            var rotation = Quaternion.Euler(new Vector2(angle.y, angle.x));

            player.ReplaceRotationAngle(angle);
            player.ReplaceRotation(rotation);
        }

        private void Smooth(InputEntity input, GameEntity player, out float newHorizontalInput, out float newVerticalInput)
        {
            newHorizontalInput = input.lookAt.Value.x;
            newVerticalInput = input.lookAt.Value.y;

            if (player.hasSmoothingRotation)
            {
                var smoothingFactor = player.smoothingRotation.Value;

                if (smoothingFactor.SmoothFactor != 0)
                {
                    float oldHorizontalInput = smoothingFactor.SmoothValue.x;
                    float oldVerticalInput = smoothingFactor.SmoothValue.y;

                    newHorizontalInput = Mathf.Lerp(oldHorizontalInput, newHorizontalInput, Time.deltaTime / smoothingFactor.SmoothFactor);
                    newVerticalInput = Mathf.Lerp(oldVerticalInput, newVerticalInput, Time.deltaTime / smoothingFactor.SmoothFactor);

                    player.ReplaceSmoothingRotation(new SmoothVector3
                    {
                        SmoothFactor = smoothingFactor.SmoothFactor,
                        SmoothValue = new Vector3(newHorizontalInput, newVerticalInput, 0)
                    });
                }
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
