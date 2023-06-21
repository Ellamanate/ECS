using System;
using UnityEngine;

namespace LamaGamma.Services
{
    [Serializable]
	public struct ViewBorders
	{
		[SerializeField, Range(0f, 90f)] public float UpperVerticalLimit;
		[SerializeField, Range(0f, 90f)] public float LowerVerticalLimit;
		[SerializeField, Range(0f, 180)] public float LeftHorizontalLimit;
		[SerializeField, Range(0f, 180)] public float RightHorizontalLimit;
		[HideInInspector] public float AngleXOrigin;
	}
}
