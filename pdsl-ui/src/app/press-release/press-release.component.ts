import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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

    canUploadRelease = false;
    uploadText = 'open upload';

    pressReleaseForm!: FormGroup;
    title!: FormControl;
    description!: FormControl;
    bannerImage!: FormControl;
    document!: FormControl;
    releaseDate!: FormControl;

    bannerImageFile!: File | null | undefined;
    releaseDocumentFile!: File | null | undefined;

    constructor(private pressReleasesService: PressReleaseService) {}

    ngOnInit(): void {
        this.title = new FormControl('', [
            Validators.required,
            Validators.maxLength(150),
        ]);
        this.description = new FormControl('', [
            Validators.required,
            Validators.maxLength(500),
        ]);
        this.bannerImage = new FormControl('', Validators.required);
        this.document = new FormControl('', Validators.required);
        this.releaseDate = new FormControl('', Validators.required);
        this.pressReleaseForm = new FormGroup({
            title: this.title,
            description: this.description,
            bannerImage: this.bannerImage,
            document: this.document,
            releaseDate: this.releaseDate,
        });

        this.pressReleasesService
            .getMostRecentPressReleases()
            .subscribe((pressReleases) => {
                this.pressReleases = pressReleases;
                this.sort();
            });
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
        if (this.pressReleases) {
            if (this.isSortByDate) {
                this.pressReleases.sort((a: PressRelease, b: PressRelease) => {
                    if (a.releaseDate < b.releaseDate) {
                        return 1;
                    } else if (a.releaseDate > b.releaseDate) {
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

    toggleUpload(): void {
        this.canUploadRelease = !this.canUploadRelease;
        if (this.canUploadRelease) {
            this.uploadText = 'close upload';
        } else {
            this.uploadText = 'open upload';
        }
    }

    onBannerImageSelection(bannerImageFiles : FileList | null | undefined): void {
        this.bannerImageFile = bannerImageFiles?.item(0);
    }

    onReleaseDocumentSelection(releaseDocuments: FileList | null | undefined) {
        this.releaseDocumentFile = releaseDocuments?.item(0);
    }

    onUploadRelease(): void {
        const uploaderId = '608a657d-a188-4165-8895-3446b9979a08';

        const formData = new FormData();
        formData.append('title', this.title.value);
        formData.append('description', this.description.value);
        formData.append('bannerImage', <Blob>this.bannerImageFile);
        formData.append('document', <Blob>this.releaseDocumentFile);
        formData.append('releaseDate', this.releaseDate.value);
        formData.append('uploaderId', uploaderId);

        this.pressReleasesService.uploadNewPressRelease(formData)
            .subscribe(result => console.log(result));
    }
}
