#nullable enable
using UnityEngine;

namespace LiskovsSubstitutionPrinciple
{
    public class Sandbag : IHpSetter
    {
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                Debug.Log($"Sandbag Hp:{_hp}");
            }
        }
        int _hp;
    }
}