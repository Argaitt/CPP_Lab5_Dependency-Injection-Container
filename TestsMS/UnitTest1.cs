using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPP_Lab5_Dependency_Injection_Container;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TestsMS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RegistrationTest()
        {
            DependenciesConfiguration d = new DependenciesConfiguration();
            d.Register<IClass1, Class1>();
            Assert.AreEqual(true, d.GetDependeces().ContainsKey(typeof(IClass1)));
        }

        [TestMethod]
        public void MultiRegistrationTest()
        {
            DependenciesConfiguration d = new DependenciesConfiguration();
            d.Register<IClass1, Class1>();
            d.Register<IClass2, Class2>();
            Assert.AreEqual(true, d.GetDependeces().ContainsKey(typeof(IClass1)));
            Assert.AreEqual(true, d.GetDependeces().ContainsKey(typeof(IClass2)));
        }
        [TestMethod]
        public void MultiRegRealizationTest()
        {
            DependenciesConfiguration dc = new DependenciesConfiguration();
            dc.Register<IClass1, Class1>();
            dc.Register<IClass1, Class2>();
            var test = dc.GetDependeces().First();
            Assert.AreEqual(2, dc.GetDependeces().First().Value.Count);
        }

        [TestMethod]
        public void GetRealizationTest()
        {
            DependenciesConfiguration dc = new DependenciesConfiguration();
            dc.Register<IClass1, Class1>();
            DependencyProvider dp = new DependencyProvider(dc);
            var actual = dp.Resolve<IClass1>();
            Assert.AreEqual("TestsMS.Class1", actual.GetType().ToString());
        }

        [TestMethod]
        public void GetMultiRealizationTest()
        {
            DependenciesConfiguration dc = new DependenciesConfiguration();
            dc.Register<IClass1, Class1>();
            dc.Register<IClass1, Class2>();
            DependencyProvider dp = new DependencyProvider(dc);
            var actual = dp.Resolve<IClass1>().GetType().ToString();
            Assert.AreEqual("System.Collections.Generic.List`1[System.Object]", actual);
        }
    }
    class Class1
    {
        int a;
        public int DoSomething()
        {
            return 0;
        }
    }
    interface IClass1
    {
        int DoSomething();
    }
    class Class2
    {
        int a;
        public int DoSomething()
        {
            return 0;
        }
    }
    interface IClass2
    {
        int DoSomething();
    }
}
