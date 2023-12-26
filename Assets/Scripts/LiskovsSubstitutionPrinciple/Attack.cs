using System;
using UnityEngine;
using UnityEngine.Assertions;
using Object = System.Object;

namespace LiskovsSubstitutionPrinciple
{
    public class BaseAttack 
    {
        public virtual void OnAttack(IHpSetter hpSetter, int baseDamage)
        {
            // precondition
            Assert.IsTrue(baseDamage > 0);
            
            hpSetter.Hp = Math.Max(hpSetter.Hp - baseDamage, 0);
            
            // postcondition
            Assert.IsTrue(hpSetter.Hp >= 0);
        }
    }

    public class DoubleAttack : BaseAttack
    {
        public override void OnAttack(IHpSetter hpSetter, int baseDamage)
        {
            // precondition
            Assert.IsTrue(baseDamage > 0);
            
            hpSetter.Hp = Math.Max(hpSetter.Hp - baseDamage * 2, 0);
            
            // postcondition
            Assert.IsTrue(hpSetter.Hp >= 0);
        }
    }

    // Hpが0以下になる攻撃
    // 事後条件の緩和してしまっているためLSP違反
    public class OverKillAttack : BaseAttack
    {
        public override void OnAttack(IHpSetter hpSetter, int baseDamage)
        {
            // precondition
            Assert.IsTrue(baseDamage > 0);
            
            hpSetter.Hp = hpSetter.Hp - baseDamage ;
            
            // postcondition
            // なし
        }
    }

    // 100以上のダメージでないとターゲットのHPを減らせない攻撃
    // 事前条件の強化してしまっているためLSP違反
    public class SlowAttack : BaseAttack
    {
        public override void OnAttack(IHpSetter hpSetter, int baseDamage)
        {
            // precondition
            Assert.IsTrue(baseDamage >= 100);
            
            hpSetter.Hp = hpSetter.Hp - baseDamage ;  // 引き算のままに注意
            
            // postcondition
            Assert.IsTrue(hpSetter.Hp >= 0);
        }
    }
    
    // 今回の場合は、BaseAttackを拡張していくのではなく、
    // インターフェイスIOnAttackを作っていくべき。
    // そうすれば、事前条件、事後条件などを考慮する必要がない

    public class Test
    {
        void test()
        {
            Action<System.Object> objAction = x => { Debug.Log(x.ToString());};
            Action<string> strAction = x => { Debug.Log(x);};
            strAction = objAction;  // エラー
            
      
        }
    }


    

}