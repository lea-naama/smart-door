import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LogInComponent } from './components/log-in/log-in.component';
import { FrameComponent } from './components/frame/frame.component';
import { AttendancePageComponent } from './components/attendance-page/attendance-page.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { UserProfilComponent } from './components/user-profil/user-profil.component';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';

const routes: Routes = [
  {path:'',redirectTo:'log-in',pathMatch:'full'},
  {path:'log-in', component:LogInComponent} ,
  {path:'shell', component:FrameComponent, 
  children:[
    {path:'attandance',component:AttendancePageComponent},
    {path:'employee-list',component:EmployeeListComponent},
    {path:'user-profil', component:UserProfilComponent},
    {path:'employee-details',component:EmployeeDetailsComponent}
  ]
},
{path:'**', component:PageNotFoundComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
