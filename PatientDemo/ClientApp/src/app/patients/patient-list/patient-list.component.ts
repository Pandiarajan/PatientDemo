import { Component, OnInit } from '@angular/core';
import {PatientService} from '../shared/patient.service'

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {

  constructor(private patientService: PatientService) { }

  ngOnInit() {
    this.patientService.getEmployeeList();
  }

}
