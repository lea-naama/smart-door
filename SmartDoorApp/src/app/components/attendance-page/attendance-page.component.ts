import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-attendance-page',
  templateUrl: './attendance-page.component.html',
  styleUrls: ['./attendance-page.component.scss']
})
export class AttendancePageComponent implements OnInit {

  public greetingMsg = '';

  constructor(private employeeService :EmployeeService, private userService: UserService) { }

  ngOnInit(): void {
    this.greetingMsg =  this.userService.user.firstName + this.userService.user.lastName;

  }

}
