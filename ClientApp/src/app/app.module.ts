import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

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
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {TermsConditionsComponent} from './terms-conditions/terms-conditions.component'
import { from } from 'rxjs';
import { NgbDateCustomParserFormatter } from './dateformat';
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
      {path:'terms-conditions',component:TermsConditionsComponent}

    ]
  },
  { path: '**', redirectTo: '' }
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
    TermsConditionsComponent
  
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    StorageServiceModule,


    RouterModule.forRoot(

      routes, config


    )
  ],
  providers: [{ provide: NgbDateParserFormatter, useClass: NgbDateCustomParserFormatter }],
  bootstrap: [AppComponent]
})
export class AppModule { }
