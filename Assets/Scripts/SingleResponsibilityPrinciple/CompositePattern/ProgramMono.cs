#nullable enable
using System;
using UnityEngine;

namespace Scripts.CompositePattern
{
    public class ProgramMono : MonoBehaviour
    {
        IComponent _component;
        void Start()
        {
            CompositeComponent composite = new CompositeComponent();
            composite.AddComponent(new Leaf());
            composite.AddComponent(new SecondTypeOfLeaf());
            composite.AddComponent(new Leaf());
            
            _component = composite;
            // _component.Something();
        }
        
        void Update()
        {
            // ここでは_componentはIComponentとしてか見えない！
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _component.Something();
            }
        }
        
    }
    
}