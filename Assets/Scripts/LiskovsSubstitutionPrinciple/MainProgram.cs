using System;
using UnityEditorInternal;
using UnityEngine;

namespace LiskovsSubstitutionPrinciple
{
    public class MainProgram : MonoBehaviour
    {
        Hero _baseHero;
        IHpSetter _target;
        
        
        void Start()
        {
            _baseHero = new Hero(new BaseAttack());
            _target = new Sandbag();
            

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _baseHero.Attack(_target);
            }
        }
    }
    
}