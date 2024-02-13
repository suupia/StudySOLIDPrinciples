using System;
using UnityEngine;

namespace DependencyInversionPrinciple
{
    // ドメイン
    public class Hero2
    {
        public int MaxHp { get;}
        public int Hp { get; set; }
        
        public Hero2(int maxHp)
        {
            MaxHp = maxHp;
            Hp = maxHp;
        }
        
        public void SetDamage(double damage)
        {
            Hp -= (int)damage;
        }
    }
    
    // UI
    public class HpInfo
    {   
        public Func<int> MaxHp = () => 0;
        public Func<int> GetHp = () => 0;
    }
    
    public class HPBar2 : MonoBehaviour
    {
        public int Hp { get; set; }
        UIBar _uiBar;
        HpInfo _hpInfo;
        
        public HPBar2(UIBar uiBar)
        {
            var hero = new Hero2(100);
            var hpInfo = new HpInfo()
            {
                MaxHp = () => hero.MaxHp,
                GetHp = () => hero.Hp
            };
        }
        
        // MonoBehaviourのUpdateメソッドを使ってHPバーを更新する
        void Update()
        {
            // HPバーを更新する処理
            _uiBar.Rate = (float)_hpInfo.GetHp() / 100;
        }

    }

    public class UIBar
    {
        public float Rate;
    }
    
    // Funcを利用する例
}