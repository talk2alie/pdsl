import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'pdsl-licensing',
    templateUrl: './licensing.component.html',
    styleUrls: ['./licensing.component.css'],
})
export class LicensingComponent implements OnInit {
    identityFormSubmitted = false;
    identityVerified = false;

    userVerificationForm!: FormGroup;
    fullName!: FormControl;
    organization!: FormControl;
    emailAddress!: FormControl;

    verificationCodeForm!: FormGroup;
    verificationCode!: FormControl;

    constructor() {}

    ngOnInit(): void {
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

        this.verificationCode = new FormControl(null, [
            Validators.required,
            Validators.maxLength(5),
        ]);
        this.verificationCodeForm = new FormGroup({
            verificationCode: this.verificationCode,
        });
    }

    onUserIdentityFormSubmit(): void {
        console.log(this.userVerificationForm.value);
        this.identityFormSubmitted = true;
    }

    onVerificationCodeSubmit(): void {
        console.log(this.verificationCodeForm.value);
        this.identityVerified = true;
    }

    showControlErrors(control: FormControl): boolean {
        return control.invalid && (control.dirty || control.touched);
    }
}
