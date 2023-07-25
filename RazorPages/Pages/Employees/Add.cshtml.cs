using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
using RazorPages.Data;
using RazorPages.Models.Domain;
using RazorPages.Models.NewFolder;

namespace RazorPages.Pages.Employees
{
    public class AddModel : PageModel
    {
		
        private readonly RazorpageContext dbContext;

		public AddModel(RazorpageContext dbContext)
		{
			this.dbContext = dbContext;
		}
        [BindProperty]
        public AddEmployee AddEmployeeRequest { get; set; }

        
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var EmployeeDomainModel = new Employee
            {

                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                salary = AddEmployeeRequest.salary,
                dob = AddEmployeeRequest.dob,
                department = AddEmployeeRequest.department,
            };
            dbContext.employees.Add(EmployeeDomainModel);
			dbContext.SaveChanges();

            ViewData["message"] = "Employee created Succesfully!";
               
        }

    }
}
