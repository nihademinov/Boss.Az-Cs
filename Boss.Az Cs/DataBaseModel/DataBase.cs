using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Az_Cs.AdminModel;
using Boss.Az_Cs.CompanyModel;
using Boss.Az_Cs.CVMOdel;
using Boss.Az_Cs.EmployerModel;
using Boss.Az_Cs.VacancyModel;
using Boss.Az_Cs.WorkerModel;

namespace Boss.Az_Cs.DataBaseModel
{
    internal class DataBase
    {
        private List<Worker>? AllWorkers = new List<Worker>();
        private List<Employer>? AllEmployers = new List<Employer>();
        private List<Admin>? AllAdmins = new List<Admin>();
        private List<Vacancy>? AllVacancies = new List<Vacancy>();
        private List<CV>? AllCvs = new List<CV>();
        private List<Company>? AllCompanies = new List<Company>();


        public List<Worker> Add_Wroker(Worker worker)
        {
            AllWorkers.Add(worker);
            return AllWorkers;
        }

        public List<Employer> Add_Employer(Employer employer)
        {
            AllEmployers.Add(employer);
            return AllEmployers;
        }

        public List<Admin> Add_Admin(Admin admin)
        {
            AllAdmins.Add(admin);
            return AllAdmins;
        }

        public List<Vacancy> Add_Vacancies(Vacancy vacancy)
        {
            AllVacancies.Add(vacancy);
            return AllVacancies;
        }

        public List<CV> Add_CV(CV cv)
        {
            AllCvs.Add(cv);
            return AllCvs;
        }

        public List<Company> Add_Company(Company company)
        {
            AllCompanies.Add(company);
            return AllCompanies;

        }

        public List<Worker> Property_Listworker
        {
            get { return AllWorkers; }
            set { AllWorkers = value; }
        }

        public List<Employer> Property_ListEmployer
        {
            get { return AllEmployers; }
            set { AllEmployers = value; }
        }

        public List<Admin> Property_ListAdmin
        {
            get { return AllAdmins; }
            set { AllAdmins = value; }
        }

        public List<Vacancy> Property_ListVacancy
        {
            get { return AllVacancies; }
            set { AllVacancies = value; }
        }

        public List<Company> Property_ListCompany
        {
            get { return AllCompanies; }
            set { AllCompanies = value; }
        }

        public List<CV>? Property_ListCV
        {
            get { return AllCvs; }
            set { AllCvs = value; }
        }

    }
}
