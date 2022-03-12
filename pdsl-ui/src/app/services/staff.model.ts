import { Paragraph } from './paragraph.model';

export interface Staff {
    id: number;
    name: string;
    shortTitle?: String;
    title: string;
    accolades?: string;
    profileImagePath: string;
    bio?: Paragraph[];
}
