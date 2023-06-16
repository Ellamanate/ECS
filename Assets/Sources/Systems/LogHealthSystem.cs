using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class LogHealthSystem : ReactiveSystem<GameEntity>
{
    public LogHealthSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Debug.Log(entity.health.Value);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }
}

/*public class LogHealthSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public LogHealthSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.Health);
    }

    public void Execute()
    {
        foreach (var entity in _entities)
        {
            Debug.Log(entity.health.Value);
        }
    }
}*/