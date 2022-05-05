import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActionModel } from 'src/app/Action.Model';
import { DataService } from 'src/app/services/data.service';
import{DatePipe} from '@angular/common'
import { jsPDF } from "jspdf";
import html2canvas from 'html2canvas';
@Component({
  selector: 'app-attendance-page',
  templateUrl: './attendance-page.component.html',
  styleUrls: ['./attendance-page.component.scss']
})
export class AttendancePageComponent implements OnInit {
  tableData:ActionModel[];
  ETcheckIn1?:string='טרם עודכן';
  ETcheckOut1?:string='טרם עודכן';
  ETcheckIn2?:string='טרם עודכן';
  ETcheckOut2?:string='טרם עודכן';
  ETcheckIn3?:string='טרם עודכן';
  ETcheckOut3?:string='טרם עודכן';
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
 createForm(actionsTable:ActionModel[]){  
    this.actionForm = this._formBuilder.group({  
      tables: this._formBuilder.array([

      ]) 
    })  
    const ctrlTables = <FormArray> this.actionForm.controls.tables;
        actionsTable.forEach(tableObj=>{
        ctrlTables.push(this.createTableRows(tableObj));
      })
    
}  
 createTableRows(action:ActionModel): any{ 
   if(action.etCheckIn1)
      this.ETcheckIn1=action.etCheckIn1;
   if(action.etCheckOut1)
      this.ETcheckOut1=action.etCheckOut1;
   if(action.etCheckIn2)
      this.ETcheckIn2=action.etCheckIn2;
   if(action.etCheckOut2)
      this.ETcheckOut2=action.etCheckOut2;
   if(action.etCheckIn3)
      this.ETcheckIn3=action.etCheckIn3;
   if(action.etCheckOut3)
      this.ETcheckOut3=action.etCheckOut3;
      debugger;
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
          attendenceType: new FormControl(action.actionType),

    });
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
}
