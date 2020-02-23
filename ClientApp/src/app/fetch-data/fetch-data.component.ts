import { Component, Inject , Input, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from "../API/data.service";
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  @Input() myinputMsg:string;  
  @Input() b:string; 
  message:string;
  @Output() myOutput:EventEmitter<any>= new EventEmitter();  
  outputMessage:string="I am child component." 

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,private data: DataService) {
   
  }
  ngOnInit() {  
    console.log(this.myinputMsg);  
    this.data.currentMessage.subscribe(message => this.message = message)
    } 
    sendValues(){  
      console.log(this.outputMessage)
      this.myOutput.emit(this.outputMessage);  
   } 
   newMessage() {
    console.log('Hello from Sibling')
    this.data.changeMessage(this.outputMessage)
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
