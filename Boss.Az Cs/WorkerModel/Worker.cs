using Boss.Az_Cs.CVMOdel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boss.Az_Cs.WorkerModel
{
    internal class Worker : Person
    {
        private string? _City;
        private string? _Phone;
        private CV _Cv;


        [JsonConstructor]
        public Worker(string? city, string? phone, CV cv, string name, int age, string surname, string email, string password) : base(name, age, surname, email, password)
        {
            Property_City = city;
            Property_Phone = phone;
            Property_CV = cv;
        }

        public Worker(string? city, string? phone, string name, int age, string surname, string email, string password) : base(name, age, surname, email, password)
        {
            Property_City = city;
            Property_Phone = phone;
        }



        public override string ToString() => $@"
ID:{Property_Id}
Name:{Property_Name}
Surname:{Property_Surname}
Age:{Property_Age}
Email:{Property_Email}
City:{_City}
_Phone:{_Phone}";





        public string? Property_City
        {
            get { return _City; }
            set
            {

                _City = value;
            }
        }
        public string? Property_Phone
        {
            get { return _Phone; }
            set
            {

                _Phone = value;
            }
        }
        public CV Property_CV
        {
            get { return _Cv; }
            set { _Cv = value; }
        }

    }
}
