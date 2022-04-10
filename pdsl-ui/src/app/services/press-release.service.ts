import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PressRelease } from './press-release.model';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class PressReleaseService {
    private baseUrl = 'https://localhost:7223/';

    constructor(private http: HttpClient) {}

    getMostRecentPressReleases(): Observable<PressRelease[]> {
        const mostRecentReleases = 'release/most-recent';
        return this.http.get<PressRelease[]>(
            `${this.baseUrl}${mostRecentReleases}`
        ).pipe(map((releases: PressRelease[]) => {
            releases.forEach(release => {
                release.bannerImagePath = `${this.baseUrl}${release.bannerImagePath}`;
                release.filePath = `${this.baseUrl}${release.filePath}`;
            })

            return releases;
        }));
    }

    getArchivedReleases(): Observable<PressRelease[]> {
        const archivedReleases = 'release/archived';
        return this.http.get<PressRelease[]>(
            `${this.baseUrl}${archivedReleases}`
        );
    }

    uploadNewPressRelease(formData: FormData) : Observable<PressRelease> {
        return this.http.post<PressRelease>(`${this.baseUrl}release`, formData);
    }
}
