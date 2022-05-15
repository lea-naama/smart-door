import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { LogInRequest } from '../models/logInRequest';
import { LogInResponse } from '../models/LogInResponse';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor( private _http : HttpClient ) { }
  baseURL = 'https://localhost:44343/api/LogIn';

  GetUser(logInRequest : LogInRequest):Observable<LogInResponse>{
    return this._http.post<LogInResponse>('/api/LogIn', logInRequest);
  }

  GetEmployeeDetails(employeeId:string ){

  }


}
