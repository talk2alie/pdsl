import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterVisitorOutputViewModel, VisitorViewModel } from '../shared/register-visitor.model';
import { Observable } from 'rxjs';
import { VerifyCodeVisitorOutputViewModel, VerifyCodeVisitorViewModel } from '../shared/verify-code.model';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class PdslApiService {
    private baseUrl = environment.apiBaseUrl;

    constructor(private httpClient: HttpClient) {}

    registerVisitor(
        visitor: VisitorViewModel
    ): Observable<RegisterVisitorOutputViewModel> {
        let url = `${this.baseUrl}/send`;
        return this.httpClient.post<RegisterVisitorOutputViewModel>(url, visitor);
    }

    verifyCode(
        visitorToVerify: VerifyCodeVisitorViewModel
    ): Observable<VerifyCodeVisitorOutputViewModel> {
        let url = `${this.baseUrl}/verify`;
        return this.httpClient.post<VerifyCodeVisitorOutputViewModel>(
            url,
            visitorToVerify
        );
    }
}
