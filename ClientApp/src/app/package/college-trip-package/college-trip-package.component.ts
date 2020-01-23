import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-college-trip-package',
  templateUrl: './college-trip-package.component.html',
  styleUrls: ['./college-trip-package.component.css']
})
export class CollegeTripPackageComponent implements OnInit {

  constructor() { }

  IsShow: any=[];
  ngOnInit() {
  this.IsShow.push(1);
  this.IsShow.push(2);
  this.IsShow.push(3);
  }
}
