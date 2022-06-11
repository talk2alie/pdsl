import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { subscribeOn } from 'rxjs/operators';

@Component({
    selector: 'pdsl-licensing',
    templateUrl: './licensing.component.html',
    styleUrls: ['./licensing.component.css'],
})
export class LicensingComponent implements OnInit {
    identityFormSubmitted = false;
    identityVerified = false;

    constructor() {}

    ngOnInit(): void {}

    onIdentitySubmitted(isSubmitted: boolean): void {
        this.identityFormSubmitted = isSubmitted;
    }

    onIdentityVerified(isVerified: boolean): void {
        this.identityVerified = isVerified;
    }
}
