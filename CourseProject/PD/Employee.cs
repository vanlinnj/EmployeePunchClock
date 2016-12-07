using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public class Employee
    { 
        private int employeeID;
        private string firstName;
        private string lastName;
        private string ssn;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        private double payRate;
        private double overtime;
        private bool isAdmin;

        #region Properties

        public int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string SSN
        {
            get
            {
                return ssn;
            }
            set
            {
                ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                zipCode = value;
            }
        }

        public double PayRate
        {
            get
            {
                return payRate;
            }
            set
            {
                payRate = value;
            }
        }

        public double Overtime
        {
            get
            {
                return overtime;
            }
            set
            {
                overtime = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                isAdmin = value;
            }
        }       
        #endregion

        
        public Employee(int employeeID, string fName, string lName, string ssn, string address, string city, string zip, double payRate, double overtime, bool isAdmin)
        {
            this.employeeID = employeeID;
            this.firstName = fName;
            this.lastName = lName;
            this.ssn = ssn;
            this.address = address;            
            this.city = city;
            this.zipCode = zip;      
            this.payRate = payRate;
            this.overtime = overtime;
            this.isAdmin = isAdmin;
        }//end employee

        public Employee()
        {
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }//end override GetHashCode

        public override bool Equals(object obj)
        {
            bool checkResult = false;

            if((obj != null) && (obj is Employee))
            {
                Employee e0 = (Employee)obj;
                if(employeeID == e0.employeeID)
                {
                    checkResult = true;
                }//end if
            }//end if

            return checkResult;
        }//end override Equals

        public override string ToString()
        {
            string stringResults = "";

            stringResults += "ID: " + employeeID + "\n" +
            "First Name: " + firstName + "\n" +
            "Last Name: " + lastName + "\n" +
            "Address: " + address + "\n" +
            "City: " + city + "\n" +
            "State: " + state + "\n" +
            "Zip: " + zipCode + "\n" +
            "PayRate: " + payRate + "\n" +
            "Overtime: " + overtime + "\n" +
            "Is Admin?: " + isAdmin;
            return stringResults;
        }//end override ToString

    }//end Employee class
}//end namespace CourseProject
