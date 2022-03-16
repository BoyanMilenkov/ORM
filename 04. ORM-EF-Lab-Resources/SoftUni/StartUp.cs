using SoftUni.Data;
using System;
using SoftUni.Models;
using System.Linq;
namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            var context = new SoftUniContext();
            //Zad1
            //var result = FindEmployeesWithJobTitle(context);
            //Console.WriteLine(result);
            //Zad2
            //var result = FindProjectWithId(context);
            //Console.WriteLine(result);
            //Zad3
        }

        //Problem 03
        public static string FindEmployeesWithJobTitle(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => x.JobTitle == "Design Engineer").Select(x => x.FirstName).ToList();
            return String.Join(Environment.NewLine, employees);
        }

        //Problem 04
        public static string FindProjectWithId(SoftUniContext context)
        {
            var project = context.Projects.Find(2);
            return project.Name;
        }

        //Problem 05
        public static void CreateNewProject(SoftUniContext context)
        {
            var project = new Project()
            {
                Name = "Our Newest Project",
                StartDate = new DateTime(2021, 1, 1),
            };
            context.Projects.Add(project);
            context.SaveChanges();
        }

        //Problem 06
        public static string UpdateFirstEmployee(SoftUniContext context)
        {
            Employee employee = context.Employees.FirstOrDefault();
            if (employee != null)
            {
                employee.FirstName = "Alex";
                context.SaveChanges();
                return employee.FirstName;
            }
            return "";
        }

        //Problem 07
        public static string DeleteFirstProject(SoftUniContext context)
        {
            Project project = context.Projects.FirstOrDefault();
            var entitiesWithProject = context.EmployeesProjects.Where(x => x.ProjectId == project.ProjectId).ToList();
            context.EmployeesProjects.RemoveRange(entitiesWithProject);
            context.Projects.Remove(project);
            context.SaveChanges();
            return project.Name;
        }

        //Problem 08
        public static string UpdateAddresses(SoftUniContext context)
        {
            //return addresses.Count.ToString();
        }
    }
}
