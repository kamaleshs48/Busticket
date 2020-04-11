import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LOCAL_STORAGE, WebStorageService, SESSION_STORAGE } from 'angular-webstorage-service';

@Component({
  selector: 'app-ticket-search',
  templateUrl: './ticket-search.component.html',
  styleUrls: ['./ticket-search.component.css']
})
export class TicketSearchComponent implements OnInit {

  TicketNo: string = "";

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private activatedRoute: ActivatedRoute, @Inject(SESSION_STORAGE) private storage: WebStorageService) {
  }

  ngOnInit() {
  }

  BindTicket() {
    if (this.TicketNo == '') {
      alert('Please Enter Ticket No');
    }
    else {

      this.http.get<any>(this.baseUrl + 'api/PrintTicket?TicketNo=' + this.TicketNo).subscribe(result => {
        console.log(result);
        //console.clear();
        if (result.PassengerList.length < 1) {
          alert('No Record Found.');

        }
        else {

          this.router.navigate(['./ticket-print'], {
            queryParams:
              { TicketNo: this.TicketNo }
          }).then(e => {
            if (e) {
              console.log("Navigation is successful!");
            } else {
              console.log("Navigation has failed!");
            }
          });
        }
        //alert(JSON.stringify(result.SeatList))
        // this.frm = result;
      }, error => console.error(error));
    }
  }
}
