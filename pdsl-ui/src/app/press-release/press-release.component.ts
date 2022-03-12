import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'pdsl-press-release',
    templateUrl: './press-release.component.html',
    styleUrls: ['./press-release.component.css'],
})
export class PressReleaseComponent implements OnInit {
    isSortByDate: boolean = true;
    isSortByTitle: boolean = false;

    constructor() {}

    ngOnInit(): void {}

    getSortByDateClass(): string {
        return this.isSortByDate ? 'btn-primary' : 'btn-outline-primary';
    }

    getSortByTitleClass(): string {
        return this.isSortByTitle ? 'btn-primary' : 'btn-outline-primary';
    }

    sortByDate(): void {
        this.isSortByDate = true;
        this.isSortByTitle = false;
    }

    sortByTitle(): void {
        this.isSortByTitle = true;
        this.isSortByDate = false;
    }
}
