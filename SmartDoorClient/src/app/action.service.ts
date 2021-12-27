import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormArray } from '@angular/forms';
import {  Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ActionModel } from './ActionModel';
import { AttendenceModel } from './attendenceModel';

@Injectable({
  providedIn: 'root'
})
export class ActionService {

  getActionsByDates(from: string, to : string):Observable<ActionModel[]>{
    return this._http.get<ActionModel[]>("/api/Action/"+from+"/"+to);
  }
  getAllActions():Observable<ActionModel[]>{
    return this._http.get<ActionModel[]>("/api/Action");
  }
  getAllAsFormArray(from: string, to : string): Observable<FormArray> {
    return this.getActionsByDates(from, to).pipe(map((attendence: ActionModel[]) => {
      // Maps all the albums into a formGroup defined in tge album.model.ts
      const fgs = attendence.map(AttendenceModel.asFormGroup);
      return new FormArray(fgs);
    }));
  }


  constructor( private _http:HttpClient) { }



}
