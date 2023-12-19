#nullable enable
using System;
using System.Collections.Generic;

namespace Scripts.CompositePattern
{
    public class CompositeComponent : IComponent
    {
        ICollection<IComponent> _children = new List<IComponent>();
        
        public void AddComponent(IComponent component)
        {
            _children.Add(component);
        }
        
        public void RemoveComponent(IComponent component)
        {
            _children.Remove(component);
        }

        public void Something()
        {
            foreach (var child in _children)
            {
                child.Something();
            }
        }
    }
}