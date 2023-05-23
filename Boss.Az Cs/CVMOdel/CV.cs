using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss.Az_Cs.EmployerModel;

namespace Boss.Az_Cs.CVMOdel
{
    internal class CV
    {

        private List<string>? _Language;
        private List<string>? _LanguageSkillScore;
        private string? _UniName;
        private string? _FacultyName;
        private string? _Skills;
        private double _EnteranceScore;
        private string? _Companies;
        private string? _DifferenceDiplom;
        private string? _GithubLink;
        private string? _LinkednLink;
        private string? _EmailWorker;
        private List<Employer>? AcceptEmployer = new List<Employer>();


        public CV(List<string>? language, List<string>? languageSkillScore, string? uniName, string? facultyName, string? skills, double enteranceScore, string? companies, string? differenceDiplom, string? githubLink, string? linkednLink, string email)
        {
            Property_EmailWorker = email;
            Property_Language = language;
            Property_LanguageSkillScore = languageSkillScore;
            Property_UniName = uniName;
            Property_FacultyName = facultyName;
            Property_Skills = skills;
            Property_EnteranceScore = enteranceScore;
            Property_Companies = companies;
            Property_DifferenceDiplom = differenceDiplom;
            Property_GithubLink = githubLink;
            Property_LinkednLink = linkednLink;
        }


        public override string ToString() => $@"
University:{_UniName}
Faculty:{_FacultyName}
Skills:{_Skills}
Enterance Score:{_EnteranceScore}
Companies:{_Companies}
Differeance Diplom:{_DifferenceDiplom}
Github link:{_GithubLink}
LinkedIn link:{_LinkednLink}
Mail:{Property_EmailWorker}";


        public List<Employer> Add_AcceptEmployer(Employer emp)
        {
            AcceptEmployer.Add(emp);
            return AcceptEmployer;
        }


        public List<Employer> Property_AcceptEmployer
        {
            get { return AcceptEmployer; }
            set { AcceptEmployer = value; }
        }
        public void PrintLanguage()
        {
            var language = _Language.ToArray();
            var LangSkill = _LanguageSkillScore.ToArray();
            for (int i = 0; i < language.Length; i++)
            {
                Console.WriteLine($"Language-->{language[i]} Language skill-->{LangSkill[i]}");
            }

        }

        public string Property_EmailWorker
        {
            get { return _EmailWorker; }
            set { _EmailWorker = value; }
        }


        public List<string> Property_Language
        {
            get
            {
                if (_Language == null)
                    _Language = default;

                return _Language!;
            }

            set { _Language = value; }
        }
        public List<string> Property_LanguageSkillScore
        {
            get
            {
                if (_LanguageSkillScore == null)
                    _LanguageSkillScore = default;

                return _LanguageSkillScore!;
            }

            set { _LanguageSkillScore = value; }
        }

        public string Property_UniName
        {
            get
            {
                if (_UniName == null)
                    _UniName = default;

                return _UniName!;
            }

            set { _UniName = value; }
        }

        public string Property_FacultyName
        {
            get
            {
                if (_FacultyName == null)
                    _FacultyName = default;

                return _FacultyName!;
            }

            set { _FacultyName = value; }
        }

        public string Property_Skills
        {
            get
            {
                if (_Skills == null)
                    _Skills = default;

                return _Skills!;
            }

            set { _Skills = value; }
        }

        public double Property_EnteranceScore
        {
            get { return _EnteranceScore!; }
            set
            {
                if (value < 0)
                {
                    try
                    {
                        throw new Exception("Score can not be negative");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    _EnteranceScore = value;
            }
        }

        public string Property_Companies
        {
            get
            {
                if (_Companies == null)
                    _Companies = default;

                return _Companies!;
            }
            set { _Companies = value; }
        }

        public string Property_DifferenceDiplom
        {
            get
            {
                if (_DifferenceDiplom == null)
                    _DifferenceDiplom = default;

                return _DifferenceDiplom!;
            }

            set { _DifferenceDiplom = value; }
        }

        public string Property_GithubLink
        {
            get { return _GithubLink!; }
            set
            {
                _GithubLink = value;

            }
        }



        public string Property_LinkednLink
        {
            get { return _LinkednLink!; }
            set
            {
                _LinkednLink = value;

            }
        }


    }
}
