using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Az_Cs.CVMOdel;
using Boss.Az_Cs.PersonModel;
using Boss.Az_Cs.VacancyModel;

namespace Boss.Az_Cs.AdminModel
{
    internal class Admin : Person
    {
        private List<CV>? RequestCv = new List<CV>();
        private List<Vacancy>? RequestVacancies = new List<Vacancy>();

        public Admin(string name, int age, string surname, string email, string password) : base(name, age, surname, email, password)
        {

        }

        public List<CV>? CheckRequestCv(CV cv)
        {
            RequestCv?.Add(cv);
            return RequestCv;
        }

        public void CheckRequestVacancies(Vacancy vacancy)
        {
            RequestVacancies.Add(vacancy);
        }


        public List<CV> Property_ReqCv
        {
            get { return RequestCv; }
            set { RequestCv = value; }
        }

        public List<Vacancy> Property_ReqVacancies
        {
            get { return RequestVacancies; }
            set { RequestVacancies = value; }
        }

    }
}
