import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ActionService } from '../action.service';
import { ActionModel } from '../ActionModel';


@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
})
export class ActionComponent implements OnInit {


  actionTable: Observable<ActionModel[]>;
  date:Date=new Date();
  from:Date=new Date(this.date.getFullYear(),this.date.getMonth(),1);
  to:Date=new Date(this.date.getFullYear(),this.date.getMonth(),30);



  constructor(private _actionService : ActionService ) { }

  ngOnInit(): void {
  //this.actionTable=this._actionService.getActionsByDates(this.from,this.to);
  }


  

}
