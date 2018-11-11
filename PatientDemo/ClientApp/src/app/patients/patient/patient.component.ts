import { Component, OnInit } from '@angular/core';
import {PatientService} from '../shared/patient.service'
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {

  constructor(private patientService: PatientService) { }

  ngOnInit() {
    this.resetForm()
  }
resetForm(form? : NgForm)
{
  if(form != null)
    form.reset();
  this.patientService.selectedPatient = {
    id : null,
    forename:'',
    surname: '',
    dateOfBirth:null,
    gender:'',
    phoneNumber:'',
    phoneType:''
  }
}
onSubmitForm(form: NgForm)
{
  this.patientService.postPatient(form.value)
  .subscribe(data => {
    this.resetForm(form);
    this.patientService.getEmployeeList();
  })
}
selectedPhoneType = this.patientService.phoneTypes[0];
}
