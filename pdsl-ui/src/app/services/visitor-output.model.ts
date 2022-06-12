import { RegisterVisitorViewModel } from './register-visitor.model';

export interface VisitorOutputViewModel extends RegisterVisitorViewModel {
    isVerified: boolean;
}