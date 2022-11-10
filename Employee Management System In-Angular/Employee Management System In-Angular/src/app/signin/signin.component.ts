import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/service/data.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {

  constructor(private dataService: DataService) { }
  UserName = ""
  Password = ""
  Role = "Student"
  UserNameFlag = false
  PasswordFlag = false

  ngOnInit(): void {
  }

  handleChange(event: any) {
    const { name, value } = event.target;
    console.log("Name : ", name, " Value : ", value);
    if (name == "UserName") {
      this.UserName = value
    }

    if (name == "Password") {
      this.Password = value
    }

  }

  handleSubmit() {
    this.UserNameFlag = false;
    this.PasswordFlag = false;

    if (this.UserName == "") {
      this.UserNameFlag = true;
    }

    if (this.Password == "") {
      this.PasswordFlag = true;
    }

    if (!this.UserNameFlag && !this.PasswordFlag) {
      this.dataService
        .SignIn(this.UserName, this.Password)
        .subscribe((data: any) => {
          console.log("Data : ", data);
          if (data?.isSuccess) {
            window.location.href = "/dashboard"
          }
        })
    }
  }

  redirectToSignIn() {
    window.location.href = "/signup"
  }

}
