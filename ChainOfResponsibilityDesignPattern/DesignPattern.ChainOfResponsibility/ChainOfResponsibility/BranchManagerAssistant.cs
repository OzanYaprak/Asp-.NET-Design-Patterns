using DesignPattern.ChainOfResponsibility.Data;
using DesignPattern.ChainOfResponsibility.Models;
using DesignPattern.ChainOfResponsibility.ViewModels;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class BranchManagerAssistant : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel request)
		{
			DBContext context = new DBContext();
			if (request.Amount <= 150000)
			{
				CustomerProcess customerProcess = new CustomerProcess();

				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Sube Mudur Yardimcisi - Melike Ozturk";
				customerProcess.Description = "Para Cekme Islemi Onaylandi, Musteriye Talep Ettigi Tutar Odendi";

				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}
			else if (NextApprover != null)
			{
				CustomerProcess customerProcess = new CustomerProcess();

				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Sube Mudur Yardimcisi - Melike Ozturk";
				customerProcess.Description = "Para Cekme Tutari Sube Mudur Yardimcisinin Gunluk Odeyebilecegi Limiti Astigi Icin Islem Sube Mudurune Yonlendirildi";

				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();

				NextApprover.ProcessRequest(request);
			}
		}
	}
}
