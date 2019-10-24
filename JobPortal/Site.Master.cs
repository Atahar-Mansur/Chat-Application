using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace JobPortal
{
    public partial class SiteMaster : MasterPage
    {
        //BLL objData = new BLL();
        BLL aBLL = new BLL();
        DataTable dt = new DataTable();
        List<Academic> anAcademic = new List<Academic>();
        PersonalDetailsClass aPersonal = new PersonalDetailsClass();
        string filePathForAcaXML, filePathForPerXML, filePathForTraXML, filePathForPCerXML, filePathForEmpXML, filePathForRCerXML;
        string xml;
        byte[] bytes;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForPerXML = Server.MapPath("~/XMLfiles/PersonalInfo.xml");
            filePathForAcaXML = Server.MapPath("~/XMLfiles/AddItem.xml");
            filePathForEmpXML = Server.MapPath("~/XMLfiles/EmplploymentData.xml");
            filePathForPCerXML = Server.MapPath("~/XMLfiles/CertificateData.xml");
            filePathForTraXML = Server.MapPath("~/XMLfiles/TrainingData.xml");
            filePathForRCerXML = Server.MapPath("~/XMLfiles/RetiredCertificateData.xml");

            foreach (var aPersonal in aBLL.GetPersonalData())
            {

                //---------------Personal Details-------------------

                txtFirstName.Text = aPersonal.strFirstName;
                txtLastName.Text = aPersonal.strLastName;
                txtFatherName.Text = aPersonal.strFatherName;
                txtMatherName.Text = aPersonal.strMatherName;
                dteDOB.Text = aPersonal.dteDateOfBirth.ToString();
                // =rdbGender.SelectedItem.Value.ToString()= aPersonal.strGender
                txtGender.Text = aPersonal.strGender;
                txtReligion.Text = aPersonal.strReligion;
                txtMaritalStatus.Text = aPersonal.strMeritalStutas;
                //aPersonal.strMeritalStutas = rdbMaritalStatus.SelectedItem.Value.ToString();

                txtNationality.Text = aPersonal.strNational;
                txtNID.Text = aPersonal.strNID;
                txtPassportNo.Text = aPersonal.strPassportNo;
                dtePassportIssuDate.Text = aPersonal.dtePassportIssueDate.ToString();
                txtMobile1.Text = aPersonal.strMobile1;
                txtMobile2.Text = aPersonal.strMobile2;
                txtMobile3.Text = aPersonal.strMobile3;
                txtMainEmail.Text = aPersonal.strMainEmail;
                txtAltEmail.Text = aPersonal.strAltEmail;

                //---------Address Details---------
                txtPresentAddress.Text = aPersonal.strPresentAddress;
                txtParmanentAddress.Text = aPersonal.strParmanentAddress;

                //---------Career and Application Information---------
                txtObjective.Text = aPersonal.strObjective;
                txtParmanentAddress2.Text = aPersonal.strParmanentAddress2;
                txtPresentSalary.Text = aPersonal.floatPresentSalary.ToString();
                txtExpectedSalary.Text = aPersonal.floatExpectedSalary.ToString();
                txtJobLevel.Text = aPersonal.strJobLavel;
                txtJobNature.Text = aPersonal.strJobNature;

                //---------Preferred Areas---------



                //---------Other Relevant Information ---------
                txtCareerSummary.Text = aPersonal.strCareerSummary;
                txtSpecialQualification.Text = aPersonal.strSpecialQualification;
                txtKeywords.Text = aPersonal.strKeywords;
            }
            //if (!IsPostBack)
            //{
               
            //    //    Session["List"] = new List<Academic>();
            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //---------Personal Details---------
            aPersonal.strFirstName = txtFirstName.Text;
            aPersonal.strLastName = txtLastName.Text;

            aPersonal.strFatherName = txtFatherName.Text;
            aPersonal.strMatherName = txtMatherName.Text;
            aPersonal.dteDateOfBirth = Convert.ToDateTime(dteDOB.Text);
            // aPersonal.strGender = rdbGender.SelectedItem.Value.ToString();
            aPersonal.strGender = txtGender.Text;
            aPersonal.strReligion = txtReligion.Text;
            aPersonal.strMeritalStutas = txtMaritalStatus.Text;
            // aPersonal.strMeritalStutas = rdbMaritalStatus.SelectedItem.Value.ToString();
            aPersonal.strNational = txtNationality.Text;
            aPersonal.strNID = txtNID.Text;
            aPersonal.strPassportNo = txtPassportNo.Text;
            aPersonal.dtePassportIssueDate = Convert.ToDateTime(dtePassportIssuDate.Text);
            aPersonal.strMobile1 = txtMobile1.Text;
            aPersonal.strMobile2 = txtMobile2.Text;
            aPersonal.strMobile3 = txtMobile3.Text;
            aPersonal.strMainEmail = txtMainEmail.Text;
            aPersonal.strAltEmail = txtAltEmail.Text;

            //---------Address Details---------
            aPersonal.strPresentAddress = txtPresentAddress.Text;//Request.Form["txtPresentAddress"];
            aPersonal.strParmanentAddress = txtParmanentAddress.Text;// Request.Form["txtParmanentAddress"];

            //---------Career and Application Information---------
            aPersonal.strObjective = txtObjective.Text;
            aPersonal.strParmanentAddress2 = txtParmanentAddress2.Text;
            aPersonal.floatPresentSalary = Convert.ToDecimal(txtPresentSalary.Text);
            aPersonal.floatExpectedSalary = Convert.ToDecimal(txtExpectedSalary.Text);
            aPersonal.strJobLavel = txtJobLevel.Text;
            aPersonal.strJobNature = txtJobNature.Text;

            //---------Preferred Areas-------- -



            //---------Other Relevant Information ---------
            aPersonal.strCareerSummary = txtCareerSummary.Text;
            aPersonal.strSpecialQualification = txtSpecialQualification.Text;
            aPersonal.strKeywords = txtKeywords.Text;
            //aPersonal.imgImage = imageByte(imageUpload.PostedFile);
            // ___________________________________________________________________________________________//

            CreateAddXml(aPersonal);
            // lblmessage.Text = 
            aBLL.Updatedata(aPersonal);

            // btnEdit.Visible = true;
            btnUpdate.Visible = false;

        }

        protected void btnAddAS_Click(object sender, EventArgs e)
        {
            //if (Session["List"] == null) anAcademic = new List<Academic>();
            //else anAcademic = (List<Academic>)Session["List"];

            Academic academic = new Academic();

            UiDesign();

            if (ValidationSearch())
            {
                academic.strLevelofEducation = strLevelofEducation.Text;
                academic.strExamDegreeTitle = strExamDegreeTitle.Text;
                academic.strConcentrationMajorGroup = strConcentrationMajorGroup.Text;
                academic.strInstituteName = strInstituteName.Text;
                academic.strAchievement = strAchievement.Text;
                academic.strResult = strResult.Text;
                academic.strYearofPassing = strYearofPassing.Text;
                academic.strDuration = strDuration.Text;

                CreateAddXml(academic);

                //anAcademic.Add(academic);
                //dgvOutput.DataSource = anAcademic;
                //dgvOutput.DataBind();
            }
        }

        protected void btnAddTS_Click(object sender, EventArgs e)
        {
            Training training = new Training();

            training.strTrainingTitle = strTrainingTitle.Text;
            training.strTopicsCovered = strTopicsCovered.Text;
            training.strInstitute = strInstitute.Text;
            training.strLocation = strLocation.Text;
            training.strCountry = strCountry.Text;
            training.strTrainingYear = strTrainingYear.Text;
            training.strDuration = strDuration.Text;

            CreateAddXml(training);
        }

        protected void btnAddCer_Click(object sender, EventArgs e)
        {
            Certificate certificate = new Certificate();

            certificate.imgCertificate = Convert.ToBase64String(imageByte(imgCertificate.PostedFile));

            CreateAddXml(certificate);
        }

        protected void btnAddEmp_Click(object sender, EventArgs e)
        {
            Experience experience = new Experience();

            experience.strCompanyName = strCompanyName.Text;
            experience.strCompanyBusiness = strCompanyBusiness.Text;
            experience.strDesignation = strDesignation.Text;
            experience.strDepartment = strDepartment.Text;
            experience.strAreaofExperiences = strAreaofExperiences.Text;
            experience.strResponsibilities = strResponsibilities.Text;
            experience.strCompanyLocation = strCompanyLocation.Text;
            experience.strEmploymentPeriod = strEmploymentPeriod.Text;

            CreateAddXml(experience);
        }

        protected void btnAddRAP_Click(object sender, EventArgs e)
        {
            Certificate certificate = new Certificate();

            certificate.imgCertificate = Convert.ToBase64String(imageByte(imgRAP.PostedFile));

            CreateAddXml(certificate, "retired");
        }


        private void CreateAddXml(PersonalDetailsClass aPersonal)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForPerXML))
            {
                doc.Load(filePathForPerXML);
                XmlNode rootNode = doc.SelectSingleNode("People");
                XmlNode addItem = CreateItemNodeDocUpload(doc, aPersonal);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("People");
                XmlNode addItem = CreateItemNodeDocUpload(doc, aPersonal);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForPerXML);
            //LoadGridwithXml();
        }

        private void CreateAddXml(Academic academic)
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists(filePathForAcaXML))
            {
                doc.Load(filePathForAcaXML);
                XmlNode rootNode = doc.SelectSingleNode("Academic");
                XmlNode addItem = CreateItemNodeDocUpload(doc, academic);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Academic");
                XmlNode addItem = CreateItemNodeDocUpload(doc, academic);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }

            doc.Save(filePathForAcaXML);

            //LoadGridwithXml();
        }

        private void CreateAddXml(Experience experience)
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists(filePathForEmpXML))
            {
                doc.Load(filePathForEmpXML);
                XmlNode rootNode = doc.SelectSingleNode("Experience");
                XmlNode addItem = CreateItemNodeDocUpload(doc, experience);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Experience");
                XmlNode addItem = CreateItemNodeDocUpload(doc, experience);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }

            doc.Save(filePathForEmpXML);

            //LoadGridwithXml();
        }

        private void CreateAddXml(Certificate certificate)
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists(filePathForPCerXML))
            {
                doc.Load(filePathForPCerXML);
                XmlNode rootNode = doc.SelectSingleNode("Certificates");
                XmlNode addItem = CreateItemNodeDocUpload(doc, certificate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Certificates");
                XmlNode addItem = CreateItemNodeDocUpload(doc, certificate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }

            doc.Save(filePathForPCerXML);
        }

        private void CreateAddXml(Training training)
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists(filePathForTraXML))
            {
                doc.Load(filePathForTraXML);
                XmlNode rootNode = doc.SelectSingleNode("Training");
                XmlNode addItem = CreateItemNodeDocUpload(doc, training);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Training");
                XmlNode addItem = CreateItemNodeDocUpload(doc, training);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }

            doc.Save(filePathForTraXML);

            //LoadGridwithXml();
        }

        private void CreateAddXml(Certificate certificate, string retired)
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists(filePathForRCerXML))
            {
                doc.Load(filePathForRCerXML);
                XmlNode rootNode = doc.SelectSingleNode("Certificates");
                XmlNode addItem = CreateItemNodeDocUpload(doc, certificate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Certificates");
                XmlNode addItem = CreateItemNodeDocUpload(doc, certificate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }

            doc.Save(filePathForRCerXML);
        }


        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, PersonalDetailsClass aPersonal)
        {
            XmlNode node = doc.CreateElement("Person");

            XmlAttribute FirstName = doc.CreateAttribute("firstName"); FirstName.Value = aPersonal.strFirstName;
            node.Attributes.Append(FirstName);

            XmlAttribute LastName = doc.CreateAttribute("lastName"); LastName.Value = aPersonal.strLastName;
            node.Attributes.Append(LastName);

            XmlAttribute FatherName = doc.CreateAttribute("fatherName"); FatherName.Value = aPersonal.strFatherName;
            node.Attributes.Append(FatherName);

            XmlAttribute MatherName = doc.CreateAttribute("matherName"); MatherName.Value = aPersonal.strMatherName;
            node.Attributes.Append(MatherName);

            XmlAttribute DateOfBirth = doc.CreateAttribute("dob"); DateOfBirth.Value = aPersonal.dteDateOfBirth.ToString();
            node.Attributes.Append(DateOfBirth);

            XmlAttribute Gender = doc.CreateAttribute("gender"); Gender.Value = aPersonal.strGender;
            node.Attributes.Append(Gender);

            XmlAttribute Religion = doc.CreateAttribute("religion"); Religion.Value = aPersonal.strReligion;
            node.Attributes.Append(Religion);

            XmlAttribute MaritalStatus = doc.CreateAttribute("maritalStatus"); MaritalStatus.Value = aPersonal.strMeritalStutas;
            node.Attributes.Append(MaritalStatus);

            XmlAttribute Nationality = doc.CreateAttribute("nationality"); Nationality.Value = aPersonal.strNational;
            node.Attributes.Append(Nationality);

            XmlAttribute NID = doc.CreateAttribute("nid"); NID.Value = aPersonal.strNID;
            node.Attributes.Append(NID);

            XmlAttribute PassportNo = doc.CreateAttribute("passportNo"); PassportNo.Value = aPersonal.strPassportNo;
            node.Attributes.Append(PassportNo);

            XmlAttribute PassportIssueDate = doc.CreateAttribute("passportIssueDate"); PassportIssueDate.Value = aPersonal.dtePassportIssueDate.ToString();
            node.Attributes.Append(PassportIssueDate);

            XmlAttribute Mobile1 = doc.CreateAttribute("mobile1"); Mobile1.Value = aPersonal.strMobile1;
            node.Attributes.Append(Mobile1);

            XmlAttribute Mobile2 = doc.CreateAttribute("mobile2"); Mobile2.Value = aPersonal.strMobile2;
            node.Attributes.Append(Mobile2);

            XmlAttribute Mobile3 = doc.CreateAttribute("mobile3"); Mobile3.Value = aPersonal.strMobile3;
            node.Attributes.Append(Mobile3);

            XmlAttribute MainEmail = doc.CreateAttribute("mainEmail"); MainEmail.Value = aPersonal.strMainEmail;
            node.Attributes.Append(MainEmail);

            XmlAttribute AltEmail = doc.CreateAttribute("altEmail"); AltEmail.Value = aPersonal.strAltEmail;
            node.Attributes.Append(AltEmail);

            XmlAttribute PresentAddress = doc.CreateAttribute("presentAddress"); PresentAddress.Value = aPersonal.strPresentAddress;
            node.Attributes.Append(PresentAddress);

            XmlAttribute ParmanentAddress = doc.CreateAttribute("parmanentAddress"); ParmanentAddress.Value = aPersonal.strParmanentAddress;
            node.Attributes.Append(ParmanentAddress);

            XmlAttribute Objective = doc.CreateAttribute("objective"); Objective.Value = aPersonal.strObjective;
            node.Attributes.Append(Objective);

            XmlAttribute ParmanentAddress2 = doc.CreateAttribute("parmanenetAddress"); ParmanentAddress2.Value = aPersonal.strParmanentAddress2;
            node.Attributes.Append(ParmanentAddress2);

            XmlAttribute PresentSalary = doc.CreateAttribute("presentSalary"); PresentSalary.Value = aPersonal.floatPresentSalary.ToString();
            node.Attributes.Append(PresentSalary);

            XmlAttribute ExpectedSalary = doc.CreateAttribute("expectedSalary"); ExpectedSalary.Value = aPersonal.floatExpectedSalary.ToString();
            node.Attributes.Append(ExpectedSalary);

            XmlAttribute JobLevel = doc.CreateAttribute("joblevel"); JobLevel.Value = aPersonal.strJobLavel;
            node.Attributes.Append(JobLevel);

            XmlAttribute JobNature = doc.CreateAttribute("jobnature"); JobNature.Value = aPersonal.strJobNature;
            node.Attributes.Append(JobNature);

            XmlAttribute CareerSummary = doc.CreateAttribute("careersummary"); CareerSummary.Value = aPersonal.strCareerSummary;
            node.Attributes.Append(CareerSummary);

            XmlAttribute SpecialQualification = doc.CreateAttribute("specialqualification"); SpecialQualification.Value = aPersonal.strSpecialQualification;
            node.Attributes.Append(SpecialQualification);

            XmlAttribute Keywords = doc.CreateAttribute("keywords"); Keywords.Value = aPersonal.strKeywords;
            node.Attributes.Append(Keywords);

            //XmlAttribute Image = doc.CreateAttribute("image"); Image.Value = Convert.ToBase64String(aPersonal.imgImage);
            //node.Attributes.Append(Image);

            return node;

        }

        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, Academic academic)
        {
            XmlNode elementNode = doc.CreateElement("SingleAcademic");

            XmlAttribute LevelofEducation = doc.CreateAttribute("strLevelofEducation"); LevelofEducation.Value = academic.strLevelofEducation;
            XmlAttribute ExamDegreeTitle = doc.CreateAttribute("strExamDegreeTitle"); ExamDegreeTitle.Value = academic.strExamDegreeTitle;
            XmlAttribute ConcentrationMajorGroup = doc.CreateAttribute("strConcentrationMajorGroup"); ConcentrationMajorGroup.Value = academic.strConcentrationMajorGroup;
            XmlAttribute InstituteName = doc.CreateAttribute("strInstituteName"); InstituteName.Value = academic.strInstituteName;
            XmlAttribute Achievement = doc.CreateAttribute("strAchievement"); Achievement.Value = academic.strAchievement;
            XmlAttribute Result = doc.CreateAttribute("strResult"); Result.Value = academic.strResult;
            XmlAttribute YearofPassing = doc.CreateAttribute("strYearofPassing"); YearofPassing.Value = academic.strYearofPassing;
            XmlAttribute Duration = doc.CreateAttribute("strDuration"); Duration.Value = academic.strDuration;

            elementNode.Attributes.Append(LevelofEducation);
            elementNode.Attributes.Append(ExamDegreeTitle);
            elementNode.Attributes.Append(ConcentrationMajorGroup);
            elementNode.Attributes.Append(InstituteName);
            elementNode.Attributes.Append(Achievement);
            elementNode.Attributes.Append(Result);
            elementNode.Attributes.Append(YearofPassing);
            elementNode.Attributes.Append(Duration);

            return elementNode;
        }

        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, Experience experience)
        {
            XmlNode elementNode = doc.CreateElement("SingleAcademic");

            XmlAttribute CompanyName = doc.CreateAttribute("strCompanyName"); CompanyName.Value = experience.strCompanyName;
            XmlAttribute CompanyBusiness = doc.CreateAttribute("strCompanyBusiness"); CompanyBusiness.Value = experience.strCompanyBusiness;
            XmlAttribute Designation = doc.CreateAttribute("strDesignation"); Designation.Value = experience.strDesignation;
            XmlAttribute Department = doc.CreateAttribute("strDepartment"); Department.Value = experience.strDepartment;
            XmlAttribute AreaofExperiences = doc.CreateAttribute("strAreaofExperiences"); AreaofExperiences.Value = experience.strAreaofExperiences;
            XmlAttribute Responsibilities = doc.CreateAttribute("strResponsibilities"); Responsibilities.Value = experience.strResponsibilities;
            XmlAttribute CompanyLocation = doc.CreateAttribute("strCompanyLocation"); CompanyLocation.Value = experience.strCompanyLocation;
            XmlAttribute EmploymentPeriod = doc.CreateAttribute("strEmploymentPeriod"); EmploymentPeriod.Value = experience.strEmploymentPeriod;

            elementNode.Attributes.Append(CompanyName);
            elementNode.Attributes.Append(CompanyBusiness);
            elementNode.Attributes.Append(Designation);
            elementNode.Attributes.Append(Department);
            elementNode.Attributes.Append(AreaofExperiences);
            elementNode.Attributes.Append(Responsibilities);
            elementNode.Attributes.Append(CompanyLocation);
            elementNode.Attributes.Append(EmploymentPeriod);

            return elementNode;
        }

        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, Certificate certificate)
        {
            XmlNode elementNode = doc.CreateElement("SingleCertificate");

            XmlAttribute ImgCertificate = doc.CreateAttribute("imgCertificate"); ImgCertificate.Value = String.Format("data:image/jpg;base64,{0}", certificate.imgCertificate);

            elementNode.Attributes.Append(ImgCertificate);

            return elementNode;
        }

        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, Training training)
        {
            XmlNode elementNode = doc.CreateElement("SingleTraining");

            XmlAttribute TrainingTitle = doc.CreateAttribute("strTrainingTitle"); TrainingTitle.Value = training.strTrainingTitle;
            XmlAttribute TopicsCovered = doc.CreateAttribute("strTopicsCovered"); TopicsCovered.Value = training.strTopicsCovered;
            XmlAttribute Institute = doc.CreateAttribute("strInstitute"); Institute.Value = training.strInstitute;
            XmlAttribute Location = doc.CreateAttribute("strLocation"); Location.Value = training.strLocation;
            XmlAttribute Country = doc.CreateAttribute("strCountry"); Country.Value = training.strCountry;
            XmlAttribute TrainingYear = doc.CreateAttribute("strTrainingYear"); TrainingYear.Value = training.strTrainingYear;
            XmlAttribute Duration = doc.CreateAttribute("strDuration"); Duration.Value = training.strDuration;

            elementNode.Attributes.Append(TrainingTitle);
            elementNode.Attributes.Append(TopicsCovered);
            elementNode.Attributes.Append(Institute);
            elementNode.Attributes.Append(Location);
            elementNode.Attributes.Append(Country);
            elementNode.Attributes.Append(TrainingYear);
            elementNode.Attributes.Append(Duration);

            return elementNode;
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtFatherName.ReadOnly = false;
            txtMatherName.ReadOnly = false;
            dteDOB.ReadOnly = false;
            // rdbGender.Enabled = true;
            txtGender.ReadOnly = false;
            txtReligion.ReadOnly = false;
            txtMaritalStatus.ReadOnly = false;
            //  rdbMaritalStatus.Enabled = true;

            txtNationality.ReadOnly = false;
            txtNID.ReadOnly = false;
            txtPassportNo.ReadOnly = false;
            dtePassportIssuDate.ReadOnly = false;
            txtMobile1.ReadOnly = false;
            txtMobile2.ReadOnly = false;
            txtMobile3.ReadOnly = false;
            txtMainEmail.ReadOnly = false;
            txtAltEmail.ReadOnly = false;

            txtPresentAddress.ReadOnly = false;
            txtParmanentAddress.ReadOnly = false;

            txtObjective.ReadOnly = false;
            txtParmanentAddress2.ReadOnly = false;
            txtPresentSalary.ReadOnly = false;
            txtExpectedSalary.ReadOnly = false;
            txtJobLevel.ReadOnly = false;
            txtJobNature.ReadOnly = false;

            txtCareerSummary.ReadOnly = false;
            txtSpecialQualification.ReadOnly = false;
            txtKeywords.ReadOnly = false;

            btnUpdate.Visible = true;
            btnEdit.Visible = false;
        }

        protected void btnEditAS_Click(object sender, EventArgs e)
        {
            strLevelofEducation.Visible = false;
            strDrpLevelofEducation.Visible = true;
            strExamDegreeTitle.Visible = false;
            strDrpExamDegreeTitle.Visible = true;

            strConcentrationMajorGroup.ReadOnly = false;
            strInstituteName.ReadOnly = false;
            strAchievement.ReadOnly = false;
            strResult.ReadOnly = false;
            strYearofPassing.ReadOnly = false;
            strDuration.ReadOnly = false;

            btnAddAS.Visible = true;
            btnSaveAS.Visible = true;
            btnDeleteAS.Visible = false;
            btnEditAS.Visible = false;
        }

        protected void btnEditTS_Click(object sender, EventArgs e)
        {
            strTrainingTitle.ReadOnly = false;
            strTopicsCovered.ReadOnly = false;
            strInstitute.ReadOnly = false;
            strLocation.ReadOnly = false;
            strCountry.Visible = true; strTxtCountry.Visible = false;
            strTrainingYear.ReadOnly = false;
            strDurationTS.ReadOnly = false;

            btnAddTS.Visible = true;
            btnSaveTS.Visible = true;
            btnDeleteTS.Visible = false;
            btnEditTS.Visible = false;
        }

        protected void btnEditEmp_Click(object sender, EventArgs e)
        {
            strCompanyName.ReadOnly = false;
            strCompanyBusiness.ReadOnly = false;
            strDesignation.ReadOnly = false;
            strDepartment.ReadOnly = false;
            strAreaofExperiences.ReadOnly = false;
            strResponsibilities.ReadOnly = false;
            strCompanyLocation.ReadOnly = false;
            strEmploymentPeriod.ReadOnly = false;

            btnAddEmp.Visible = true;
            btnSaveEmp.Visible = true;
            btnDeleteEmp.Visible = false;
            btnEditEmp.Visible = false;
        }


        protected void UiDesign()
        {
            strLevelofEducation.Visible = true;
            strDrpLevelofEducation.Visible = false;
            strLevelofEducation.Text = strDrpLevelofEducation.Text;

            strExamDegreeTitle.Visible = true;
            strDrpExamDegreeTitle.Visible = false;
            strExamDegreeTitle.Text = strDrpExamDegreeTitle.Text;

            strConcentrationMajorGroup.ReadOnly = true;
            strInstituteName.ReadOnly = true;
            strAchievement.ReadOnly = true;
            strResult.ReadOnly = true;
            strYearofPassing.ReadOnly = true;
            strDuration.ReadOnly = true;

            btnAddAS.Visible = false;
            btnSaveAS.Visible = false;
            btnDeleteAS.Visible = true;
            btnEditAS.Visible = true;
        }

        private byte[] imageByte(HttpPostedFile postedFile)
        {

            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;
            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".bmp")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                bytes = binaryReader.ReadBytes((int)stream.Length);
            }
            return (bytes);
        }

        bool ValidationSearch()
        {
            lblValidationMsg.Text = "";

            if (strConcentrationMajorGroup.Text == "")
                lblValidationMsg.Text = lblValidationMsg.Text + "Concentration/Major/Group field is empty\n";
            if (strInstituteName.Text == "")
                lblValidationMsg.Text = lblValidationMsg.Text + "Institute Name field is empty\n";
            if (strAchievement.Text == "")
                lblValidationMsg.Text = lblValidationMsg.Text + "Achievement field is empty\n";
            if (strResult.Text == "")
                lblValidationMsg.Text = lblValidationMsg.Text + "Result field is empty\n";
            if (strYearofPassing.Text == "")
                lblValidationMsg.Text = lblValidationMsg.Text + "Year of Passing field is empty\n";
            if (strDuration.Text == "")
                lblValidationMsg.Text = lblValidationMsg.Text + "Duration field is empty\n";


            if (lblValidationMsg.Text == "")
            {
                lblValidationMsg.Text = "Data are successfully added\n";
                return true;
            }
            else return false;
        }
    }
}