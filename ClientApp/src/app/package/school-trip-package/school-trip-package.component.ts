import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-school-trip-package',
  templateUrl: './school-trip-package.component.html',
  styleUrls: ['./school-trip-package.component.css']
})
export class SchoolTripPackageComponent implements OnInit {

  constructor() { }

  IsShow: any=[];
  ngOnInit() {
  this.IsShow.push(1);
  this.IsShow.push(2);
  this.IsShow.push(3);
  }

}
