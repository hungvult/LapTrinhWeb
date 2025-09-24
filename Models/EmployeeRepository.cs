using System.Collections.Generic;
using System.Linq;
using LapTrinhWeb.Models;

namespace LapTrinhWeb.Models
{
    public class EmployeeRepository
    {
        private static List<Employee> _employees = new List<Employee>()
        {
            new Employee(){
                Id = 1,
                FullName = "Nguyen Van A",
                Gender = "Male",
                Phone = "0987824721",
                Email = "NVA33@gmail.com",
                Salary = 1000,
                Status = "Active"}
        };
        private static int _nextId = 1;

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            employee.Id = _nextId++;
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                existing.FullName = employee.FullName;
                existing.Gender = employee.Gender;
                existing.Phone = employee.Phone;
                existing.Email = employee.Email;
                existing.Salary = employee.Salary;
                existing.Status = employee.Status;
            }
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}