import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes, ExtraOptions } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SearchComponent } from './search/search.component';
import { SearchListComponent } from './search-list/search-list.component';
import { FooterComponent } from './footer/footer.component';
import { LayoutComponent } from './shared/layout/layout.component';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
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
  
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,



    RouterModule.forRoot(

      routes, config


    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
