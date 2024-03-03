using DesignPattern.ChainOfResponsibility.ViewModels;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public abstract class Employee
	{
		protected Employee NextApprover;
		
		public void SetNextApprover(Employee superVisor)
		{
			NextApprover = superVisor;
		}

		public abstract void ProcessRequest(CustomerProcessViewModel request);
	}
}


