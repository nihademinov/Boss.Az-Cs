using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Az_Cs.CompanyModel
{
    internal class Company
    {
        private string? _CompanyName;
        private string? _CompanyAddress;
        private DateTime _Date;

        public Company(string companyName, string companyAddress)
        {
            Property_CompanyName = companyName;
            Property_CompanyAddress = companyAddress;
            DateTime dateTime = new DateTime();
            _Date = dateTime;
        }

        public string Property_CompanyName
        {
            get { return _CompanyName; }
            set
            {

                _CompanyName = value;
            }
        }

        public string Property_CompanyAddress
        {
            get { return _CompanyAddress; }
            set
            {

                _CompanyAddress = value;
            }
        }

        public DateTime Property_Date
        {
            get { return _Date; }
        }


    }
}
