import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from 'src/service/data.service';
import { DesignationListInterface } from 'src/app/Interface/interface';

@Component({
  selector: 'app-designation',
  templateUrl: './designation.component.html',
  styleUrls: ['./designation.component.scss']
})
export class DesignationComponent implements OnInit {

  Id = 0
  DesignationName = ""
  closeResult = '';
  Update = false
  TotalPages = 0
  PageNumber = 0
  List: DesignationListInterface[] = []

  constructor(private modalService: NgbModal, private dataService: DataService) { }

  ngOnInit(): void {
  }

  // Start Model

  open(content: any, data: any, operation: string) {

    if (data !== null) {
      //Update
      console.log("Update Data Operation. Data : ", data);
      this.Update = true
      this.Id = data.id
      this.DesignationName = data.designationName
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


  GetDesignation(PageNumber: number) {
    this.dataService
      .GetDesignation(PageNumber, 7)
      .subscribe((data: any) => {
        console.log("Data : ", data);
        if (data?.isSuccess) {
          this.List = data?.data as DesignationListInterface[];
          this.TotalPages = data?.totalPage
        } else {
          if (this.PageNumber > 1 && data?.data === null) {
            this.GetDesignation(this.PageNumber - 1)
            this.PageNumber = this.PageNumber - 1
          }
          this.List = []
        }
      })
  }

  handlePagination(event: any) {
    console.log("Page : ", event);
    this.PageNumber = event
    this.GetDesignation(event)
  }

  handleChange(event: any) {
    const { id, value } = event.target
    console.log("Id : ", id, " Value : ", value);
    if (id === "designationName") { this.DesignationName = value }
  }

  handelAddDesignation() {
    console.log("Add Method Calling...");
    if (this.DesignationName === "") {
      alert("Please Enter Required Field. Example : DesignationName.");
      return;
    }

    this.dataService
      .AddDesignation(this.DesignationName)
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetDesignation(this.PageNumber)
      })

  }

  handleUpdate() {
    console.log("Update Method Calling...");

    if (this.DesignationName === "") {
      alert("Please Enter Required Field. Example : DesignationName.");
      return;
    }

    this.dataService
      .UpdateDesignation(this.Id, this.DesignationName)
      .subscribe((data: any) => {
        console.log("Data", data);
        this.Update = false
        this.GetDesignation(this.PageNumber)
      })
  }

  handleDelete(ID: any) {
    this.dataService
      .DeleteDesignation(ID)
      .subscribe((data) => {
        console.log("Data : ", data);
        this.GetDesignation(this.PageNumber)
      })
  }

}
