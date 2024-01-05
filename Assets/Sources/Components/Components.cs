using Entitas;
using Entitas.CodeGeneration.Attributes;
using LamaGamma.Services;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace LamaGamma.Components
{
    [Unique, Input] public class Input : IComponent { }
    [Unique, Input] public class InputService : IComponent { public Services.InputService Value; }
    [Input] public class Movement : IComponent { public Vector2 Value; }
    [Input] public class LookAt : IComponent { public Vector2 Value; }
    [Input] public class InteractDown : IComponent { }

    [Gameplay, Event(Self)] public class Health : IComponent { public float Value; }
    [Gameplay, Event(Self)] public class Rotation : IComponent { public Quaternion Value; }
    [Gameplay, Event(Self)] public class Position : IComponent { public Vector3 Value; }
    [Gameplay, Event(Self)] public class Destructed : IComponent { }
    [Gameplay, Event(Self)] public class Interactable : IComponent { }

    [Gameplay] public class Id : IComponent {[PrimaryEntityIndex] public int Value; }
    [Gameplay] public class InSightId : IComponent {[EntityIndex] public int Value; }

    [Gameplay] public class Rigidbody : IComponent { public UnityEngine.Rigidbody Value; }

    [Gameplay] public class Player : IComponent { }

    [Gameplay] public class MoveSpeed : IComponent { public float Value; }
    [Gameplay] public class RotationSpeed : IComponent { public float Value; }
    [Gameplay] public class RotationAngle : IComponent { public Vector2 Value; }
    [Gameplay] public class Borders : IComponent { public ViewBorders Value; }
    [Gameplay] public class Raycasting : IComponent { public RaycastSettings Value; }
    [Gameplay] public class SmoothingRotation : IComponent { public Smooth<Vector2> Value; }

    [Unique, GameState] public class State : IComponent { }
    [GameState, Event(Self)] public class Window : IComponent { public WindowType Value; }
    [GameState, Event(Self)] public class CanInteract : IComponent { public bool Value; }
    [GameState] public class PlayerAlive : IComponent { }
    [GameState] public class Pause : IComponent { }

    [UI, Event(Self)] public class WindowFade : IComponent { public float Value; }
    [UI, Event(Self)] public class InteractButtonFade : IComponent { public float Value; }
}
