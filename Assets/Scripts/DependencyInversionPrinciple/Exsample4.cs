using System;
using LiskovsSubstitutionPrinciple;
using UnityEngine;

namespace DependencyInversionPrinciple
{
    // ドメイン
    public class Hero3
    {
        public int MaxHp { get;}
        public int Hp { get; set; }
        IUpdateHp _bar0;
        
        public Hero3(int maxHp)
        {
            MaxHp = maxHp;
            Hp = maxHp;
            _bar0.UpdateHp(maxHp);
        }
        
        public void SetDamage(double damage)
        {
            Hp -= (int)damage;
            _bar0.UpdateHp(Hp);
        }
    }
    
    // UI
    public interface IHpInfo
    {
        int MaxHp { get; }
        int GetHp { get; }
    }
    public class HpInfo3 : IHpInfo
    {   
        public int MaxHp { get; }
        public int GetHp { get; }
        
        public HpInfo3(Hero3 hero)
        {
            MaxHp = hero.MaxHp;
            GetHp = hero.Hp;
        }
    }
    
    public class HPBar3 : MonoBehaviour
    {
        public int Hp { get; set; }
        UIBar _uiBar;
        HpInfo _hpInfo;
        
        public HPBar3(UIBar uiBar)
        {
            var hero = new Hero3(100);
            var hpInfo = new HpInfo3(hero);
        }
        
        // MonoBehaviourのUpdateメソッドを使ってHPバーを更新する
        void Update()
        {
            // HPバーを更新する処理
            _uiBar.Rate = (float)_hpInfo.GetHp() / 100;
        }

    }
    
    // インターフェイスを利用する例
}