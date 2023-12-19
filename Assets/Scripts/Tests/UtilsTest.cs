using System.Collections;
using System.Collections.Generic;
using Generic;
using NUnit.Framework;
using UnityEngine;

public class UtilsTest
{
    [Test]
    public void BeforeUtilsTest()
    {
        double d1 = 4;
        double d2 = 5;
        double dMax = BeforeUtils<double>.Max(d1, d2);
        Assert.That(dMax, Is.EqualTo(5));

        string foo = "foo";
        string bar = "bar";
        string sMax = BeforeUtils<string>.Max(foo, bar);
        Assert.That(sMax, Is.EqualTo("foo"));
    }
    
    [Test]
    public void AfterUtilsTest()
    {
        double d1 = 4;
        double d2 = 5;
        double dMax = AfterUtils.Max(d1, d2);  // doubleと指定する必要がない！
        Assert.That(dMax, Is.EqualTo(5));
　
        string foo = "foo";
        string bar = "bar";
        string sMax = AfterUtils.Max(foo, bar);
        Assert.That(sMax, Is.EqualTo("foo"));

        double? d3 = 12;
        double? d4 = null;
        double? dMax2 = AfterUtils.Max(d3, d4);
        Assert.That(dMax2, Is.EqualTo(12));
        
        
        // 型をクライアント側で指定しなければならない場合
        // 機能を改善したメソッドを追加しても使ってもらえない可能性がある。
        // （型を指定するのが面倒だから）
    }
}
