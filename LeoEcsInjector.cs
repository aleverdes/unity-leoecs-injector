using System;
using System.Collections.Generic;
using Leopotam.Ecs;

namespace AffenCode
{
    public static class LeoEcsInjector
    {
        private static readonly Dictionary<Type, object> InjectedObjects = new();
        
        public static void AddInjection(object injectedObject)
        {
            InjectedObjects.Add(injectedObject.GetType(), injectedObject);
        }

        public static void RemoveInjection(object injectedObject)
        {
            InjectedObjects.Remove(injectedObject.GetType());
        }

        public static EcsSystems InjectData(this EcsSystems ecsSystems)
        {
            foreach (var injectedObject in InjectedObjects)
            {
                if (injectedObject.Value != null)
                {
                    ecsSystems.Inject(injectedObject.Value);
                }
            }

            return ecsSystems;
        }
    }
}