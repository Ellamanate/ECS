using Entitas;
using Entitas.CodeGeneration.Attributes;
using LamaGamma.Services;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace LamaGamma.Components
{
    [Unique, Input] public class InputService : IComponent { public Services.InputService Value; }
    [Unique, Input] public class Input : IComponent { }
    [Input] public class Movement : IComponent { public Vector2 Value; }
    [Input] public class LookAt : IComponent { public Vector2 Value; }
    [Input] public class InteractDown : IComponent { }

    [Game, Event(Self)] public class Health : IComponent { public float Value; }
    [Game, Event(Self)] public class Rotation : IComponent { public Quaternion Value; }
    [Game, Event(Self)] public class Position : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class Destructed : IComponent { }
    [Game, Event(Self)] public class Interactable : IComponent { }

    [Game] public class Id : IComponent {[PrimaryEntityIndex] public int Value; }
    [Game] public class InSightId : IComponent {[EntityIndex] public int Value; }

    [Game] public class Rigidbody : IComponent { public UnityEngine.Rigidbody Value; }

    [Game] public class Player : IComponent { }

    [Game] public class MoveSpeed : IComponent { public float Value; }
    [Game] public class RotationSpeed : IComponent { public float Value; }
    [Game] public class RotationAngle : IComponent { public Vector2 Value; }
    [Game] public class Borders : IComponent { public ViewBorders Value; }
    [Game] public class Raycasting : IComponent { public RaycastSettings Value; }
    [Game] public class SmoothingRotation : IComponent { public Smooth<Vector2> Value; }
}
