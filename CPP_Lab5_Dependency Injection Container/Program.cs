using System;
using System.Collections.Generic;

namespace CPP_Lab5_Dependency_Injection_Container
{
    class Program
    {
        static void Main(string[] args)
        {
            
		}
    }
    class DependenciesConfiguration
    {
        Dictionary<Type, List<Type>> dictionary = new Dictionary<Type, List<Type>>();
        public void Register<Interface,Imp>()
        {
            dictionary.Add(Interface, value.add(Imp));
        }
    }
}






