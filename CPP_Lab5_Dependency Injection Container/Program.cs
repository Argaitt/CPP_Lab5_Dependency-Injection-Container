using System;
using Ninject.Modules;
using Ninject.Activation;
using Ninject.Components;
using Ninject.Infrastructure;
using Ninject.Injection;
using Ninject.Parameters;
using Ninject.Planning;
using Ninject.Selection;
using Ninject.Syntax;
using Ninject;

namespace CPP_Lab5_Dependency_Injection_Container
{
    class Program
    {
        static void Main(string[] args)
        {
			//SimpleConfigModule simpleConfigModule = new SimpleConfigModule();
			//IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
			// там где нужно создать экземпляр ScheduleViewer мы вместо new, делаем так:
			//ScheduleViewer scheduleViewer = ninjectKernel.Get<ScheduleViewer>();
		}
    }
}



class Schedule
{

}

interface IScheduleManager
{
	Schedule GetSchedule();
}

class ScheduleManager : IScheduleManager
{
	public Schedule GetSchedule()
	{
		Schedule schedule = new Schedule();
		return schedule;
	}
}

class ScheduleViewer
{
	private IScheduleManager _scheduleManager;
	public ScheduleViewer(IScheduleManager scheduleManager)
	{
		_scheduleManager = scheduleManager;
	}
	public void RenderSchedule()
	{
		_scheduleManager.GetSchedule();
		// Do Something by render schedule... 
	}
}
class SimpleConfigModule: NinjectModule
{
	public void Register<I, R>(I intce, R realization) 
	{
	}
	public override void Load()
	{
		Bind<IScheduleManager>().To<ScheduleManager>();
		// нижняя строка необязательна, это поведение стоит по умолчанию:
		// т.е. класс подставляет сам себя
		Bind<ScheduleViewer>().ToSelf();
	}
}


