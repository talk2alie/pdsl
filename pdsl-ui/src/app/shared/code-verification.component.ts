import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PdslApiService } from '../services/pdsl.api.service';
import { RegisterVisitorOutputViewModel } from './register-visitor.model';
import { VerifyCodeVisitorOutputViewModel, VerifyCodeVisitorViewModel } from './verify-code.model';

@Component({
    selector: 'pdsl-code-verification-form',
    template: `
        <div
            *ngIf="submittedVisitor && submittedVisitor.isCodeSent"
            id="identityVerificationForm"
        >
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
    @Input() submittedVisitor?: RegisterVisitorOutputViewModel = undefined;
    @Output() identityVerified = new EventEmitter<VerifyCodeVisitorOutputViewModel>();

    verificationCodeForm!: FormGroup;
    verificationCode!: FormControl;

    constructor(private pdslApi: PdslApiService) {}

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
        if (!this.submittedVisitor) {
            return;
        }
        let verifyCodeVisitor: VerifyCodeVisitorViewModel = {
            code: this.verificationCode.value,
            email: this.submittedVisitor.email,
            fullName: this.submittedVisitor.fullName,
            organization: this.submittedVisitor.organization,
        };
        this.pdslApi.verifyCode(verifyCodeVisitor).subscribe((visitor) => {
            this.identityVerified.emit(visitor);
        }, error => {
            this.identityVerified.emit(error.error);
        });
    }

    showControlErrors(control: FormControl): boolean {
        return control.invalid && (control.dirty || control.touched);
    }
}
