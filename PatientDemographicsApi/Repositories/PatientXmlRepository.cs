using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using PatientDemographicsApi.Model;
using System.Linq;
using PatientDemographicsApi.Config;

namespace PatientDemographicsApi.Repositories
{
    public class PatientXmlRepository : IPatientRepository
    {
        public bool CanSave(Patient patient)
        {
            if (Get().Any(patient.IsDuplicate()))
                return false;

            DataSet dataSet = new DataSet();
            if (File.Exists(Constants.DataSetFileName))
            {
                dataSet.ReadXml(Constants.DataSetFileName);
            }
            else
            {
                var patientTable = dataSet.Tables.Add(Constants.PatientTableName);
                CreatePatientTable(patientTable);
                var phoneNumberTable = dataSet.Tables.Add(Constants.PhoneTableName);
                CreatePhoneNumberTable(phoneNumberTable);
            }
            DataTable dt = dataSet.Tables[Constants.PatientTableName] as DataTable;
            dt.Rows.Add(patient.Id, patient.Forename, patient.Surname, patient.DateOfBirth, patient.Gender.Name);

            DataTable dtPhone = dataSet.Tables[Constants.PhoneTableName] as DataTable;
            foreach (var phoneNumber in patient.TelephoneNumbers)
            {
                dtPhone.Rows.Add(patient.Id, phoneNumber.PhoneType.Id, phoneNumber.Number);
            }
            
            dataSet.WriteXml(Constants.DataSetFileName);
            return true;
        }

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

        public IEnumerable<Patient> Get()
        {
            List<Patient> patients = new List<Patient>();
            DataSet dataSet = new DataSet();
            if (File.Exists(Constants.DataSetFileName))
            {
                dataSet.ReadXml(Constants.DataSetFileName);
                DataTable dt = dataSet.Tables[Constants.PatientTableName] as DataTable;
                patients = (from DataRow row in dt.Rows

                            select new Patient(
                                Guid.Parse(row[nameof(Patient.Id)].ToString()),
                                row[nameof(Patient.Forename)].ToString(),
                                row[nameof(Patient.Surname)].ToString(),
                                DateTime.Parse(row[nameof(Patient.DateOfBirth)].ToString()),
                                Gender.GetGender(row[nameof(Patient.Gender)].ToString())
                            )).ToList();
            }
            return patients;
        }

        public Patient Get(Guid patientId)
        {
            return Get().FirstOrDefault(p => p.Id == patientId);
        }
    }
}
