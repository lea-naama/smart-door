import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {  TableRow } from 'src/app/tableRow.Model';
import { DataService } from 'src/app/services/data.service';
import{DatePipe} from '@angular/common'
import { jsPDF } from "jspdf";
import html2canvas from 'html2canvas';
import { ActionModel } from 'src/app/action.Model';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-attendance-page',
  templateUrl: './attendance-page.component.html',
  styleUrls: ['./attendance-page.component.scss']
})
export class AttendancePageComponent implements OnInit {
  user_id:number;
  userFullName:number;
  tableData:TableRow[];
  etCheckIn1?:string='טרם עודכן';
  etCheckOut1?:string='טרם עודכן';
  etCheckIn2?:string='טרם עודכן';
  etCheckOut2?:string='טרם עודכן';
  etCheckIn3?:string='טרם עודכן';
  etCheckOut3?:string='טרם עודכן';  
  actionForm: FormGroup;
  currentDate:Date;  
  columns:string[]=['סוג נוכחות','סה"כ','שעת יציאה','שעת כניסה','שעת יציאה','שעת כניסה','שעת יציאה','שעת כניסה','יום בשבוע','תאריך'];
  constructor(private  _dataService: DataService,
    private _formBuilder: FormBuilder, private datepipe:DatePipe, private _acr : ActivatedRoute) {
      this.currentDate=new Date();
   }
  ngOnInit(): void {
    debugger;
    this._acr.paramMap.subscribe(p=>
      {if(p.has("id"))
      this.user_id=Number(p.get("id"))});
      
    this.userFullName=this.user_id;
    var from=new Date(this.currentDate.getFullYear(), this.currentDate.getMonth(), 1);
    var to=new Date(this.currentDate.getFullYear(), this.currentDate.getMonth() + 1, 0);
    //this.user_id=JSON.parse(localStorage.getItem('user')).id;
    this._dataService.getActionsByDates(this.user_id,
      this.datepipe.transform(from, 'yyyy-MM-dd'),
      this.datepipe.transform(to, 'yyyy-MM-dd'))
    .subscribe(data=>{
      this.tableData=data;
      this.createForm(this.tableData);
    }
    );

  }
 createForm(actionsTable:TableRow[]){  
   debugger;
    this.actionForm = this._formBuilder.group({  
      tables: this._formBuilder.array([

      ]) 
    })  
    const ctrlTables = <FormArray> this.actionForm.controls.tables;
        actionsTable.forEach(tableObj=>{
        ctrlTables.push(this.createTableRows(tableObj));
      })
    
}  
 createTableRows(action:TableRow): any{ 
  if(action.etCheckIn1)
    this.etCheckIn1=action.etCheckIn1;
  if(action.etCheckOut1)
    this.etCheckOut1=action.etCheckOut1;
  if(action.etCheckIn2)
    this.etCheckIn2=action.etCheckIn2;
  if(action.etCheckOut2)
    this.etCheckOut2=action.etCheckOut2;
  if(action.etCheckIn3)
    this.etCheckIn3=action.etCheckIn3;
  if(action.etCheckOut3)
    this.etCheckOut3=action.etCheckOut3;
      return this._formBuilder.group({
          date: new FormControl(this.datepipe.transform(action.date, 'yyyy-MM-dd')),
          weakDay: new FormControl(action.dayWeak),
          checkIn1: new FormControl(action.checkIn1),
          checkOut1: new FormControl(action.checkOut1),
          checkIn2: new FormControl(action.checkIn2),
          checkOut2: new FormControl(action.checkOut2),
          checkIn3: new FormControl(action.checkIn3),
          checkOut3: new FormControl(action.checkOut3),
          totalHours: new FormControl(action.total),
          actionType: new FormControl(action.actionType),
          enteringType: new FormControl(action.enteringType),
          aiCheckIn1: new FormControl(action.aiCheckIn1),
          aiCheckOut1: new FormControl(action.aiCheckOut1),
          aiCheckIn2: new FormControl(action.aiCheckIn2),
          aiCheckOut2: new FormControl(action.aiCheckOut2),
          aiCheckIn3: new FormControl(action.aiCheckIn3),
          aiCheckOut3: new FormControl(action.aiCheckOut3),

    }
    );
  
} 
get tableRowArray(){  
    return this.actionForm.get('tableRowArray') as FormArray;  
}  
public exportHtmlToPDF(){
  let data = document.getElementById('table');
    
    html2canvas(data).then(canvas => {
        
        let docWidth = 208;
        let docHeight = canvas.height * docWidth / canvas.width;
        
        const contentDataURL = canvas.toDataURL('image/png')
        let doc = new jsPDF('p', 'mm', 'a4');
        let position = 0;
        doc.addImage(contentDataURL, 'PNG', 0, position, docWidth, docHeight)
        
        doc.save('exportedPdf.pdf');
    });
}
currentMonth(){
  this.currentDate=new Date();
  this.ngOnInit();
} 
nextMonth(){
  var nextMonth = new Date(this.currentDate);
  nextMonth.setMonth(this.currentDate.getMonth()+1);
  this.currentDate=nextMonth;
  this.ngOnInit();
} 
previousMonth(){
  var previousDay = new Date(this.currentDate);
  previousDay.setMonth(this.currentDate.getMonth()-1);
  this.currentDate=previousDay;
  this.ngOnInit();

}
castEnteringType(et:string){
  switch(et){
    case et="מצלמה":
      return 1;
    case et="כרטיס":
      return 2;
    case et="טביעת אצבע":
      return 3;
    case et="ידני":
      return 4;
    default:
      return 4;

  }
} 
castActionType(at:string){
  switch(at){   
    case at="נוכחות":
      return 1;
    case at="יציאה בתפקיד":
      return 2;
    case at="מחלה":
      return 3;
    case at="חופשה":
      return 4;
    default:
      return 1;

  }
} 
saveTable(actionTable:TableRow[]){
  debugger;
  let table:ActionModel[]=new Array();
  let i=0;
  actionTable.forEach(action=>{
  if(action.checkIn1){
    let actId:number;
    if(action.aiCheckIn1)
      actId=action.aiCheckIn1;
    else
      actId=0;
    table[i]={date:new Date(action.date+' '+action.checkIn1), statusId:1,enteringTypeId:0,actionTypeId:0, employeeId:this.user_id,actionId:actId};
    if(action.etCheckIn1==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckIn1);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkOut1){
    let actId:number;
    if(action.aiCheckOut1)
      actId=action.aiCheckOut1;
    else
      actId=0;
    table[i]={date:new Date(action.date+' '+action.checkOut1), statusId:2,enteringTypeId:0,actionTypeId:0, employeeId:this.user_id, actionId:actId};
    if(action.etCheckOut1==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckOut1);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkIn2){
    let actId:number;
    if(action.aiCheckIn2)
      actId=action.aiCheckIn2;
    else
      actId=0;
    table[i]={date:new Date(action.date+' '+action.checkIn2), statusId:1,enteringTypeId:0,actionTypeId:0, employeeId:this.user_id,actionId:actId};
    if(action.etCheckIn2==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckIn2);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkOut2){
    let actId:number;
    if(action.aiCheckOut2)
      actId=action.aiCheckOut2;
    else
      actId=0;
    table[i]={date:new Date(action.date+' '+action.checkOut2), statusId:2,enteringTypeId:0,actionTypeId:0, employeeId:this.user_id,actionId:actId};
    if(action.etCheckOut2==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckOut2);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkIn3){
    let actId:number;
    if(action.aiCheckIn3)
      actId=action.aiCheckIn3;
    else
      actId=0;
    table[i]={date:new Date(action.date+' '+action.checkIn3), statusId:1,enteringTypeId:0,actionTypeId:0, employeeId:this.user_id,actionId:actId};
    if(action.etCheckIn3==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckIn3);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkOut3){
    let actId:number;
    if(action.aiCheckOut3)
      actId=action.aiCheckOut3;
    else
      actId=0;
    table[i]={date:new Date(action.date+' '+action.checkOut3), statusId:2,enteringTypeId:0,actionTypeId:0, employeeId:this.user_id,actionId:actId};
    if(action.etCheckOut3==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckOut3);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  })
  this._dataService.saveAttendance(table).subscribe(d=>{
    console.log(d);
  });
}

}
