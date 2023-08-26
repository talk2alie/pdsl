import { Injectable } from '@angular/core';
import { PressRelease } from './press-release.model';
import { pressReleases } from './press-release.data';

@Injectable({
    providedIn: 'root',
})
export class PressReleaseService {

    getMostRecentPressReleases(): PressRelease[] {
        return pressReleases;
    }
}
