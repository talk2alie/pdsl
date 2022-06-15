import { VisitorViewModel } from './register-visitor.model';

export interface VerifyCodeVisitorViewModel extends VisitorViewModel {
    code: string;
}

export interface VerifyCodeVisitorOutputViewModel extends VisitorViewModel {
    isCodeVerified: boolean;
}