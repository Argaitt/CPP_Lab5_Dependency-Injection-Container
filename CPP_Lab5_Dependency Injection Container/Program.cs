using System;
using System.Collections.Generic;
using System.Linq;

namespace CPP_Lab5_Dependency_Injection_Container
{
    class Program
    {
        static void Main(string[] args)
        {
            DependenciesConfiguration dependenciesConfiguration = new DependenciesConfiguration();
            dependenciesConfiguration.Register<ItestClass, TestClass>();
            DependencyProvider dependencyProvider = new DependencyProvider(dependenciesConfiguration);
            var test = dependencyProvider.Resolve<ItestClass>();
            
		}
    }
    class DependenciesConfiguration
    {
        Dictionary<Type, List<Type>> dependeces = new Dictionary<Type, List<Type>>();
        public void Register<Tinterface,Timp>()
        {
            var typeinterfece = typeof(Tinterface);
            if (!dependeces.ContainsKey(typeinterfece))
            {
                dependeces[typeinterfece] = new List<Type>();
            }
            dependeces[typeinterfece].Add(typeof(Timp));
        }
        public Dictionary<Type,List<Type>> GetDependeces()
        {
            return dependeces;
        }
    }
    class DependencyProvider
    {
        Dictionary<Type, List<Type>> _dependeces;
        public DependencyProvider(DependenciesConfiguration configuration) 
        {
            _dependeces = configuration.GetDependeces();
        }
        public dynamic Resolve<Tinterface>() 
        {
            var typeinterface = typeof(Tinterface);
            if (_dependeces.ContainsKey(typeinterface)) 
            {
                return Activator.CreateInstance(_dependeces[typeinterface].First());
            }
            else
                return 0;
        }
    }
    interface ItestClass 
    {
        
    }
    class TestClass : ItestClass
    {
        public int a = 1;
    }
}






