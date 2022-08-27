export class CommentDTO{
    Name: string;
    Content: string;
    Date: Date;
    Rating: any;
    constructor(){
        this.Name = "",
        this.Content = "",
        this.Date = new Date(),
        this.Rating = 0
    }
}