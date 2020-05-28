import Entity from './entity'
export default class Attachment extends Entity<number>{
    id:number;
    name:string;
    fileSize:number;
}