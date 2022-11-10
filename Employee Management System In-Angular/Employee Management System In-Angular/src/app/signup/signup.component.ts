import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/service/data.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  Username = ""
  Password = ""
  ConfirmPassword = ""
  MasterPassword = ""
  UsernameFlag = false
  PasswordFlag = false
  ConfirmPasswordFlag = false
  MasterPasswordFlag = false
  MasterPasswordInputFlag = false
  Role = "student"

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
  }

  handleChange(event: any) {
    const { name, value } = event.target
    console.log('Name : ', name, ' Value : ', value)
    if (name == "Username") {
      this.Username = value
    }
    if (name == "Password") {
      this.Password = value
    }
    if (name == "ConfirmPassword") {
      this.ConfirmPassword = value
    }
  
  }

  handleSubmit() {
    this.UsernameFlag = false;
    this.PasswordFlag = false;
    this.ConfirmPasswordFlag = false;
    // this.MasterPasswordFlag = false;
    this.MasterPasswordInputFlag = false;
    if (this.Username == "") {
      this.UsernameFlag = true
    }
    if (this.Password == "") {
      this.PasswordFlag = true
    }
    if (this.ConfirmPassword == "") {
      this.ConfirmPasswordFlag = true
    }

    if (!this.UsernameFlag && !this.PasswordFlag && !this.ConfirmPasswordFlag) {
      console.log("API Calling");
      if (this.Password != this.ConfirmPassword) {
        alert("Password & Confirm Password Not Match")
        return
      }

      this.dataService
        .SignUp(this.Username, this.Password)
        .subscribe((data: any) => {
          console.log("Data : ", data);
          alert(data?.message)
          if (data?.isSuccess) {
            window.location.href = "/"
          }
        })

    }
  }

  redirectToSignIn() {
    window.location.href = "/"
  }

}
