import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LOCAL_STORAGE,WebStorageService,SESSION_STORAGE } from 'angular-webstorage-service';

@Component({
  selector: 'app-ticket-print',
  templateUrl: './ticket-print.component.html',
  styleUrls: ['./ticket-print.component.css']
})
export class TicketPrintComponent implements OnInit {
  TicketNo:any;
  isLoad:boolean=false;
  frm:any={};
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
  private activatedRoute: ActivatedRoute,@Inject(SESSION_STORAGE) private storage: WebStorageService) { 

    this.activatedRoute.queryParams.subscribe(params => {
      this.TicketNo = params['TicketNo'];
      if(!this.TicketNo)
      {
        this.TicketNo=storage.get('TicketNo');
      }
     if(this.TicketNo)
     {
      http.get<any>(baseUrl + 'api/PrintTicket?TicketNo='+this.TicketNo).subscribe(result => {
        // console.log(result);
    
        //console.clear();
        //alert(JSON.stringify(result.SeatList))
        this.frm = result;
        
      }, error => console.error(error));
     }
     

    });


   

  }

  ngOnInit() {
    if (!localStorage.getItem('IsTicketPageReload')) { 
      localStorage.setItem('IsTicketPageReload', 'no reload') 
     // location.reload() 
    } else {
      localStorage.removeItem('IsTicketPageReload') 
    }
   
  }

}
interface PrintTicketModels {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}