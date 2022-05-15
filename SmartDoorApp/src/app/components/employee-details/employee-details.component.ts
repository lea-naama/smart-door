import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.scss']
})
export class EmployeeDetailsComponent implements OnInit {

  employee : Employee;
  public employeeForm : FormGroup = new FormGroup({
    firstName: new FormControl(),
    lastName: new FormControl(),
    phone: new FormControl(),
    address: new FormControl(),
    email: new FormControl(),
    id: new FormControl(),
    employeeId: new FormControl(),
    password: new FormControl(),
    department: new FormControl(),
    manager: new FormControl(),
    hours: new FormControl(),
    image: new FormControl(),
  });
  constructor(private userService : UserService,
    private employeeService: EmployeeService) { }

  ngOnInit(): void {

  }

  GetEmployeeById(id : number){
   this.employeeService.GetEmployeeById(id).subscribe(res=>{
      if(res!= null){
        this.employee = res;
      }
      else{
        alert("לא נמצאו נתונים לעובד עבור מספר זהות : "+ id);
      }
    }, error=>{
      console.log(error);
      alert('תקלה בנתוני עובד');
    });
  }

}
