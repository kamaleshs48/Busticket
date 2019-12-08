import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { NgbDate, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
const now = new Date();
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class SearchComponent implements OnInit {
  SourceList: any = [];

  SearchForm = {
    Destination: '13',
    Source: '6',
    JournyDate: {},
  }


  constructor(private router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>(baseUrl + 'api/GetSourceList').subscribe(result => {
      console.log(result.SourceList);
      this.SourceList = result.SourceList;
    }, error => console.error(error));
  }

  ngOnInit() {
    // this. Source.push('AAA')
    this.SearchForm.JournyDate = { year: now.getFullYear(), month: now.getMonth() + 1, day: now.getDate()+1 };
  }
  OpenPage() {
    //alert(JSON.stringify(this.SearchForm.JournyDate)); ("0" + myNumber).slice(-2)
    let _Date: any = this.SearchForm.JournyDate
    let _JDate = ("0" + _Date.day).slice(-2) + "/" + ("0" + _Date.month).slice(-2) + "/" + _Date.year;
  











    this.router.navigate(['./search-list'], {
      queryParams:
        { Source: this.SearchForm.Source, Destination: this.SearchForm.Destination, JournyDate: _JDate,Date:this.SearchForm.JournyDate }
    }).then(e => {
      if (e) {
        console.log("Navigation is successful!");
      } else {
        console.log("Navigation has failed!");
      }
    });
  }
}