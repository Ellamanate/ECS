using Sirenix.OdinInspector;
using UnityEngine;

namespace LamaGamma.Services
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/CameraConfig")]
	public class CameraConfig : ScriptableObject
	{
		[field: SerializeField] public ViewBorders Borders { get; private set; }
		[field: SerializeField] public float CameraSpeed { get; private set; } = 0.25f;
		[field: SerializeField] public bool SmoothCameraRotation { get; private set; } = false;

		[field: SerializeField, ShowIf(nameof(SmoothCameraRotation)), Range(0f, 50)] 
		public float CameraSmoothingFactor { get; private set; } = 25f;
	}
}
