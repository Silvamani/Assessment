import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeComponent } from './dashboard/employee/employee.component';
import { DesignationComponent } from './dashboard/designation/designation.component';
import { TimemanagementComponent } from './dashboard/timemanagement/timemanagement.component';
import { PaymentComponent } from './dashboard/payment/payment.component';
import { LeaveComponent } from './dashboard/leave/leave.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    SigninComponent,
    SignupComponent,
    EmployeeComponent,
    DesignationComponent,
    TimemanagementComponent,
    PaymentComponent,
    LeaveComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
