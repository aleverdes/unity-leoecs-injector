# LeoECS Injector
Simple Injector for LeoECS

# Usage

```csharp
using AffenCode;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        LeoEcsInjector.AddInjection(this);
    }

    private void OnDestroy()
    {
        LeoEcsInjector.RemoveInjection(this);
    }

    public void DebugLog()
    {
        Debug.Log("test");
    }
}
```

In ECS Startup

```csharp
using AffenCode;
using Leopotam.Ecs;
...
_updateSystems = new EcsSystems(world);
_updateSystems
    .AddUpdatePlayerSystems()
    .InjectData() // this
    .Init();
```

In ECS System

```csharp

    public class CollectSystem : IEcsRunSystem
    {
        private LevelManager _levelManager;
        private EcsFilter<Collectable, EcsTransform> _collectableFilter;

        public void Run()
        {
            _levelManager.DebugLog();
        }
    }
```
