using UnityEngine;
using UnityEngine.Assertions;

namespace InterfaceSegregationPrinciple
{
    namespace EaseOfTesting1
    {
        class BeforeMetalSlime
        {
            public double Hp { get; private set; }
            public BeforeMetalSlime(double maxHp)
            {
                Hp = maxHp;
            }
            public void OnAttack(DamageObject damage)
            {
                // メタルスライムのダメージ計算を行う
                if (damage.IsCritical)
                {
                    Hp -= damage.Damage * 2;
                }
                else
                {
                    Hp -= 1;
                }
                
                // 乱数で90%の確率で逃げる
                if (Random.Range(0, 100) < 90)
                {
                    RunAway();
                }
            }
            
            void RunAway()
            {
                // 逃げる処理
            }
        }
        
        /// //////////////////////////////////////////////////////////
        
        // すぐに逃げてしまってまともにテストできない
        // ダメージ計算のロジックを別のクラスに分けて、そのクラスをテストするようにする
        class AfterMetalSlime : IOnAttack
        {
            readonly MetalSlimeOnAttack _onAttack;
            public AfterMetalSlime(MetalSlimeOnAttack onAttack)
            {
                _onAttack = onAttack;
            }
            public void OnAttack(DamageObject damage)
            {
                _onAttack.OnAttack(damage);
                
                // 乱数で90%の確率で逃げる
                if (Random.Range(0, 100) < 90)
                {
                    RunAway();
                }
            }
            
            void RunAway()
            {
                // 逃げる処理
            }
        }
        
        class MetalSlimeOnAttack : IOnAttack
        {
            public double Hp { get; private set; } = 10;
            public MetalSlimeOnAttack(double maxHp)
            {
                Hp = maxHp;
            }
            public void OnAttack(DamageObject damage)
            {
                // メタルスライムのダメージ計算を行う
                if (damage.IsCritical)
                {
                    Hp -= damage.Damage * 2;
                }
                else
                {
                    Hp -= 1;
                }
            }
        }
        
        class MetalSlimeTest
        {
            public void ProbablyFailTest()
            {
                var metalSlime = new BeforeMetalSlime(100);
                var damage = new DamageObject(10, false);
                metalSlime.OnAttack(damage);
                Assert.AreEqual(90, metalSlime.Hp);
                // 逃げる処理があるため、テストが難しい
            }

            public void GoodTest()
            {
                var metalSlime = new MetalSlimeOnAttack(100);
                var damage = new DamageObject(10, false);
                metalSlime.OnAttack(damage);
                Assert.AreEqual(90, metalSlime.Hp);
                // MetalSlimeOnAttackは簡単にテストすることができる。
                // AfterMetalSlimeはダメージ計算をMetalSlimeOnAttackに委譲しているので、
                // MetalSlimeOnAttackのテストを行うことで、間接的に正しさを保証できる。
                // なお、IOnAttackで受け取るようにすると、いろんなダメージ計算を実装するMetalSlimeインスタンスを作成できるようになる。
            }
        }
        

        interface IOnAttack
        {
            void OnAttack(DamageObject damage);
        }
        
        class DamageObject
        {
            public double Damage { get; }
            public bool IsCritical { get; }
            public DamageObject(double damage, bool isCritical)
            {
                Damage = damage;
                IsCritical = isCritical;
            }
        }
    }

}