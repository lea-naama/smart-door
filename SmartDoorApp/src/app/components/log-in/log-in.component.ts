import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  logInForm = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl('')
  });




  go(){
    
    console.log(this.logInForm.value.password);
    console.log(this.logInForm.value.userName);
    this.router.navigate(['shell/attandance']);
  }

}
