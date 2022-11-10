import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { DesignationListInterface } from 'src/app/Interface/interface';
import { DataService } from 'src/service/data.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})

export class PaymentComponent implements OnInit {

  Id = 0
  Designation = ""
  PaymentAmount = 0
  closeResult = '';
  Update = false
  TotalPages = 0
  PageNumber = 0
  // List: TimeManagementInterface[] = []
  List: any = []

  constructor(private modalService: NgbModal, private dataService: DataService) {

  }

  ngOnInit(): void {
    // this.GetDesignation(1)
    this.GetPayment(1)
  }

  // Start Model

  open(content: any, data: any, operation: string) {

    if (data !== null) {
      //Update
      // debugger;
      console.log("Update Data Operation. Data : ", data);
      this.Update = true
      this.Id = data.id
      this.Designation = data.designationName
      this.PaymentAmount = data.payment
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
  GetPayment(PageNumber:number) {
    this.dataService
      .GetPayment(PageNumber, 7)
      .subscribe((data: any) => {
        // debugger
        console.log("Data : ", data);
        if (data?.isSuccess) {
          this.Update = true
          this.List = data?.data;
          this.TotalPages = data?.totalPage;
          console.log("List : ", this.List);
        } else {
          this.Update = false
        }
      })
  }

  handlePagination(event: any) {
    console.log("Page : ", event);
    this.PageNumber = event
    this.GetPayment(this.PageNumber)
  }

  handleChange(event: any) {
    const { id, value } = event.target
    console.log("Id : ", id, " Value : ", value);
    if (id === "designation") { this.Designation = value } else
      if (id === "paymentAmount") { this.PaymentAmount = value }
  }

  handelAddPayment() {
    console.log("Add Method Calling...");
    if (this.Designation === "" || this.PaymentAmount === 0) {
      alert("Please Enter Required Field. Example : Designation, PaymentAmount.");
      return;
    }

    this.dataService
      .AddPayment(this.Designation, Number(this.PaymentAmount))
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetPayment(this.PageNumber)
      })

  }

  handleUpdate() {
    console.log("Update Method Calling...");

    if (this.Designation === "" || this.PaymentAmount == 0) {
      alert("Please Enter Required Field. Example : Designation, PaymentAmount.");
      return;
    }

    this.dataService
      .UpdatePayment(this.Id, this.Designation, Number(this.PaymentAmount))
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetPayment(this.PageNumber)
      })
  }

  handleDelete(ID: any) {
    this.dataService
      .DeletePayment(ID)
      .subscribe((data) => {
        console.log("Data : ", data);
        this.GetPayment(this.PageNumber)
      })
  }

}
