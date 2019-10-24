using JobPortal.DALTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal
{
    public class BLL
    {
        PersonalTableAdapter aPTA = new PersonalTableAdapter();
        Personal1TableAdapter uPTA = new Personal1TableAdapter();
        public List<PersonalDetailsClass> GetPersonalData()
        {
            int i = 1;
            List<PersonalDetailsClass> personalList = new List<PersonalDetailsClass>();
            foreach (var p in aPTA.GetData())
            {
                PersonalDetailsClass ap = new PersonalDetailsClass();
                //AnyPropertyIsnull(p);
                ap.intID = p.intID;
                ap.strFirstName = p.strFirstName;
                ap.strLastName = p.strLastName;
                ap.strFatherName = p.strFatherName;
                ap.strMatherName = p.strMatherName;
                ap.dteDateOfBirth = p.dteDateOfBirth;
                ap.strGender = p.strGender;
                ap.strReligion = p.strReligion;
                ap.strMeritalStutas = p.strMeritalStutas;
                ap.strNational = p.strNational;
                ap.strNID = p.strNID;
                ap.strPassportNo = p.strPassportNo;
                ap.dtePassportIssueDate = p.dtePassportIssueDate;
                ap.strMobile1 = p.strMobile1;
                ap.strMobile2 = p.strMobile2;
                ap.strMobile3 = p.strMobile3;
                ap.strMainEmail = p.strMainEmail;
                ap.strAltEmail = p.strAltEmail;

                ap.strPresentAddress = p.strPresentAddress;
                ap.strParmanentAddress = p.strParmanentAddress;

                ap.strObjective = p.strObjective;
                ap.strParmanentAddress2 = p.strParmanentAddress2;
                ap.floatPresentSalary = (p.floatPresentSalary);
                ap.floatExpectedSalary = p.floatExpectedSalary;
                ap.strJobLavel = p.strJobLavel;
                ap.strJobNature = p.strJobNature;

                ap.strCareerSummary = p.strCareerSummary;
                ap.strSpecialQualification = p.strSpecialQualification;
                ap.strKeywords = p.strKeywords;

                personalList.Add(ap);
                i++;
            }
            return personalList;
        }

        public string Updatedata(PersonalDetailsClass ap)
        {

            string message;
            var row = uPTA.Update1(ap.strFirstName, ap.strLastName, ap.strFatherName, ap.strMatherName, ap.dteDateOfBirth.ToString(), ap.strGender, ap.strReligion, ap.strMeritalStutas, ap.strNational, ap.strNID, ap.strPassportNo, ap.dtePassportIssueDate.ToString(), ap.strMobile1, ap.strMobile2, ap.strMobile3, ap.strMainEmail, ap.strAltEmail, ap.strPresentAddress, ap.strParmanentAddress, ap.strObjective, ap.strParmanentAddress2, ap.floatPresentSalary, ap.floatExpectedSalary, ap.strJobLavel, ap.strJobNature, ap.strCareerSummary, ap.strSpecialQualification, ap.strKeywords, ap.imgImage, ap.intID);

             if (row != null)
            message = "Data are successfull Updated.";
             else
            message = "Sorry! Data are not Updated.";

            return message;
        }
    }
}