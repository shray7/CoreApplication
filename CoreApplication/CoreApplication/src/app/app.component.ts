import { Component } from '@angular/core';
import { Http } from '@angular/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    isApplication: boolean = true;
    constructor() { }
    
    ngOnInit() {
        
    }
    seeApplication() {
        this.isApplication = true;
    }
    seeEmployer() {
        this.isApplication = false;
    }
}
