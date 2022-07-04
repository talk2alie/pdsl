import { Component, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { PdslApiService } from '../services/pdsl.api.service';
import {
    RegisterVisitorOutputViewModel,
    VisitorViewModel,
} from './register-visitor.model';

@Component({
    selector: 'pdsl-identity-submission-form',
    template: `<div *ngIf="!identitySubmitted" id="identitySubmitssionForm">
        <form
            autocomplete="off"
            novalidate
            [formGroup]="userVerificationForm"
            (ngSubmit)="onVisitorIdentityFormSubmit()"
        >
            <div class="row">
                <div class="col-md-4 text-start mb-3">
                    <label for="fullName" class="form-label">Full Name</label>
                    <input
                        type="text"
                        formControlName="fullName"
                        class="form-control"
                        id="fullName"
                        title="Please enter your full name"
                        required
                        placeholder="Please enter your full name"
                        name="fullName"
                    />
                    <p
                        class="text-danger fs-6 fst-italic"
                        *ngIf="showControlErrors(fullName)"
                    >
                        <span *ngIf="fullName.errors?.required"
                            >*Your full name is required</span
                        ><br />
                        <span *ngIf="fullName.errors?.maxlength"
                            >*Your full name must be at most 255
                            characters</span
                        >
                    </p>
                </div>
                <div class="col-md-4 text-start mb-3">
                    <label for="organization" class="form-label"
                        >Organization</label
                    >
                    <input
                        type="text"
                        formControlName="organization"
                        class="form-control"
                        id="organization"
                        title="Please enter your organization's name"
                        required
                        placeholder="Please enter your organization's name"
                        name="organization"
                    />
                    <p
                        class="text-danger fs-6 fst-italic"
                        *ngIf="showControlErrors(organization)"
                    >
                        <span *ngIf="organization.errors?.required"
                            >*Your organizaion's name is required</span
                        ><br />
                        <span *ngIf="organization.errors?.maxlength"
                            >*Your organizaion's name must be at most 255
                            characters</span
                        >
                    </p>
                </div>
                <div class="col-md-4 text-start mb-3">
                    <label for="emailAddress" class="form-label">Email</label>
                    <input
                        type="text"
                        formControlName="emailAddress"
                        class="form-control"
                        id="emailAddress"
                        title="Please enter your email address at your organization"
                        required
                        placeholder="Please enter your email address"
                        name="emailAddress"
                    />
                    <p
                        class="text-danger fs-6 fst-italic"
                        *ngIf="showControlErrors(emailAddress)"
                    >
                        <span *ngIf="emailAddress.errors?.required"
                            >*Your email address at your organizaion is
                            required</span
                        ><br />
                        <span *ngIf="emailAddress.errors?.email"
                            >*Your email address at your organizaion must be in
                            a valid email format</span
                        >
                    </p>
                </div>
                <div class="row">
                    <div class="col-md-6 text-start mb-3">
                        <button
                            class="btn btn-primary"
                            type="submit"
                            [disabled]="
                                userVerificationForm.invalid || isLoading
                            "
                        >
                            Submit
                            <span *ngIf="isLoading">&nbsp;</span>
                            <span
                                *ngIf="isLoading"
                                class="spinner-border spinner-border-sm"
                                role="status"
                                aria-hidden="true"
                            ></span>
                        </button>
                    </div>
                </div>
            </div>
        </form>
    </div>`,
})
export class IdentitySubmissionFormComponent implements OnInit {
    identitySubmitted = false;
    @Output() identityFormSubmitted =
        new EventEmitter<RegisterVisitorOutputViewModel>();

    userVerificationForm!: FormGroup;
    fullName!: FormControl;
    organization!: FormControl;
    emailAddress!: FormControl;

    isLoading = false;

    constructor(private pdslApi: PdslApiService) {}

    ngOnInit() {
        this.fullName = new FormControl(null, [
            Validators.required,
            Validators.maxLength(255),
        ]);
        this.organization = new FormControl(null, [
            Validators.required,
            Validators.maxLength(255),
        ]);
        this.emailAddress = new FormControl(null, [
            Validators.required,
            Validators.email,
        ]);
        this.userVerificationForm = new FormGroup({
            fullName: this.fullName,
            organization: this.organization,
            emailAddress: this.emailAddress,
        });
    }

    onVisitorIdentityFormSubmit(): void {
        this.isLoading = true;

        let visitor: VisitorViewModel = {
            fullName: this.fullName.value,
            organization: this.organization.value,
            email: this.emailAddress.value,
        };
        this.pdslApi.registerVisitor(visitor).subscribe((visitor) => {
            let visitorOutput: RegisterVisitorOutputViewModel = {
                fullName: visitor.fullName,
                organization: visitor.organization,
                email: visitor.email,
                isCodeSent: visitor.isCodeSent,
                isCodeVerified: visitor.isCodeVerified,
            };
            this.isLoading = false;
            this.identityFormSubmitted.emit(visitorOutput);
        });
    }

    showControlErrors(control: FormControl): boolean {
        return control.invalid && (control.dirty || control.touched);
    }
}
