import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { DesignationListInterface, EmployeeListInterface } from 'src/app/Interface/interface';
import { DataService } from 'src/service/data.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  closeResult = '';
  Id = 0
  EmployeeId = ""
  EmployeeName = ""
  Designation = "None"
  Email = ""
  MobileNumber = ""
  Address = ""
  Update = false
  TotalPages = 0
  PageNumber = 0
  List: EmployeeListInterface[] = []
  List1: DesignationListInterface[] = []

  constructor(private modalService: NgbModal, private dataService: DataService) { }

  ngOnInit(): void {
    this.GetEmployee(1);
    this.GetAllDesignation();
  }

  // Start Model

  open(content: any, data: any, operation: string) {

    if (data !== null) {
      //Update
      console.log("Update Data Operation. Data : ", data);
      this.Update = true
      this.Id = data.id
      this.EmployeeId = data.employeeID
      this.EmployeeName = data.employeeName
      this.MobileNumber = data.phoneNumber
      this.Email = data.email
      this.Address = data.address
      this.Designation = data.designation
    } else {
      this.Update = false
    }

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
      (result) => {
        this.closeResult = `Closed with: ${result}`;
      },
      (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      },
    );
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  // End Model

  GetEmployee(PageNumber: number) {
    this.dataService
      .GetEmployee(PageNumber, 7)
      .subscribe((data: any) => {
        console.log("Data : ", data);
        if (data?.isSuccess) {
          this.List = data?.data as EmployeeListInterface[];
          this.TotalPages = data?.totalPage
        }
      })
  }

  GetAllDesignation() {
    this.dataService
      .GetAllDesignation()
      .subscribe((data: any) => {
        console.log("Data : ", data);
        if (data?.isSuccess) {
          this.List1 = data?.data as DesignationListInterface[];
          // this.TotalPages = data?.totalPage
        }
      })
  }

  handlePagination(event: any) {
    console.log("Page : ", event);
    this.PageNumber = event
    this.GetEmployee(event)
  }

  handleChange(event: any) {
    const { id, value } = event.target
    console.log("Id : ", id, " Value : ", value);
    if (id === "employeeId") { this.EmployeeId = value } else
      if (id === "employeeName") { this.EmployeeName = value } else
        if (id === "mobileNumber") { this.MobileNumber = value } else
          if (id === "email") { this.Email = value } else
            if (id === "address") { this.Address = value } else
              if (id === "designation") { if (value !== "") { this.Designation = value } }
  }

  handelAddEmployee() {
    console.log("Add Method Calling...");
    if (this.EmployeeId === "" || this.EmployeeName === "" || this.MobileNumber === "") {
      alert("Please Enter Required Field. Example : EmployeeId , EmployeeName , MobileNumber.");
      return;
    }

    this.dataService
      .AddEmployee(this.EmployeeId, this.EmployeeName, this.MobileNumber, this.Email, this.Address, this.Designation)
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetEmployee(this.PageNumber)
      })

  }

  handleUpdate() {
    console.log("Update Method Calling...");

    if (this.EmployeeId === "" || this.EmployeeName === "" || this.MobileNumber === "") {
      alert("Please Enter Required Field. Example : EmployeeId , EmployeeName , MobileNumber.");
      return;
    }

    this.dataService
      .UpdateEmployee(this.Id, this.EmployeeId, this.EmployeeName, this.MobileNumber, this.Email, this.Address, this.Designation)
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetEmployee(this.PageNumber)
      })
  }

  handleDelete(ID: number) {
    this.dataService
      .DeleteEmployee(ID)
      .subscribe((data: any) => {
        console.log("Data : ", data);
        this.GetEmployee(this.PageNumber)
      })
  }

}
