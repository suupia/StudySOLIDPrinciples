using System.Collections;
using System.Collections.Generic;

namespace Generic
{
    // Effective C# p106
    public static class BeforeUtils<T>
    {
        public static T Max(T left, T right) =>
            Comparer<T>.Default.Compare(left, right) < 0 ? right : left;

        public static T Min(T left, T right) =>
            Comparer<T>.Default.Compare(left, right) < 0 ? left : right;
    }
    
    // BeforeUtilsのデメリット
    // メソッドを呼び出すために、毎回型を指定する必要がある
    // これはジェネリッククラスとして作成したから
    // また、組み込み型の多くには、既に定義されたMaxとMinがあるがある。
    //  例えば、数値型にはMath.Max()とMath.Min()がある。
    //　このジェネリッククラスでは、これらの代わりにComparer<T>で実装されたバージョンが常に使用される
    //  この方法だと、実行時の型がIComparer<T>を実装しているかどうかを実行時に確認して、
    //  適切なメソッドを呼び出すという余計な手間がかかる
    
    
    //  自動的に最適なメソッドが呼ばれるようにしたい！
    //  非ジェネリッククラスでジェネリックメソッドを定義することで実装できる
    public static class AfterUtils
    {
        public static T Max<T>(T left, T right) =>
            Comparer<T>.Default.Compare(left, right) < 0 ? right : left;
        
        public static double Max(double left, double right) =>
            System.Math.Max(left, right);
        // その他の数値型に対応するバージョンは省略

        public static T Min<T>(T left, T right) =>
            Comparer<T>.Default.Compare(left, right) < 0 ? left : right;
        
        public static double Min(double left, double right) =>
            System.Math.Min(left, right);
        // その他の数値型に対応するバージョンは省略
    }
    
    
    //  ジェネリッククラスとジェネリックメソッドのどちらを使用すればよいかの指針
    //  ・型パラメータの値をクラスの内部状態として保持するかどうか（コレクションクラスなどがこれにあたる）
    //  ・ジェネリックインターフェイスを実装する型かどうか
    //  これらの2つに該当しない場合は、非ジェネリッククラスのジェネリックメソッドを定義するとよい
    
}