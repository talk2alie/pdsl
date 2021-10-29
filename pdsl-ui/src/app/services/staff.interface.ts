import { Paragraph } from './paragraph.interface';

export interface Staff {
    id: number;
    name: string;
    shortTitle?: String;
    title: string;
    accolades?: string;
    profileImagePath: string;
    bio?: Paragraph[];
}
