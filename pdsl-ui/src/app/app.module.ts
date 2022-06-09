import { NgModule } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { OperationsComponent } from './operations/operations.component';
import { RegulationsComponent } from './regulations/regulations.component';
import { AboutComponent } from './about/about.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { routes } from './routes';
import { StaffDetailComponent } from './staff-detail/staff-detail.component';
import { ApplicationsComponent } from './applications/applications.component';
import { PressReleaseComponent } from './press-release/press-release.component';
import { LicensingComponent } from './licensing/licensing.component';

@NgModule({
declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    FooterComponent,
    OperationsComponent,
    RegulationsComponent,
    AboutComponent,
    PageNotFoundComponent,
    StaffDetailComponent,
    ApplicationsComponent,
    PressReleaseComponent,
    LicensingComponent
],
imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
],
providers: [Title],
bootstrap: [AppComponent]
})
export class AppModule { }
