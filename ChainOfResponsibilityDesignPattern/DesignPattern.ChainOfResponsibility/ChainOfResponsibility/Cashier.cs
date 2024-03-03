using DesignPattern.ChainOfResponsibility.Data;
using DesignPattern.ChainOfResponsibility.Models;
using DesignPattern.ChainOfResponsibility.ViewModels;
using System;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class Cashier : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel request)
		{
			DBContext context = new DBContext();
			if (request.Amount <= 100000)
			{
				CustomerProcess customerProcess = new CustomerProcess();
				
				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Veznedar - Ayse Cinar";
				customerProcess.Description = "Para Cekme Islemi Onaylandi, Musteriye Talep Ettigi Tutar Odendi";

				context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}
            else if (NextApprover != null)
            {
				CustomerProcess customerProcess = new CustomerProcess();

				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Veznedar - Ayse Cinar";
				customerProcess.Description = "Para Cekme Tutari Veznedarin Gunluk Odeyebilecegi Limiti Astigi Icin Islem Sube Mudur Yardimcisina Yonlendirildi";
				
				context.CustomerProcesses.Add(customerProcess); 
				context.SaveChanges();

				NextApprover.ProcessRequest(request);
			}
		}
	}
}
