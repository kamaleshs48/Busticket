import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  SourceList: any = [];

  SearchForm = {
    Destination: '13',
    Source: '6',
    JournyDate: "",
  }


  constructor(private router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>(baseUrl + 'api/GetSourceList').subscribe(result => {
      console.log(result.SourceList);
      this.SourceList = result.SourceList;
    }, error => console.error(error));
  }

  ngOnInit() {
    // this. Source.push('AAA')
  }
  OpenPage() {
   // alert(JSON.stringify(this.SearchForm));
    this.router.navigate(['./search-list'], {
      queryParams:
        { Source: this.SearchForm.Source, Destination: this.SearchForm.Destination, JournyDate: this.SearchForm.JournyDate }
    }).then(e => {
      if (e) {
        console.log("Navigation is successful!");
      } else {
        console.log("Navigation has failed!");
      }
    });
  }
}
