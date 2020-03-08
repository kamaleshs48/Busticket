import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material';

import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes, ExtraOptions } from '@angular/router';


import { StorageServiceModule} from 'angular-webstorage-service'
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SearchComponent } from './search/search.component';
import { SearchListComponent } from './search-list/search-list.component';
import { FooterComponent } from './footer/footer.component';
import { LayoutComponent } from './shared/layout/layout.component';
import {TicketPrintComponent} from './ticket-print/ticket-print.component'
import {NgbModule, NgbDateParserFormatter} from '@ng-bootstrap/ng-bootstrap';
import {TermsConditionsComponent} from './terms-conditions/terms-conditions.component';
import {SearchResultComponent} from './search-result/search-result.component'

import { from } from 'rxjs';
import { NgbDateCustomParserFormatter } from './dateformat';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FamilyPackageComponent } from './package/family-package/family-package.component';
import { HoneymoonPackageComponent } from './package/honeymoon-package/honeymoon-package.component';
import { OfficialTripPackageComponent } from './package/official-trip-package/official-trip-package.component';
import { SchoolTripPackageComponent } from './package/school-trip-package/school-trip-package.component';

import { CollegeTripPackageComponent } from './package/college-trip-package/college-trip-package.component';
import { PackageDetailsComponent } from './package/package-details/package-details.component';
import { TicketSearchComponent } from './ticket-search/ticket-search.component';
import { DataService } from "./API/data.service";

const routes: Routes = [
  {

    path: '',

    children: [
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    
    ],
  },
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'search-list', component: SearchListComponent },
      { path: 'ticket-print', component: TicketPrintComponent},
      {path:'terms-conditions',component:TermsConditionsComponent},
      {path:'search-result',component:SearchResultComponent},
      {path:'package/family-package',component:FamilyPackageComponent},
      {path:'package/honeymoon-package',component:HoneymoonPackageComponent},
      {path:'package/official-trip-package',component:OfficialTripPackageComponent},
      {path:'package/school-trip-package',component:SchoolTripPackageComponent},
      {path:'package/college-trip-package',component:CollegeTripPackageComponent},
      {path:'package/package-details',component:PackageDetailsComponent},
      {path:'search-ticket',component:TicketSearchComponent},



    ]
  },
 
  
 /*  { path: '**', redirectTo: '' } */
];

const config: ExtraOptions = {
  useHash: true,
};




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SearchComponent,
    SearchListComponent,
    FooterComponent,
    LayoutComponent,
    TicketPrintComponent,
    TermsConditionsComponent,
    SearchResultComponent,
    FamilyPackageComponent,
    HoneymoonPackageComponent,
    OfficialTripPackageComponent,
    SchoolTripPackageComponent,
    TicketSearchComponent,
    CollegeTripPackageComponent,
   
    PackageDetailsComponent,
    
  
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    StorageServiceModule,
    MatCardModule,


    RouterModule.forRoot(

      routes, config


    ),


    BrowserAnimationsModule
  ],
  providers: [DataService,{ provide: NgbDateParserFormatter, useClass: NgbDateCustomParserFormatter }],
  bootstrap: [AppComponent]
})
export class AppModule { }
