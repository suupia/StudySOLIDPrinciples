#nullable enable
using UnityEngine;

namespace InterfaceSegregationPrinciple
{
    namespace Flexibility
    {
        static class GameSystem
        {
            public static GameObject GetTarget()
            {
                // 適当です
                return new GameObject();
            }
        }

        //  インターフェイスを使用しないパターン
        class CharacterWithNoInterface
        {
            public void Attack()
            {
                var targetObject = GameSystem.GetTarget();
                if (targetObject.TryGetComponent(out Slime slime))
                {
                    // スライムに攻撃
                }
                else if (targetObject.TryGetComponent(out Goblin goblin))
                {
                    // ゴブリンに攻撃
                }
                // （ここにBatの処理を新しく追加する必要がある）
            }
        }

        class CharacterWithInterface
        {
            public void Attack()
            {
                var targetObject = GameSystem.GetTarget();
                if (targetObject.TryGetComponent(out IOnAttack targetOnAttack))
                {
                    targetOnAttack.OnAttack();
                }
                //  （たとえBatが追加されても、IOnAttackを実装していればこのクラスは変更する必要がない）
            }
        }

        interface IOnAttack
        {
            void OnAttack();
        }

        class Slime : IOnAttack
        {
            public void OnAttack()
            {
                // スライムのダメージ計算を行う
            }
        }

        class Goblin : IOnAttack
        {
            public void OnAttack()
            {
                // ゴブリンのダメージ計算を行う
            }
        }
    }
}