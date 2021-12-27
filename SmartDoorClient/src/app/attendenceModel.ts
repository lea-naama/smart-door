import { FormControl, FormGroup } from "@angular/forms";

export class AttendenceModel{
    title:string;
    actionId? :number;
    employeeId? : number;
    date: Date;
    statusId?: number;
    actionTypeId?:number;
    enteringTypeId:number;
    static asFormGroup(attendence: AttendenceModel): FormGroup {
        const fg = new FormGroup({
          actionId: new FormControl(attendence.actionId),
          employeeId: new FormControl(attendence.employeeId),
          date: new FormControl(attendence.date),
          statusId: new FormControl(attendence.statusId),
          actionTypeId: new FormControl(attendence.actionTypeId),
          enteringTypeId: new FormControl(attendence.enteringTypeId),
          title: new FormControl(attendence.title)
        });
        return fg;
      }





}