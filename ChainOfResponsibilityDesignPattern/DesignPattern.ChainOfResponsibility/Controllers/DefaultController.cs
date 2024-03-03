using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern.ChainOfResponsibility.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
	public class DefaultController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		
		[HttpPost]
		public IActionResult Index(CustomerProcessViewModel customerProcessViewModel)
		{
			Employee cashier = new Cashier();
			Employee branchManagerAssistant = new BranchManagerAssistant();
			Employee branchManager = new BranchManager();
			Employee regionalManager = new RegionalManager();

			cashier.SetNextApprover(branchManagerAssistant);
			branchManagerAssistant.SetNextApprover(branchManager);
			branchManager.SetNextApprover(regionalManager);

			cashier.ProcessRequest(customerProcessViewModel);
			return View();
		}
	}
}
