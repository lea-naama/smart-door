import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dialog-log-in',
  templateUrl: './dialog-log-in.component.html',
  styleUrls: ['./dialog-log-in.component.scss']
})
export class DialogLogInComponent implements OnInit {

  constructor(private userService: UserService,
    private router:Router) { }

  ngOnInit(): void {
  }

  LogInAsAdmin(){
    console.log('admin');
    this.userService.isManager = true;
    localStorage.setItem('isManager', JSON.stringify(true));
    this.router.navigate(['shell/employee-list']);
  }

  LogInAsEmployee(){
    console.log('no admin');
    this.router.navigate(['shell/attandance/',  JSON.parse(localStorage.getItem('user')).id]);
  }

}
