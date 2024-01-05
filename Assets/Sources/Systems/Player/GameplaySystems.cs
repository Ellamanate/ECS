using LamaGamma.Infrastructure;

namespace LamaGamma.Systems
{
    public class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts contexts, MainGameServices services)
            : base(nameof(GameplaySystems))
        {
            Add(new PlayerRotationSystem(contexts));
            Add(new PlayerMoveSystem(contexts));
            Add(new RaycastSystem(contexts, services));
            Add(new InteractSystem(contexts, services));
        }
    }
}
