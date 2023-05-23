using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Boss.Az_Cs.WorkerModel;

namespace Boss.Az_Cs.VacancyModel
{
    internal class Vacancy
    {
        private string? _JobName;
        private string? _JobDescription;
        private string? _JobExperience;
        private Guid? _VacancyId;
        private double? _Salary;
        private string? _MailEmployer;
        private List<Worker>? AcceptWorker = new List<Worker>();

        public Vacancy(string? jobName, string? jobDescription, string? jobExperience, double? salary, string? mail)
        {
            _VacancyId = Guid.NewGuid();
            Property_JobName = jobName;
            Property_JobDescription = jobDescription;
            Property_JobExperience = jobExperience;
            Property_Salary = salary;
            Property_MailEmployer = mail;



        }


        public List<Worker> Add_AcceptWorker(Worker wr)
        {
            AcceptWorker.Add(wr);
            return AcceptWorker;
        }


        public List<Worker> Property_AcceptWorker
        {
            get { return AcceptWorker; }
            set { AcceptWorker = value; }
        }
        public string? Property_MailEmployer
        {
            get { return _MailEmployer; }
            set
            {

                _MailEmployer = value;
            }
        }

        public string? Property_JobName
        {
            get { return _JobName; }
            set
            {

                _JobName = value;
            }
        }

        public string? Property_JobDescription
        {
            get { return _JobDescription; }
            set
            {

                _JobDescription = value;
            }
        }

        public string? Property_JobExperience
        {
            get { return _JobExperience; }
            set
            {

                _JobExperience = value;
            }
        }

        public Guid? Property_VacancyId
        {
            get { return _VacancyId; }
        }

        public double? Property_Salary
        {
            get { return _Salary; }
            set
            {

                _Salary = value;
            }
        }

        public override string ToString() => $@"
Vacancy Id:{Property_VacancyId}
Job Name:{Property_JobName}
Job Description:{Property_JobDescription}
Job Expreience:{Property_JobExperience}
Salary:{Property_Salary}
Mail:{Property_MailEmployer}";

    }
}
