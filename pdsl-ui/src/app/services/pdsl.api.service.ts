import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterVisitorViewModel } from './register-visitor.model';
import { Observable } from 'rxjs';
import { VisitorOutputViewModel } from './visitor-output.model';
import { VerifyCodeViewModel } from './verify-code.model';

@Injectable({ providedIn: 'root' })
export class PdslApiService {
    private baseUrl = 'https://localhost:7006';

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
