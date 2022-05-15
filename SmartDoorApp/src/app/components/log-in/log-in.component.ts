import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LogInRequest } from 'src/app/models/logInRequest';
import { DataService } from 'src/app/services/data.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { UserService } from 'src/app/services/user.service';
import { DialogLogInComponent } from '../dialog-log-in/dialog-log-in.component';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  public logInBtnClicked: boolean = false;
  public logInError: boolean = false;
  public logInNoContent: boolean = false;
  public errorMsg = ',' + 'משתמש אינו קיים במערכת' + '\n' + '.' + 'שם משתמש או סיסמא שגויים';

  constructor(private router: Router,
    private dataService: DataService,
    private employeeService: EmployeeService,
    public dialog: MatDialog,
    private userService: UserService) {
  }

  ngOnInit(): void {
  }

  public logInForm: FormGroup = new FormGroup({
    userName: new FormControl('', Validators.email),
    password: new FormControl('', Validators.minLength(6))
  });




  LogIn() {
    this.logInBtnClicked = true;
    this.logInNoContent = false;
    let logInRequest: LogInRequest = {
      userName: this.logInForm.value.userName,
      password: this.logInForm.value.password
    }
    this.dataService.GetUser(logInRequest).subscribe(response => {
      debugger;
      if (response != null && response.user != null) {
        debugger;
        console.log(response.user.email, response.user.password);               
        this.userService.employeeList = response.employeeList;
        localStorage.setItem('user', JSON.stringify(response.user));
        if (response.employeeList.length > 0) {
          this.OpenDialog();
        }
        else {
          this.router.navigate(['shell/attandance']);
        }

        this.logInBtnClicked = false;

      }
      else {
        this.logInNoContent = true;
        this.logInBtnClicked = false;
      }
    }, error => {
      this.logInError = true;
      this.logInBtnClicked = false;
      console.log(error);
      alert("אחד מהנתונים שגויים");
    });
  }

  OpenDialog() {
    this.dialog.open(DialogLogInComponent);
  }


}
