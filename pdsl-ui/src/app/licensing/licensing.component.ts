import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { subscribeOn } from 'rxjs/operators';
import { PdslApiService } from '../services/pdsl.api.service';
import { VisitorOutputViewModel } from '../shared/visitor-output.model';
import { VisitorSubmittedViewModel } from '../shared/visitor-submitted.model';

@Component({
    selector: 'pdsl-licensing',
    templateUrl: './licensing.component.html',
    styleUrls: ['./licensing.component.css'],
})
export class LicensingComponent implements OnInit {
    identityFormSubmitted = false;
    identityVerified = false;

    visitor!: VisitorOutputViewModel;

    constructor(private titleService: Title) {
        this.titleService.setTitle('PDSL | Licensing');
    }

    ngOnInit(): void {

    }

    onIdentitySubmitted(visitorSubmittedModel: VisitorSubmittedViewModel): void {
        if(visitorSubmittedModel.isVerified) {
            this.identityVerified = visitorSubmittedModel.isVerified;
            this.identityFormSubmitted = visitorSubmittedModel.identitySubmitted;
            return;
        }

        this.identityFormSubmitted = visitorSubmittedModel.identitySubmitted;
        this.visitor = {
            fullName: visitorSubmittedModel.fullName,
            organization: visitorSubmittedModel.organization,
            email: visitorSubmittedModel.email,
            isVerified: visitorSubmittedModel.isVerified
        };
    }

    onIdentityVerified(isVerified: boolean): void {
        this.identityVerified = isVerified;
    }
}
