import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { PatientsComponent } from './patients/patients.component';
import { PatientComponent } from './patients/patient/patient.component';
import { PatientListComponent } from './patients/patient-list/patient-list.component';

@NgModule({
  declarations: [
    AppComponent,
    PatientsComponent,
    PatientsComponent,
    PatientComponent,
    PatientListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PatientsComponent, pathMatch: 'full' }
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
