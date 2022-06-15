import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { RegisterVisitorOutputViewModel } from '../shared/register-visitor.model';
import { VerifyCodeVisitorOutputViewModel } from '../shared/verify-code.model';

@Component({
    selector: 'pdsl-licensing',
    templateUrl: './licensing.component.html',
    styleUrls: ['./licensing.component.css'],
})
export class LicensingComponent implements OnInit {
    identityFormSubmitted = false;
    identityVerified = false;

    submittedVisitor?: RegisterVisitorOutputViewModel = undefined;

    errorMessage?: string = undefined;

    constructor(private titleService: Title) {
        this.titleService.setTitle('PDSL | Licensing');
    }

    ngOnInit(): void {
        this.errorMessage = undefined;
    }

    onIdentitySubmitted(visitorSubmittedModel: RegisterVisitorOutputViewModel): void {
        if(!visitorSubmittedModel.isCodeVerified) {
            this.submittedVisitor = visitorSubmittedModel;
        }

        this.identityFormSubmitted = visitorSubmittedModel.isCodeSent;
        this.identityVerified = visitorSubmittedModel.isCodeVerified;
    }

    onIdentityVerified(vierifiedVisitor: VerifyCodeVisitorOutputViewModel): void {
        this.identityVerified = vierifiedVisitor.isCodeVerified;
        if(!this.identityVerified) {
            this.submittedVisitor = undefined;
            this.identityFormSubmitted = false;
            this.errorMessage = 'The code you provided was incorrect. Please retry submitting your information.';
            return;
        }

        this.identityFormSubmitted = true;
        this.errorMessage = undefined;
    }
}
