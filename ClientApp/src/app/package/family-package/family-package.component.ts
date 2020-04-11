import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LOCAL_STORAGE, WebStorageService, SESSION_STORAGE } from 'angular-webstorage-service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-family-package',
  templateUrl: './family-package.component.html',
  
  styleUrls: ['./family-package.component.css']
})
export class FamilyPackageComponent implements OnInit {
  PackageList:any=[];
  IsShow: any=[];
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private activatedRoute: ActivatedRoute, @Inject(SESSION_STORAGE) private storage: WebStorageService, private modalService: NgbModal) { 

   
      http.get<any>(baseUrl + 'api/GetPackageList?PackageTypeID=1').subscribe(result => {
         console.log(result);
    
        //console.clear();
        //alert(JSON.stringify(result.SeatList))
      this.PackageList = result.PackageList;
        
      }, error => console.error(error));
        

  }
  openBackDropCustomClass(content) {
   // this.modalService.open(content, { backdropClass: 'light-blue-backdrop' });
    this.modalService.open(content, { size: 'sm' });
  }
  ngOnInit() {
  }

}
