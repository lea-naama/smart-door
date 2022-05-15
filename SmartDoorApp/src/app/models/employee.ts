import { Department } from "./department"

export interface Employee{
    employeeId : number,
    firstName : string,
    lastName : string,
    email : string,
    address : string,
    phone : string,
    id : string,
    directManagerId? : number,
    departmentId? : number,
    StandardDailyHours? : number,
    image : string,
    password : string   
    department : Department;
}