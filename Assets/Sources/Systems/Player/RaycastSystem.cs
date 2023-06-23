using Entitas;
using LamaGamma.Infrastructure;

namespace LamaGamma.Systems
{
    public class RaycastSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly MainGameServices _services;
        private readonly IGroup<GameEntity> _players;

        public RaycastSystem(Contexts contexts, MainGameServices services)
        {
            _contexts = contexts;
            _services = services;
            _players = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
        }

        public void Execute()
        {
            foreach (var player in _players)
            {
                if (player.hasRaycasting 
                    && player.hasInSightId
                    && _services.PhysicsService.RaycastFromCamera(player.raycasting.Value, out var hit))
                {
                    var view = _services.ViewsRegistrator.Take(hit.collider.gameObject.GetInstanceID());
                    player.ReplaceInSightId(view != null ? view.LinkedEntity.id.Value : -1);
                }
                else
                {
                    player.ReplaceInSightId(-1);
                }
            }
        }
    }
}
