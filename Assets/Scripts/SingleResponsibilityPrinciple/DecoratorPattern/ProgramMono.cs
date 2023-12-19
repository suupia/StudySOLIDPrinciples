#nullable enable
using System;
using UnityEngine;

namespace Scripts.DecoratorPattern
{
    public class ProgramMono : MonoBehaviour
    {
        void Start()
        {
            var component = new DecoratorComponent(new ConcreteComponent());
            component.Something();
        }
    }
}