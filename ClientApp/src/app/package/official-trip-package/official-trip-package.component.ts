import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-official-trip-package',
  templateUrl: './official-trip-package.component.html',
  styleUrls: ['./official-trip-package.component.css']
})
export class OfficialTripPackageComponent implements OnInit {

  constructor() { }

  IsShow: any=[];
  ngOnInit() {
  this.IsShow.push(1);
  this.IsShow.push(2);
  this.IsShow.push(3);
  }
}
