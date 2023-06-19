using Entitas;
using Entitas.CodeGeneration.Attributes;
using LamaGamma.Services;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace LamaGamma.Components
{
    [Unique, Input] public class Input : IComponent { public IInputService Value; }
    [Unique, Input] public class Keyboard : IComponent { }

    [Game, Event(Self)] public class Health : IComponent { public float Value; }
    [Game, Event(Self)] public class Rotation : IComponent { public Quaternion Value; }
    [Game, Event(Self)] public class Position : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class Destructed : IComponent { }

    [Game] public class Rigidbody : IComponent { public UnityEngine.Rigidbody Value; }

    [Game] public class Player : IComponent { }

    [Input] public class Movement : IComponent { public Vector2 Value; }
    [Input] public class LookAt : IComponent { public Vector2 Value; }
}
