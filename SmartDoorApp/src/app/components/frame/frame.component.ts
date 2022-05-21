import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-frame',
  templateUrl: './frame.component.html',
  styleUrls: ['./frame.component.scss']
})
export class FrameComponent implements OnInit {

  isManagaer : boolean
  constructor(private router : Router) { }

  ngOnInit(): void {
  }
  Nevigate(component){
    this.router.navigate(['shell/'+component]);
  }
  IsManager(){
    return  JSON.parse(localStorage.getItem('isManager'));
  }

}
