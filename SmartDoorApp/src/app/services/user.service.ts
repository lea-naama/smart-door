import { Injectable } from '@angular/core';
import { SubEmployee } from '../models/SubEmployee';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  _user: User = new User();
  employeeList : Array<SubEmployee> = new Array<SubEmployee>();
  userEditAvailable: boolean = false;
  isManager: boolean = false;

  public get user() {
    this._user = JSON.parse(localStorage.getItem('user'));
    return this._user;
  }

  constructor() { }

  
}
