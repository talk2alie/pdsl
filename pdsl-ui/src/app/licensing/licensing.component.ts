import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'pdsl-licensing',
    templateUrl: './licensing.component.html',
    styleUrls: ['./licensing.component.css'],
})
export class LicensingComponent implements OnInit {
    identityVerified = false;
    identityFormSubmitted = false;
    constructor() {}

    ngOnInit(): void {}
}
