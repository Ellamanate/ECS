using Entitas;
using LamaGamma.Infrastructure;

namespace LamaGamma.Systems
{
    public class RaycastSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly MainGameServices _services;
        private readonly GameStateEntity _stateEntity;
        private readonly IGroup<GameplayEntity> _players;

        public RaycastSystem(Contexts contexts, MainGameServices services)
        {
            _contexts = contexts;
            _services = services;
            _stateEntity = contexts.gameState.stateEntity;
            _players = _contexts.gameplay.GetGroup(GameplayMatcher.AllOf(GameplayMatcher.Player));
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

                    if (view != null)
                    {
                        player.ReplaceInSightId(view.LinkedEntity.id.Value);

                        bool canInteract = view.LinkedEntity.isInteractable;

                        if (_stateEntity.hasCanInteract && _stateEntity.canInteract.Value != canInteract)
                        {
                            _stateEntity.ReplaceCanInteract(canInteract);
                        }

                        continue;
                    }
                }

                player.ReplaceInSightId(-1);

                if (_stateEntity.hasCanInteract && _stateEntity.canInteract.Value)
                {
                    _stateEntity.ReplaceCanInteract(false);
                }
            }
        }
    }
}
