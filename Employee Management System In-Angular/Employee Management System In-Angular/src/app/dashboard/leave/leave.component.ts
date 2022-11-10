import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { GetAllEmployeeIdInterface } from 'src/app/Interface/interface';
import { DataService } from 'src/service/data.service';

@Component({
  selector: 'app-leave',
  templateUrl: './leave.component.html',
  styleUrls: ['./leave.component.scss']
})
export class LeaveComponent implements OnInit {

  Id = 0
  EmployeeID = ""
  Type = ""
  FromLeaveDate = ""
  ToLeaveDate = ""
  Reason = ""
  PaymentAmount = 0
  closeResult = '';
  Update = false
  TotalPages = 0
  PageNumber = 0
  // List: TimeManagementInterface[] = []
  List: any = []
  EmployeeIdList: GetAllEmployeeIdInterface[] = []

  constructor(private modalService: NgbModal, private dataService: DataService) {

  }

  ngOnInit(): void {
    // this.GetDesignation(1)
    this.GetLeave(1)
    this.GetAllEmployeeId()
  }

  // Start Model

  open(content: any, data: any, operation: string) {
    debugger
    if (data !== null) {
      //Update
      debugger;
      console.log("Update Data Operation. Data : ", data);
      this.Update = true
      this.Id = data.id
      this.EmployeeID = data.employeeId
      this.Type = data.type
      this.FromLeaveDate = data.fromLeaveDate
      this.ToLeaveDate = data.toLeaveDate
      this.Reason = data.reason
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


  GetLeave(PageNumber: number) {
    debugger
    this.dataService
      .GetLeave(PageNumber, 7)
      .subscribe((data: any) => {
        debugger
        console.log("Data : ", data);
        if (data?.isSuccess) {
          this.Update = false
          this.List = data?.data;
          this.TotalPages = data?.totalPage
          console.log("List : ", this.List);
        } else {
          if(this.PageNumber>1 && data?.data === null)
          {
            this.GetLeave(this.PageNumber-1)
            this.PageNumber = this.PageNumber-1
          }
          this.Update = false
        }
      })
  }

  GetAllEmployeeId() {
    this.dataService
      .GetAllEmployeeId()
      .subscribe((data: any) => {
        console.log("GetAllEmployeeId Data : ", data);
        this.EmployeeIdList = data?.data
      })
  }

  handlePagination(event: any) {
    console.log("Page : ", event);
    this.PageNumber = event
    this.GetLeave(this.PageNumber)
  }

  handleChange(event: any) {
    const { id, value } = event.target
    console.log("Id : ", id, " Value : ", value);
    if (id === "employeeId") { this.EmployeeID = value } else
      if (id === "type") { if (value !== "") { this.Type = value } } else
        if (id === "fromleaveDate") { if (value !== "") { this.FromLeaveDate = value } } else
          if (id === "toleaveDate") { if (value !== "") { this.ToLeaveDate = value } } else
            if (id === "reason") { this.Reason = value }
  }

  handelAddPayment() {
    console.log("Add Method Calling...");
    if (this.EmployeeID === "" || this.Type === "" || this.FromLeaveDate === "" || this.ToLeaveDate === "") {
      alert("Please Enter Required Field. Example : EmployeeID : " + this.EmployeeID + " Type : " + this.Type + " FromLeaveDate : " + this.FromLeaveDate + " ToLeaveDate : " + this.ToLeaveDate);
      return;
    }

    this.dataService
      .AddLeave(this.EmployeeID, this.Type, this.FromLeaveDate, this.ToLeaveDate, this.Reason)
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetLeave(this.PageNumber)
      })

  }

  handleUpdate() {
    console.log("Update Method Calling...");

    if (this.EmployeeID === "" || this.Type === "" || this.FromLeaveDate === "" || this.ToLeaveDate === "") {
      alert("Please Enter Required Field. Example : EmployeeID, Type, FromLeaveDate, ToLeaveDate.");
      return;
    }

    this.dataService
      .UpdateLeave(this.Id, this.EmployeeID, this.Type, this.FromLeaveDate, this.ToLeaveDate, this.Reason)
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetLeave(this.PageNumber)
      })
  }

  handleDelete(ID: any) {
    this.dataService
      .DeleteLeave(ID)
      .subscribe((data) => {
        console.log("Data : ", data);
        this.GetLeave(this.PageNumber)
      })
  }


}
