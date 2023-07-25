namespace RazorPages.Models.Domain
{
	public class Employee
	{
		 
			public Guid Id { get; set; }
			public string Name { get; set; }
			public string Email { get; set; }
			public long salary { get; set; }
			public DateTime dob { get; set; }
			public string department { get; set; }
	 
}
}
