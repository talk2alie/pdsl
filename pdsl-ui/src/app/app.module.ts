import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { OperationsComponent } from './operations/operations.component';
import { RegulationsComponent } from './regulations/regulations.component';
import { AboutComponent } from './about/about.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { routes } from './routes';

@NgModule({
declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    FooterComponent,
    OperationsComponent,
    RegulationsComponent,
    AboutComponent,
    PageNotFoundComponent
],
imports: [
    BrowserModule,
    RouterModule.forRoot(routes)
],
providers: [],
bootstrap: [AppComponent]
})
export class AppModule { }
