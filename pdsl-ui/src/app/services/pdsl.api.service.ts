import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterVisitorViewModel } from '../shared/register-visitor.model';
import { Observable } from 'rxjs';
import { VisitorOutputViewModel } from '../shared/visitor-output.model';
import { VerifyCodeViewModel } from '../shared/verify-code.model';

@Injectable({ providedIn: 'root' })
export class PdslApiService {
    private baseUrl = 'https://localhost:7006/visitorverification';

    constructor(private httpClient: HttpClient) {}

    registerVisitor(
        visitor: RegisterVisitorViewModel
    ): Observable<VisitorOutputViewModel> {
        let url = `${this.baseUrl}/send`;
        return this.httpClient.post<VisitorOutputViewModel>(url, visitor);
    }

    verifyCode(visitorToVerify: VerifyCodeViewModel): Observable<VisitorOutputViewModel> {
        let url = `${this.baseUrl}/verify`;
        return this.httpClient.post<VisitorOutputViewModel>(url, visitorToVerify);
    }
}
