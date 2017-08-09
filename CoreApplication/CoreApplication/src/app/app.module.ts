import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { ApplicationFormComponent } from './application-form/application-form.component';
import { EmployerFormComponent } from './employer-form/employer-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ApplicationFormComponent,
    EmployerFormComponent
  ],
  imports: [
      BrowserModule,
      HttpModule,
      FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
