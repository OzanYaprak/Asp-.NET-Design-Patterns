using DesignPattern.ChainOfResponsibility.Data;
using DesignPattern.ChainOfResponsibility.Models;
using DesignPattern.ChainOfResponsibility.ViewModels;
using System;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class BranchManager : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel request)
		{
			DBContext context = new DBContext();
			if (request.Amount <= 250000)
			{
				CustomerProcess customerProcess = new CustomerProcess();

				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Sube Muduru - Arif Isik";
				customerProcess.Description = "Para Cekme Islemi Onaylandi, Musteriye Talep Ettigi Tutar Odendi";
                customerProcess.IsApproved = true;
                customerProcess.ProcessTime = DateTime.Now;

                context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}
			else if (NextApprover != null)
			{
				CustomerProcess customerProcess = new CustomerProcess();

				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Sube Muduru - Arif Isik";
				customerProcess.Description = "Para Cekme Tutari Sube Mudurunun Gunluk Odeyebilecegi Limiti Astigi Icin Islem Bolge Mudurune Yonlendirildi";
                customerProcess.IsApproved = false;
                customerProcess.ProcessTime = DateTime.Now;

                context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();

				NextApprover.ProcessRequest(request);
			}
		}
	}
}
