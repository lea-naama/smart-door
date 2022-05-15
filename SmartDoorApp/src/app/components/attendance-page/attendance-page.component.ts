import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {  TableRow } from 'src/app/tableRow.Model';
import { DataService } from 'src/app/services/data.service';
import{DatePipe} from '@angular/common'
import { jsPDF } from "jspdf";
import html2canvas from 'html2canvas';
import { ActionModel } from 'src/app/action.Model';
@Component({
  selector: 'app-attendance-page',
  templateUrl: './attendance-page.component.html',
  styleUrls: ['./attendance-page.component.scss']
})
export class AttendancePageComponent implements OnInit {
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
    private _formBuilder: FormBuilder, private datepipe:DatePipe) {
      this.currentDate=new Date();
   }
  ngOnInit(): void {
    console.log(this.currentDate);
    var from=new Date(this.currentDate.getFullYear(), this.currentDate.getMonth(), 1);
    var to=new Date(this.currentDate.getFullYear(), this.currentDate.getMonth() + 1, 0);
    this._dataService.getActionsByDates(324215433,
      this.datepipe.transform(from, 'yyyy-MM-dd'),
      this.datepipe.transform(to, 'yyyy-MM-dd'))
    .subscribe(data=>{
      this.tableData=data;
      this.createForm(this.tableData);
    }
    );

  }
 createForm(actionsTable:TableRow[]){  
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
  let table:ActionModel[]=new Array();
  let i=0;
  actionTable.forEach(action=>{
  if(action.checkIn1){
    table[i]={date:new Date(action.date+' '+action.checkIn1), statusId:1,enteringTypeId:0,actionTypeId:0, employeeId:324215433};
    if(action.etCheckIn1==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckIn1);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkOut1){
    table[i]={date:new Date(action.date+' '+action.checkOut1), statusId:2,enteringTypeId:0,actionTypeId:0, employeeId:324215433};
    if(action.etCheckOut1==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckOut1);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkIn2){
    table[i]={date:new Date(action.date+' '+action.checkIn2), statusId:1,enteringTypeId:0,actionTypeId:0, employeeId:324215433};
    if(action.etCheckIn2==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckIn2);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkOut2){
    table[i]={date:new Date(action.date+' '+action.checkOut2), statusId:2,enteringTypeId:0,actionTypeId:0, employeeId:324215433};
    if(action.etCheckOut2==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckOut2);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkIn3){
    table[i]={date:new Date(action.date+' '+action.checkIn3), statusId:1,enteringTypeId:0,actionTypeId:0, employeeId:324215433};
    if(action.etCheckIn3==undefined)
      table[i].enteringTypeId=4;
    else
      table[i].enteringTypeId=this.castEnteringType(action.etCheckIn3);
    table[i].actionTypeId=this.castActionType(action.actionType);
    i=i+1;
  }
  if(action.checkOut3){
    table[i]={date:new Date(action.date+' '+action.checkOut3), statusId:2,enteringTypeId:0,actionTypeId:0, employeeId:324215433};
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
