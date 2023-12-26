using UnityEngine;

namespace Generic
{

    //  ジェネリッククラス
    public class GenericClass<T>
    {
        // Tに制約が全くない場合はほぼ使い物にならない
        // こうやって定義しますよという例
        public T Value { get;}
        public GenericClass(T value)
        {
            Value = value;
        }
    }
    
    // ジェネリックインターフェイス
    public interface IGenericInterface<out T>   // covariantとしてoutを使うことができる
    {
        T Value { get; }
    }
    
    public interface IGenericInterface2<in T>   // contravariantとしてinを使うことができる
    {
        void SetValue(T value);
    }
    
    public interface IGenericInterface3<T>   // 両方使うこともできる
    {
        T CalcValue(T value);
    }
    
    public class GenericClassNeo<T> : IGenericInterface<T>
    {
        public T Value { get; }
        public GenericClassNeo(T value)
        {
            Value = value;
        }
    }
    
    // ジェネリックメソッド
    public class GenericMethod
    {
        // こうやって定義しますよという例
        public T Identity<T>(T value)
        {
            return value;
        }
    }
    
}