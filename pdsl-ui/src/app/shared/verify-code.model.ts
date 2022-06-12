import { RegisterVisitorViewModel } from './register-visitor.model';

export interface VerifyCodeViewModel extends RegisterVisitorViewModel {
    code: string;
}