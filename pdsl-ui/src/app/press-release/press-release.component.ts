import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { PressRelease } from '../services/press-release.model';
import { PressReleaseService } from '../services/press-release.service';

@Component({
    selector: 'pdsl-press-release',
    templateUrl: './press-release.component.html',
    styleUrls: ['./press-release.component.css'],
})
export class PressReleaseComponent implements OnInit {
    isSortByDate: boolean = true;
    isSortByTitle: boolean = false;
    pressReleases: PressRelease[] = [];

    constructor(private pressReleasesService: PressReleaseService) {}

    ngOnInit(): void {
        this.pressReleases = this.pressReleasesService.getMostRecentPressReleases();
        this.sort();
    }

    getSortByDateClass(): string {
        return this.isSortByDate ? 'btn-primary' : 'btn-outline-primary';
    }

    getSortByTitleClass(): string {
        return this.isSortByTitle ? 'btn-primary' : 'btn-outline-primary';
    }

    sortByDate(): void {
        this.isSortByDate = true;
        this.isSortByTitle = false;

        this.sort();
    }

    sortByTitle(): void {
        this.isSortByTitle = true;
        this.isSortByDate = false;

        this.sort();
    }

    private sort(): void {
        if(this.pressReleases) {
            if(this.isSortByDate) {
                this.pressReleases.sort((a: PressRelease, b: PressRelease) => {
                    if(a.releaseDate < b.releaseDate) {
                        return 1;
                    } else if(a.releaseDate > b.releaseDate) {
                        return -1;
                    } else {
                        return 0;
                    }
                });
            }

            if (this.isSortByTitle) {
                this.pressReleases.sort((a: PressRelease, b: PressRelease) => {
                    if (a.title > b.title) {
                        return 1;
                    } else if (a.title < b.title) {
                        return -1;
                    } else {
                        return 0;
                    }
                });
            }
        }
    }
}
