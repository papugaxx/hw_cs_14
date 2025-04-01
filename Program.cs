using System;
using System.Collections.Generic;
using System.Linq;

public class Company
{
    public string Name { get; set; }
    public DateTime FoundationDate { get; set; }
    public string BusinessProfile { get; set; }
    public string DirectorName { get; set; }
    public int EmployeeCount { get; set; }
    public string Address { get; set; }

    public Company(string name, DateTime foundationDate, string businessProfile,
                 string directorName, int employeeCount, string address)
    {
        Name = name;
        FoundationDate = foundationDate;
        BusinessProfile = businessProfile;
        DirectorName = directorName;
        EmployeeCount = employeeCount;
        Address = address;
    }

    public string Show()
    {
        return $"Company: {Name}\n" +
               $"Founded: {FoundationDate}\n" +
               $"Business: {BusinessProfile}\n" +
               $"Director: {DirectorName}\n" +
               $"Employees: {EmployeeCount}\n" +
               $"Address: {Address}\n";
    }
}

public class CompanyManager
{
    private List<Company> _companies;

    public CompanyManager()
    {
        _companies = new List<Company>
        {
            new Company("Tech", new DateTime(2010, 5, 15), "IT",
                      "Ivan Ivanov", 50, "Kyiv, Khreshchatyk St. 1"),
            new Company("Food", new DateTime(2015, 3, 20), "Products",
                      "Olena Petrova", 30, "Lviv, Svobody Ave. 5"),
            new Company("Food", new DateTime(2008, 10, 1), "Products",
                      "Mykhailo Sydorenko", 120, "Odesa, Derybasivska St. 10")
        };
    }

    public void ShowAllCompanies()
    {
        var allCompanies = from company in _companies
                           select company;

        foreach (var company in allCompanies)
            Console.WriteLine(company.Show());
    }
    public void ShowFoodCompanies()
    {
        var foodCompanies = from company in _companies
                            where company.Name.Contains("Food")
                            select company;

        foreach (var company in foodCompanies)
            Console.WriteLine(company.Show());
    }
}

public class Program
{
    public static void Main()
    {
        var manager = new CompanyManager();
        Console.WriteLine("All:");
        manager.ShowAllCompanies();
        Console.WriteLine("Food:");
        manager.ShowFoodCompanies();
    }
}