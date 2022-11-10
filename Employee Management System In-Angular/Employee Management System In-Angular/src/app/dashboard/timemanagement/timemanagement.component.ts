import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { TimeManagementInterface } from 'src/app/Interface/interface';
import { DataService } from 'src/service/data.service';

@Component({
  selector: 'app-timemanagement',
  templateUrl: './timemanagement.component.html',
  styleUrls: ['./timemanagement.component.scss']
})
export class TimemanagementComponent implements OnInit {

  Id = 0
  MonthlyTotalHour = 0
  MonthlyMinHour = 0
  closeResult = '';
  Update = false
  TotalPages = 0
  PageNumber = 0
  // List: TimeManagementInterface[] = []
  List: TimeManagementInterface[] = []

  constructor(private modalService: NgbModal, private dataService: DataService) {

  }

  ngOnInit(): void {
    // this.GetHours()
    this.GetHours()
  }

  // Start Model

  open(content: any, MonthlyTotalHour: number, MonthlyMinHour: number, operation: string) {

    if (MonthlyTotalHour !== 0) {
      //Update
      debugger;
      console.log("Update Data Operation. MonthlyTotalHour : ", MonthlyTotalHour, " MonthlyMinHour : ", MonthlyMinHour);
      this.Update = true
      this.MonthlyTotalHour = MonthlyTotalHour
      this.MonthlyMinHour = MonthlyMinHour
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

  GetHours() {
    this.dataService
      .GetHours()
      .subscribe((data: any) => {
        debugger
        console.log("Data : ", data);
        if (data?.isSuccess) {
          this.Update = true
          this.Id = data?.data.id
          this.MonthlyTotalHour = data?.data.monthlyTotalHour
          this.MonthlyMinHour = data?.data.monthlyMinHour
          console.log("List : ", this.List);
        } else {
          this.Update = false
        }
      })
  }

  handlePagination(event: any) {
    console.log("Page : ", event);
    this.PageNumber = event
    this.GetHours()
  }

  handleChange(event: any) {
    const { id, value } = event.target
    console.log("Id : ", id, " Value : ", value);
    if (id === "monthlyTotalHour") { this.MonthlyTotalHour = value === "" ? 0 : value } else
      if (id === "monthlyMinHour") { this.MonthlyMinHour = value === "" ? 0 : value }
  }

  handelAddHours() {
    debugger
    console.log("Add Method Calling...");
    if (this.MonthlyTotalHour === 0 || this.MonthlyMinHour === 0) {
      alert("Please Enter Required Field. Example : MonthlyTotalHour, MonthlyMinHour.");
      this.GetHours()
      return;
    }

    this.dataService
      .AddHours(Number(this.MonthlyTotalHour), Number(this.MonthlyMinHour))
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetHours()
      })

  }

  handleUpdate() {
    console.log("Update Method Calling...");
    debugger
    if (this.MonthlyTotalHour === 0 || this.MonthlyMinHour === 0) {
      alert("Please Enter Required Field. Example : MonthlyTotalHour, MonthlyMinHour.");
      this.GetHours()
      return;
    }

    this.dataService
      .UpdateHours(this.Id, Number(this.MonthlyTotalHour), Number(this.MonthlyMinHour))
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetHours()
      })
  }

  handleDelete() {
    debugger
    this.dataService
      .DeleteHours(this.Id)
      .subscribe((data) => {
        console.log("Data : ", data);
        this.GetHours()
      })
  }

}
