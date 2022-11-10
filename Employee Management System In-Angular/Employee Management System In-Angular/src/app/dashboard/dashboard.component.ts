import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  Employee = true;
  Designation = false;
  Payment = false;
  TimeManagement = false;
  Leave = false;

  EmployeeSelector = true;
  DesignationSelector = false;
  PaymentSelector = false;
  TimeManagementSelector = false;
  LeaveSelector = false;

  constructor() { }

  ngOnInit(): void {
  }

  handleNav(option: string) {
    if (option == "Employee") {
      this.handleReset()
      this.Employee = true;
      this.EmployeeSelector = true;
    } else
      if (option == "Designation") {
        this.handleReset()
        this.Designation = true;
        this.DesignationSelector = true;
      } else
        if (option == "Payment") {
          this.handleReset()
          this.Payment = true;
          this.PaymentSelector = true;

        } else
          if (option == "TimeManagement") {
            this.handleReset()
            this.TimeManagement = true;
            this.TimeManagementSelector = true;

          } else
            if (option == "Leave") {
              this.handleReset()
              this.Leave = true;
              this.LeaveSelector = true;

            } 
  }

  handleReset() {
    this.Employee = false;
    this.Designation = false;
    this.Payment = false;
    this.TimeManagement = false;
    this.Leave = false;

    this.EmployeeSelector = false;
    this.DesignationSelector = false;
    this.PaymentSelector = false;
    this.TimeManagementSelector = false;
    this.LeaveSelector = false;
  }

}
