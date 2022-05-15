import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormArray } from '@angular/forms';
import {  Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ActionModel } from '../action.Model';
import { TableRow } from '../tableRow.Model';
import { Employee } from '../models/employee';
import { LogInRequest } from '../models/logInRequest';
import { LogInResponse } from '../models/LogInResponse';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private _http:HttpClient) { }

  getActionsByDates(id :number,from: string, to : string):Observable<TableRow[]>{
    return this._http.get<TableRow[]>("/api/Action/"+id+"/"+from+"/"+to);
  }
  saveAttendance(table:ActionModel[]):Observable<void>{
    debugger;
    return this._http.post<void>("/api/Action/",table);
  }
  baseURL = 'https://localhost:44343/api/LogIn';

  GetUser(logInRequest : LogInRequest):Observable<LogInResponse>{
    return this._http.post<LogInResponse>('/api/LogIn', logInRequest);
  }

  GetEmployeeDetails(employeeId:string ){

  }


}
