using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganization
{
    internal class Position
    {
        private string title;
        private Employee? employee;
        private HashSet<Position> directReports;

        public Position(string title)
        {
            this.title = title;
            directReports = new HashSet<Position>();
        }

        public Position(String title, Employee employee) : this(title)
        {
            if (employee != null)
                SetEmployee(employee);
        }

        public String GetTitle()
        {
            return title;
        }

        public void SetEmployee(Employee? employee)
        {
            this.employee = employee ?? throw new ArgumentNullException();
        }

        public Employee? GetEmployee(int identifier)
        {
            return employee;
        }

        public Boolean IsFilled()
        {
            return employee != null;
        }

       

        public Boolean AddDirectReport(Position postion)
        {
            if (postion == null)
                throw new Exception("position cannot be null");
            return directReports.Add(postion);
        }

        public Position? FindPostionByTitle(Position position)
        {
            if (position.title == title)
                return this;
            else
            {
                return null;
            }
        }

        public Boolean RemoveEmpoyee(Position postion)
        {
            return directReports.Remove(postion);
        }

        public ImmutableList<Position> GetDirectReports()
        {
            return directReports.ToImmutableList();
        }

        override public string ToString()
        {
            return title + ( employee!= null ? ": " + employee.ToString() : "");
        }
    }
}
