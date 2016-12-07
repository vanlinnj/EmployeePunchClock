using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public class Punch
    {
        private int punchID;
        private int employeeID;
        private DateTime dateTime;
        private bool punchType;

        #region Properties
        public int PunchID
        {
            get
            {
                return punchID;
            }
            set
            {
                punchID = value;
            }
        }

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

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }

        public bool PunchType
        {
            get
            {
                return punchType;
            }
            set
            {
                punchType = value;
            }
        }
        #endregion
        public Punch()
        {
            punchID = 0;
            employeeID = 0;
            dateTime = DateTime.Now;
            punchType = true;
        }

        public Punch(int punchID, int employeeID, DateTime dateTime, bool punchType)
        {
            this.punchID = punchID;
            this.employeeID = employeeID;
            this.dateTime = dateTime;
            this.punchType = punchType;
        }//end Punch

        public Punch(int employeeID, bool punchType)
        {
            this.punchID = 0;
            this.employeeID = employeeID;
            this.dateTime = DateTime.Now;
            this.punchType = punchType;
        }//end Punch

        public String getPunchType()
        {
            string punchResult = "";

            if(punchType == true)
            {
                punchResult = "In";
            }
            else
            {
                punchResult = "Out";
            }
            return punchResult;
        }//end getPunchType

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool checkResult = false;

            if((obj != null) && (obj is Punch))
            {
                Punch p0 = (Punch)obj;
                if ((employeeID == p0.employeeID) && (dateTime.Equals(p0.dateTime)) && (punchType == p0.punchType))
                {
                    checkResult = true;
                }//end if
            }//end if
            return checkResult;
        }//end Equals

        public override string ToString()
        {
            string stringResults = "";

            stringResults += "Punch ID: " + punchID + "\n" +
            "Employee ID: " + employeeID + "\n" +
            "Time: " + dateTime.ToString("MM/dd/yyyy hh:mm:ss tt") + "\n" +
            "Punch Type: " + getPunchType();
            return stringResults;
        }//end override ToString

    }//end punch class
}//end namespace courseProject
