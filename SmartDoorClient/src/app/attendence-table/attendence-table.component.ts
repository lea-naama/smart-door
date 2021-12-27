import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActionService } from '../action.service';
import { ActionModel } from '../ActionModel';

@Component({
  selector: 'app-attendence-table',
  templateUrl: './attendence-table.component.html',
  
})
export class AttendenceTableComponent implements OnInit {
  form: FormGroup;
  actions: ActionModel[] = [];
  displayedColumns = [,'תאריך', 'שעת כניסה ', 'שעת יציאה','שעת כניסה','שעת יציאה','שעת כניסה', 'שעת יציאה','סה"כ','סוג נוכחות']
  constructor(private  _actionService: ActionService,
    private _formBuilder: FormBuilder) {
    
    
   }

  ngOnInit(): void {
    this.form = this._formBuilder.group({
      attendence: this._formBuilder.array([])
    });
    this._actionService.getAllAsFormArray('04-10-2020','05-10-2020').subscribe(attendence =>{
      this.form.setControl('attendence', attendence);
    })
    this._actionService.getAllActions().subscribe(acts => {
      this.actions=acts;
    });
   
  }
  get attendence(): FormArray {
    return this.form.get('attendence') as FormArray;
  }

  // On user change I clear the title of that album 
  onActionChange(event, attendence: FormGroup) {
    const title = attendence.get('title');

    title.setValue(null);
    title.markAsUntouched();
    // Notice the ngIf at the title cell definition. The user with id 3 can't set the title of the albums
  }

}
