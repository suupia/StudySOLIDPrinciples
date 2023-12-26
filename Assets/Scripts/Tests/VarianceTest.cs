using System;
using System.Collections.Generic;
using LiskovsSubstitutionPrinciple;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class VarianceTest
    {
        [Test]
        public void CovarianceTest()
        {
            // 反変性
            // Child -> Parent => Action<Parent> -> Action<Child>
            Action<Parent> parentAction = x => { Debug.Log(x.ToString());};
            Action<Child> childAction = x => { Debug.Log(x.ToString());};
            childAction = parentAction;
            //  parentAction = childAction; // コンパイルエラー
            Assert.That(childAction is Action<Parent>, Is.True);
            Assert.That(parentAction is  Action<Child>, Is.True);   // なぜ通る？
        }
        
        [Test]
        public void ContravarianceTest()
        {
            // 共変性
            // Child -> Parent => IEnumerable<Child> -> IEnumerable<Parent>
            IEnumerable<Child> childAction = new List<Child>();
            IEnumerable<Parent> parentAction = new List<Parent>();
            // childAction = parentAction;  // コンパイルエラー
            parentAction = childAction;
            Assert.That(parentAction is  IEnumerable<Child>, Is.True);   // なぜ通る？
            Assert.That(childAction is  IEnumerable<Parent>, Is.True);   
        }
        
  
    }
}