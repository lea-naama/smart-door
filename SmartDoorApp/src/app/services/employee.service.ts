import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  baseUrl = 'https://localhost:44343/api/Employee';
  constructor(private http : HttpClient) { }

  currentEmployee : Employee;

  GetEmployeeById(id: number) : Observable<Employee>{
    return this.http.post<Employee>(this.baseUrl+id,{});
  }
}
