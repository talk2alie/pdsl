
import { Routes } from "@angular/router";
import { AboutComponent } from "./about/about.component";
import { ApplicationsComponent } from "./applications/applications.component";
import { GalleryComponent } from './gallery/gallery.component';
import { HomeComponent } from "./home/home.component";
import { LicensingComponent } from './licensing/licensing.component';
import { OperationsComponent } from "./operations/operations.component";
import { PageNotFoundComponent } from "./page-not-found/page-not-found.component";
import { PressReleaseComponent } from "./press-release/press-release.component";
import { RegulationsComponent } from "./regulations/regulations.component";
import { StaffDetailComponent } from "./staff-detail/staff-detail.component";

export const routes: Routes = [
    { path: 'gallery', component: GalleryComponent },
    { path: 'about', component: AboutComponent },
    { path: 'about/:id', component: StaffDetailComponent },
    { path: 'licensing', component: LicensingComponent },
    { path: 'press-release', component: PressReleaseComponent },
    { path: 'application', component: ApplicationsComponent },
    { path: 'regulations', component: RegulationsComponent },
    { path: 'operations', component: OperationsComponent },
    { path: 'home', component: HomeComponent },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent },
];