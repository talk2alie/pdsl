import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { OperationsComponent } from './operations/operations.component';

@NgModule({
declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    FooterComponent,
    OperationsComponent
],
imports: [
    BrowserModule
],
providers: [],
bootstrap: [AppComponent]
})
export class AppModule { }
