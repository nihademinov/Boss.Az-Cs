using Boss.Az_Cs.CompanyModel;
using Boss.Az_Cs.PersonModel;
using Boss.Az_Cs.VacancyModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Az_Cs.EmployerModel
{
    internal class Employer : Person
    {
        private Company _Company;
        private Vacancy _Vacancy;


        [JsonConstructor]
        public Employer(Company company, Vacancy vacancy, string name, string surname, string email, string password) : base(name, surname, email, password)
        {
            Property_Company = company;
            Property_Vacancy = vacancy;
        }
        public Employer(Company company, string name, string surname, string email, string password) : base(name, surname, email, password)
        {
            Property_Company = company;
        }




        public Company Property_Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        public Vacancy Property_Vacancy
        {
            get { return _Vacancy; }
            set { _Vacancy = value; }
        }

    }
}
