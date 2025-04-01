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
               $"Founded: {FoundationDate.ToShortDateString()}\n" +
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
            new Company("Tech Solutions", new DateTime(2010, 5, 15), "IT",
                      "Ivan Ivanov", 50, "Kyiv, Khreshchatyk St. 1"),
            new Company("Food Delivery", new DateTime(2015, 3, 20), "Products",
                      "Olena Petrova", 30, "Lviv, Svobody Ave. 5"),
            new Company("Food Market", new DateTime(2008, 10, 1), "Products",
                      "Mykhailo Sydorenko", 120, "Odesa, Derybasivska St. 10"),
            new Company("Digital Marketing", new DateTime(2018, 7, 12), "Marketing",
                      "John White", 150, "London, Oxford St. 100"),
            new Company("IT Innovations", new DateTime(2019, 1, 5), "IT",
                      "Sarah Johnson", 250, "London, Baker St. 221B"),
            new Company("Global Marketing", new DateTime(2012, 11, 30), "Marketing",
                      "Michael White", 80, "New York, Broadway 50"),
            new Company("London Foods", new DateTime(2020, 2, 14), "Products",
                      "David Brown", 300, "London, Piccadilly 25")
        };
    }

    public void ShowAllCompanies()
    {
        Console.WriteLine("All companies:");
        var allCompanies = from company in _companies
                          select company;

        foreach (var company in allCompanies)
            Console.WriteLine(company.Show());
    }

    public void ShowFoodCompanies()
    {
        Console.WriteLine("\nCompanies with 'Food' in name:");
        var foodCompanies = from company in _companies
                           where company.Name.Contains("Food")
                           select company;

        foreach (var company in foodCompanies)
            Console.WriteLine(company.Show());
    }

    public void ShowMarketingCompanies()
    {
        Console.WriteLine("\nMarketing companies:");
        var marketingCompanies = from company in _companies
                                where company.BusinessProfile == "Marketing"
                                select company;

        foreach (var company in marketingCompanies)
            Console.WriteLine(company.Show());
    }

    public void ShowCompaniesWithMoreThan100Employees()
    {
        Console.WriteLine("\nCompanies with >100 employees:");
        var companies = from company in _companies
                        where company.EmployeeCount > 100
                        select company;

        foreach (var company in companies)
            Console.WriteLine(company.Show());
    }

    public void ShowCompaniesWith100To300Employees()
    {
        Console.WriteLine("\nCompanies with 100-300 employees:");
        var companies = from company in _companies
                        where company.EmployeeCount >= 100 && company.EmployeeCount <= 300
                        select company;

        foreach (var company in companies)
            Console.WriteLine(company.Show());
    }

    public void ShowLondonCompanies()
    {
        Console.WriteLine("\nCompanies in London:");
        var companies = from company in _companies
                         where company.Address.Contains("London")
                         select company;

        foreach (var company in companies)
            Console.WriteLine(company.Show());
    }

    public void ShowCompaniesWithWhiteDirector()
    {
        Console.WriteLine("\nCompanies with director 'White':");
        var companies = from company in _companies
                        where company.DirectorName.Contains("White")
                        select company;

        foreach (var company in companies)
            Console.WriteLine(company.Show());
    }

    public void ShowCompaniesFoundedMoreThan2YearsAgo()
    {
        Console.WriteLine("\nCompanies founded more than 2 years ago:");
        var twoYearsAgo = DateTime.Now.AddYears(-2);
        var companies = from company in _companies
                         where company.FoundationDate < twoYearsAgo
                         select company;

        foreach (var company in companies)
            Console.WriteLine(company.Show());
    }
}

public class Program
{
    public static void Main()
    {
        var manager = new CompanyManager();
        
        manager.ShowAllCompanies();
        manager.ShowFoodCompanies();
        manager.ShowMarketingCompanies();
        manager.ShowCompaniesWithMoreThan100Employees();
        manager.ShowCompaniesWith100To300Employees();
        manager.ShowLondonCompanies();
        manager.ShowCompaniesWithWhiteDirector();
        manager.ShowCompaniesFoundedMoreThan2YearsAgo();
    }
}
