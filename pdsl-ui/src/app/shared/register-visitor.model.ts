export interface VisitorViewModel {
    fullName: string;
    organization: string;
    email: string;
}

export interface RegisterVisitorViewModel extends VisitorViewModel { }

export interface RegisterVisitorOutputViewModel extends VisitorViewModel {
    isCodeSent: boolean;
    isCodeVerified: boolean;
}
