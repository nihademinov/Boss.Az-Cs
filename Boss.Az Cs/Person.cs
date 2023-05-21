using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Az_Cs
{
    public  class Person
    {
        private Guid _Id;
        private string? _Name;
        private int _Age;
        private string? _Surname;
        private string? _Email;
        private string? _Password;

        public Person(string name, int age, string surname, string email, string password)
        {
            _Id = Guid.NewGuid();
            Property_Name = name;
            Property_Age = age;
            Property_Surname = surname;
            Property_Email = email;
            Property_Password = password;
        }
        public Person(string name, string surname, string email, string password)
        {
            _Id = Guid.NewGuid();
            Property_Name = name;
            Property_Surname = surname;
            Property_Email = email;
            Property_Password = password;
        }




        public Guid Property_Id
        {
            get { return _Id; }
        }
        public string Property_Name
        {
            get { return _Name; }
            set
            {
                
                    _Name = value;
            }
        }

        public string Property_Surname
        {
            get { return _Surname; }
            set
            {
               
                    _Surname = value;
            }
        }


        public string Property_Email
        {
            get { return _Email; }
            set
            {
               
                    _Email = value;
            }
        }

        public string Property_Password
        {
            get { return _Password; }
            set
            {
               
                    _Password = value;
            }
        }

        public int Property_Age
        {
            get { return _Age; }
            set
            {
               
                    _Age = value;
            }
        }

    }
}
