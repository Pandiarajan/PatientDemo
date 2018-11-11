using PatientDemographics.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;

namespace PatientDemographics.Repository
{
    public class XmlConverter : IXmlConverter
    {
        private void CreatePhoneNumberTable(DataTable phoneNumberTable)
        {
            phoneNumberTable.Columns.Add(nameof(Patient.Id));
            phoneNumberTable.Columns.Add("PhoneTypeId");
            phoneNumberTable.Columns.Add(nameof(TelephoneNumber.Number));
        }

        private void CreatePatientTable(DataTable patientTable)
        {
            patientTable.Columns.Add(nameof(Patient.Id));
            patientTable.Columns.Add(nameof(Patient.Forename));
            patientTable.Columns.Add(nameof(Patient.Surname));
            patientTable.Columns.Add(nameof(Patient.DateOfBirth));
            patientTable.Columns.Add(nameof(Patient.Gender));
        }


        public string GetXml(Patient patient)
        {
            DataSet dataSet = new DataSet();
            var patientTable = dataSet.Tables.Add(RepoConstants.PatientTableName);
            CreatePatientTable(patientTable);
            var phoneNumberTable = dataSet.Tables.Add(RepoConstants.PhoneTableName);
            CreatePhoneNumberTable(phoneNumberTable);
            DataTable dt = dataSet.Tables[RepoConstants.PatientTableName] as DataTable;
            dt.Rows.Add(patient.Id, patient.Forename, patient.Surname, patient.DateOfBirth, patient.Gender.Name);

            DataTable dtPhone = dataSet.Tables[RepoConstants.PhoneTableName] as DataTable;
            if (patient.TelephoneNumbers != null)
            {
                foreach (var phoneNumber in patient.TelephoneNumbers)
                {
                    dtPhone.Rows.Add(patient.Id, phoneNumber.PhoneType.Id, phoneNumber.Number);
                }
            }
            StringWriter stringWriter = new StringWriter();
            dataSet.WriteXml(stringWriter);
            return stringWriter.ToString();
        }

        public Patient GetPatient(string patientXml)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(XmlReader.Create(new StringReader(patientXml)));
            DataTable dt = dataSet.Tables[RepoConstants.PatientTableName] as DataTable;
            return (from DataRow row in dt.Rows

                        select new Patient(
                            Guid.Parse(row[nameof(Patient.Id)].ToString()),
                            row[nameof(Patient.Forename)].ToString(),
                            row[nameof(Patient.Surname)].ToString(),
                            DateTime.Parse(row[nameof(Patient.DateOfBirth)].ToString()),
                            Gender.GetGender(row[nameof(Patient.Gender)].ToString())
                        )).Single();
        }
    }
}
