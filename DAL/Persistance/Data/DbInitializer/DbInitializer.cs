using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Entities.Departments;
using DAL.Entities.Employees;
using Microsoft.EntityFrameworkCore;

namespace DAL.Persistance.Data.DbInitializer
{
    public class DbInitializer(ApplicationDbContext _dbContext) : IDbInitializer
    {
        public void Initialize()
        {
            // Code to initialize the database
            if(_dbContext.Database.GetPendingMigrations().Any())
                _dbContext.Database.Migrate();
            
        }
        public void Seed()
        {
            // Code to seed the database with initial data

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false),
                    //new DateOnlyJsonConverter() // if you're also handling DateOnly
                }


            };

            if (!_dbContext.Departments.Any())
            {
                var depatmentData = File.ReadAllText("../DAL/Persistance/Data/Seeds/departments.json");
                var departments = JsonSerializer.Deserialize<List<Department>>(depatmentData, options);

                if (departments is not null)
                {
                    _dbContext.Departments.AddRange(departments);
                    _dbContext.SaveChanges();
                }
            }

            if (!_dbContext.Employees.Any())
            {
                var employeeData = File.ReadAllText("../DAL/Persistance/Data/Seeds/employees.json");
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeeData, options);

                if (employees is not null)
                {
                    _dbContext.Employees.AddRange(employees);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
    
}
