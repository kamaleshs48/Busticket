import { Component,OnInit  } from '@angular/core';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';  
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent  implements OnInit{
  title = 'app';
 
  constructor() {  
    
  }  

  public OpenPage() {
    alert('sSSSSSSSSSSSSSSSSS');
  }
  ngOnInit() {  
   
  }  
}
