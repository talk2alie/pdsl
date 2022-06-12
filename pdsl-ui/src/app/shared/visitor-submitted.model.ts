import { VisitorOutputViewModel } from './visitor-output.model';

export interface VisitorSubmittedViewModel extends VisitorOutputViewModel {
    identitySubmitted: boolean;
}