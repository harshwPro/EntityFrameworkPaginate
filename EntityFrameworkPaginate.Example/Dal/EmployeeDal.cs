namespace EntityFrameworkPaginate.Example.Dal
{
    public class EmployeeDal
    {
        public Page<Employee> GetFilteredEmployees(int pageSize, int currentPage, string searchText, int sortBy, string jobTitle)
        {
            Page<Employee> employees;
            var filters = new Filters<Employee>();
            filters.Add(!string.IsNullOrEmpty(searchText), x=>x.LoginID.Contains(searchText));
            filters.Add(!string.IsNullOrEmpty(jobTitle), x=> x.JobTitle.Equals(jobTitle));

            var sorts = new Sorts<Employee>();
            sorts.Add(sortBy == 1, x=>x.BusinessEntityID);
            sorts.Add(sortBy == 2, x=>x.LoginID);
            sorts.Add(sortBy == 3, x=>x.JobTitle);

            using (var context = new AdventureWorksEntities())
            {
                employees = context.Employees.Paginate(currentPage, pageSize, sorts, filters);
            }

            return employees;
        }
    }
}