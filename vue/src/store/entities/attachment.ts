import Entity from './entity'
export default class Attachment extends Entity<string>{
    id:string;
    name:string;
    fileSize:number;
    absoluteUrl:string;
    extenson:string;
}