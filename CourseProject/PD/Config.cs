using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program9
{
    public class Config
    {
        private string name;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phone;

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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

        public string Zip
        {
            get
            {
                return zip;
            }

            set
            {
                zip = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }
        #endregion


        public Config()
        {
            this.name = "";
            this.address = "";
            this.city = "";
            this.state = "";
            this.zip = "";
            this.phone = "";
        }

        public Config(string name, string address, string city, string state, string zip, string phone)
        {
            this.Name = name;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Phone = phone;
        }

    }
}
