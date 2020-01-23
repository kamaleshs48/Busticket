import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
@Component({
  selector: 'app-honeymoon-package',
  templateUrl: './honeymoon-package.component.html',
  styleUrls: ['./honeymoon-package.component.css']
})
export class HoneymoonPackageComponent implements OnInit {

  constructor(private router: Router) { }
  IsShow: any=[];
  ngOnInit() {
  this.IsShow.push(1);
  this.IsShow.push(2);
  this.IsShow.push(3);
  }

}
