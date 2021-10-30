import { Component, HostListener, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'pdsl-regulations',
    templateUrl: './regulations.component.html',
    styleUrls: ['./regulations.component.css'],
})
export class RegulationsComponent {
    private viewportWidth: number;

    constructor(private titleService: Title) {
        this.viewportWidth = window.innerWidth;
        this.titleService.setTitle('PDSL | Regulations');
    }

    @HostListener('window:resize', ['$event'])
    onResize(event: any) {
        this.viewportWidth = event.target.innerWidth;
    }

    canApplyLargeHorizontalMargin(): boolean {
        return this.viewportWidth >= 768;
    }

    canApplyLargeHorizontalTableMargin(): boolean {
        return this.viewportWidth >= 992;
    }

    getHorizontalTableMarginClasses(): string {
        if (this.viewportWidth >= 992) {
            return 'mx-20';
        }

        if (this.viewportWidth >= 768) {
            return 'mx-10';
        }

        return '';
    }

    getLargeThumbnailMarginClass(): string {
        if (this.viewportWidth >= 1200) {
            return 'mx-20';
        }

        return '';
    }

    getCardBodyClasses(): string {
        if (this.viewportWidth < 768) {
            return 'text-center';
        }

        return '';
    }
}
