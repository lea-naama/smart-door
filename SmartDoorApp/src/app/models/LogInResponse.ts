import { SubEmployee } from "./SubEmployee";
import { User } from "./user";

export interface LogInResponse{ 
    user : User,
    employeeList: Array<SubEmployee>
}