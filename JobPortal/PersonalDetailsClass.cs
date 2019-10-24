using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal
{
    public class PersonalDetailsClass
    {
        public int intID { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strFatherName { get; set; }
        public string strMatherName { get; set; }

        public DateTime dteDateOfBirth { get; set; }
        public string strGender { get; set; }
        public string strReligion { get; set; }
        public string strMeritalStutas { get; set; }
        public string strNational { get; set; }
        public string strNID { get; set; }
        public string strPassportNo { get; set; }
        public DateTime dtePassportIssueDate { get; set; }
        public string strMobile1 { get; set; }
        public string strMobile2 { get; set; }
        public string strMobile3 { get; set; }
        public string strMainEmail { get; set; }
        public string strAltEmail { get; set; }


        public string strPresentAddress { get; set; }
        public string strParmanentAddress { get; set; }


        public string strObjective { get; set; }
        public string strParmanentAddress2 { get; set; }
        public Decimal floatPresentSalary { get; set; }
        public Decimal floatExpectedSalary { get; set; }
        public string strJobLavel { get; set; }
        public string strJobNature { get; set; }


        public string strCareerSummary { get; set; }
        public string strSpecialQualification { get; set; }
        public string strKeywords { get; set; }

        public byte[] imgImage { get; set; }
    }
}