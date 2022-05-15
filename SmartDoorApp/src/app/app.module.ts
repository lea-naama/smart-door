import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { FrameComponent } from './components/frame/frame.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { UserProfilComponent } from './components/user-profil/user-profil.component';
import { AttendancePageComponent } from './components/attendance-page/attendance-page.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { MenuComponent } from './components/menu/menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCard, MatCardModule } from '@angular/material/card';
import { AppRoutingModule } from './app-routing.module'
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import { DialogLogInComponent } from './components/dialog-log-in/dialog-log-in.component';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';


@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    HomePageComponent,
    FrameComponent,
    EmployeeListComponent,
    UserProfilComponent,
    AttendancePageComponent,
    PageNotFoundComponent,
    MenuComponent,
    DialogLogInComponent,
    EmployeeDetailsComponent,
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatCardModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatDialogModule
    
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
