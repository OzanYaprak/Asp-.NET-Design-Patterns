using System;

namespace DesignPattern.ChainOfResponsibility.Models
{
	public class CustomerProcess
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Amount { get; set; }
		public string EmployeeName { get; set; }
		public string Description { get; set; }
		public bool IsApproved { get; set; }
		public DateTime ProcessTime { get; set; }
    }
}
