import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormArray } from '@angular/forms';
import {  Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ActionModel } from '../Action.Model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private _http:HttpClient) { }

  getActionsByDates(id :number,from: string, to : string):Observable<ActionModel[]>{
    return this._http.get<ActionModel[]>("/api/Action/"+id+"/"+from+"/"+to);
  }
}
