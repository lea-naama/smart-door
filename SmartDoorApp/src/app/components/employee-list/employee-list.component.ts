import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SubEmployee } from 'src/app/models/SubEmployee';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  employeeList :Array<SubEmployee>=new Array<SubEmployee>();
  constructor(private userService : UserService, 
    private router: Router) { }

  ngOnInit(): void {
    debugger;
    this.employeeList = JSON.parse(localStorage.getItem('employees'));
    console.log(this.employeeList);
  }
  GoToAttendance(id: number){
    this.router.navigate(['shell/attandance/',id]);
  }

}
