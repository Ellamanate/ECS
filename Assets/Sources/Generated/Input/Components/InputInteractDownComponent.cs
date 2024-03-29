//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly LamaGamma.Components.InteractDown interactDownComponent = new LamaGamma.Components.InteractDown();

    public bool isInteractDown {
        get { return HasComponent(InputComponentsLookup.InteractDown); }
        set {
            if (value != isInteractDown) {
                var index = InputComponentsLookup.InteractDown;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : interactDownComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInteractDown;

    public static Entitas.IMatcher<InputEntity> InteractDown {
        get {
            if (_matcherInteractDown == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InteractDown);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInteractDown = matcher;
            }

            return _matcherInteractDown;
        }
    }
}
