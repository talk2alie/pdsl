import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'pdsl-code-verification-form',
    template: `
        <div *ngIf="identityFormSubmitted" id="identityVerificationForm">
            <form
                class="d-flex justify-content-center"
                autocomplete="off"
                novalidate
                [formGroup]="verificationCodeForm"
                (ngSubmit)="onVerificationCodeSubmit()"
            >
                <div>
                    <div class="form-group">
                        <label for="verificationCode" class="form-label"
                            >Verification Code</label
                        >
                        <input
                            type="text"
                            maxlength="6"
                            required
                            name="verificationCode"
                            formControlName="verificationCode"
                            id="verificationCode"
                            class="form-control"
                        />
                        <p
                            class="text-danger fs-6 fst-italic"
                            *ngIf="showControlErrors(verificationCode)"
                        >
                            <span *ngIf="verificationCode.errors?.required"
                                >*Verification Code is required</span
                            ><br />
                            <span *ngIf="verificationCode.errors?.maxlength"
                                >*Verification Code must be 6 characters
                                long</span
                            >
                        </p>
                        <button
                            type="submit"
                            class="btn btn-primary mt-3"
                            [disabled]="verificationCodeForm.invalid"
                        >
                            Submit
                        </button>
                    </div>
                </div>
            </form>
        </div>
    `,
})
export class CodeVerificationFormComponent implements OnInit {
    @Input() identityFormSubmitted!: boolean;
    @Output() identityVerified = new EventEmitter<boolean>();

    verificationCodeForm!: FormGroup;
    verificationCode!: FormControl;

    constructor() {}

    ngOnInit() {
        this.verificationCode = new FormControl(null, [
            Validators.required,
            Validators.maxLength(6),
        ]);
        this.verificationCodeForm = new FormGroup({
            verificationCode: this.verificationCode,
        });
    }

    onVerificationCodeSubmit(): void {
        console.log(this.verificationCodeForm.value);
        this.identityVerified.emit(true);
    }

    showControlErrors(control: FormControl): boolean {
        return control.invalid && (control.dirty || control.touched);
    }
}
