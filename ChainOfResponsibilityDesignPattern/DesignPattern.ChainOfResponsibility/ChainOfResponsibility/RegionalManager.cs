using DesignPattern.ChainOfResponsibility.Data;
using DesignPattern.ChainOfResponsibility.Models;
using DesignPattern.ChainOfResponsibility.ViewModels;
using System;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
	public class RegionalManager : Employee
	{
		public override void ProcessRequest(CustomerProcessViewModel request)
		{
			DBContext context = new DBContext();
			if (request.Amount <= 400000)
			{
				CustomerProcess customerProcess = new CustomerProcess();

				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Bolge Muduru - Zeynep Yilmaz";
				customerProcess.Description = "Para Cekme Islemi Onaylandi, Musteriye Talep Ettigi Tutar Odendi";
                customerProcess.IsApproved = true;
				customerProcess.ProcessTime = DateTime.Now;

                context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}
			else
			{
				CustomerProcess customerProcess = new CustomerProcess();

				customerProcess.Amount = request.Amount.ToString();
				customerProcess.Name = request.Name;
				customerProcess.EmployeeName = "Bolge Muduru - Zeynep Yilmaz";
				customerProcess.Description = "Para Cekme Tutari Bolge Mudurunun Gunluk Odeyebilecegi Limiti Astigi Icin Islem Gerceklestirilemedi, Musterinin Gunluk Maksimum Cekebilecegi Tutar 400,000 TL Olup Daha Fazlasi Icin Birden Fazla Gun Subeye Gelmesi Gereklidir";
                customerProcess.IsApproved = false;
                customerProcess.ProcessTime = DateTime.Now;

                context.CustomerProcesses.Add(customerProcess);
				context.SaveChanges();
			}
		}
	}
}
