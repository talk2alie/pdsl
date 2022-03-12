import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { pressReleases } from './press-release.data';
import { PressRelease } from './press-release.model';

@Injectable({
    providedIn: 'root',
})
export class PressReleaseService {
    private pressReleases: PressRelease[] = pressReleases;

    getPressReleases(): Observable<PressRelease[]> {
        return new Observable<PressRelease[]>((observer) => observer.next(pressReleases));
    }
}
