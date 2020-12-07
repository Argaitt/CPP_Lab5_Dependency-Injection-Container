using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPP_Lab5_Dependency_Injection_Container;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DependenciesConfiguration dependenciesConfiguration = new DependenciesConfiguration();
            dependenciesConfiguration.Register<ItestClass, TestClass>();
            DependencyProvider dependencyProvider = new DependencyProvider(dependenciesConfiguration);
            var test = dependencyProvider.Resolve<ItestClass>();
            Assert
        }
    }
}
