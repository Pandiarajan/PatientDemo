import { Injectable, Inject } from '@angular/core';
import {Http, Response, Headers, RequestOptions, RequestMethod} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import {Patient} from './patient.model';

@Injectable()
export class PatientService {
  phoneTypes : Array<string> = ['MobilePhone', 'HomePhone','WorkPhone']
  selectedPatient : Patient;
  patientList : Patient[];
  constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

  postPatient(patient: Patient)
  {
      var body = JSON.stringify(patient);
      var headerOptions = new Headers ({'Content-Type': 'appliction/json'});
      var requestOptions = new RequestOptions({method:RequestMethod.Post, headers: headerOptions});
      return this.http.post(this.baseUrl + 'api/Patients', body, requestOptions).map(x => x.json());
  }
  getEmployeeList()
  {
    this.http.get(this.baseUrl + 'api/Patients')
    .map((data: Response) => {
      return data.json() as Patient[];
    }).toPromise().then(x => {
      this.patientList = x;
    })
  }
}
