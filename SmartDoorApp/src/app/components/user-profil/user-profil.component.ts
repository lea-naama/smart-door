import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'user-profil',
  templateUrl: './user-profil.component.html',
  styleUrls: ['./user-profil.component.scss']
})
export class UserProfilComponent implements OnInit {

  constructor(public userService:UserService,
    private router: Router) { }

  ngOnInit(): void {
    
  }

  GoToUserDetails(){
    this.userService.userEditAvailable = false;
    this.router.navigate(['shell/employee-details']);

  }

}
