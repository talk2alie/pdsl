import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { PressRelease } from './press-release.model';
import { pressReleases } from './press-release.data';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class PressReleaseService {

    getMostRecentPressReleases(): PressRelease[] {
        return pressReleases;
    }
}
