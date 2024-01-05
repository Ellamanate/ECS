using Entitas;
using LamaGamma.Infrastructure;
using System.Collections.Generic;
using UnityEngine;

namespace LamaGamma.Systems
{
    public class InteractSystem : ReactiveSystem<InputEntity>
    {
        private readonly MainGameServices _services;
        private readonly IGroup<GameplayEntity> _players;

        public InteractSystem(Contexts contexts, MainGameServices services) : base(contexts.input)
        {
            _services = services;
            _players = contexts.gameplay.GetGroup(GameplayMatcher.AllOf(GameplayMatcher.Player));
        }

        protected override bool Filter(InputEntity entity) => entity.isInteractDown;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.InteractDown.Added());

        protected override void Execute(List<InputEntity> interactInputs)
        {
            foreach (GameplayEntity player in _players)
            {
                var entity = _services.EntitysRegistrator.Take(player.inSightId.Value);

                if (entity != null && entity.isInteractable) 
                {
                    Debug.Log("Interact");
                }
            }
        }
    }
}
