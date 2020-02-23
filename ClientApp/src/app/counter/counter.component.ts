import { Component } from '@angular/core';
import { DataService } from "../API/data.service";
@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  myInputMessage:string ="I am the parent comppnent"  ;
  myInputMessage1:string ="I am the parent comppnent Second" ;
  MyOutPutData:string="MyOutpUt"
  message:string;
  public incrementCounter() {
    this.currentCount++;
  }


  constructor(private data: DataService) { }
  GetChildData(data){  
    this.MyOutPutData=data;
    console.log(data);  
 } 
 ngOnInit() {
  this.data.currentMessage.subscribe(message => this.message = message)
}
}
