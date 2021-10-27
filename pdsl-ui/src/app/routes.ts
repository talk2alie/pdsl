import { Routes } from "@angular/router";
import { AboutComponent } from "./about/about.component";
import { HomeComponent } from "./home/home.component";
import { OperationsComponent } from "./operations/operations.component";
import { PageNotFoundComponent } from "./page-not-found/page-not-found.component";
import { RegulationsComponent } from "./regulations/regulations.component";

export const routes: Routes = [
    { path: 'about', component: AboutComponent },
    { path: 'regulations', component: RegulationsComponent },
    { path: 'operations', component: OperationsComponent },
    { path: 'home', component: HomeComponent },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent}
]