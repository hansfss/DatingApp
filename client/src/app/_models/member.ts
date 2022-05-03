import { Photo } from "./photo";

export interface Member {
    id: number;
    username: string;
    photoUrl: string;
    age: number;
    gender: string;
    city: string;
    country: string;
    knownAs: string;
    introduction: string;
    lookingFor: string;
    interests: string;
    created: Date;
    lastActive: Date;
    photos: Photo[];
}

