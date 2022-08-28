export class CommentDTO{
    Name: string;
    Content: string;
    Date: Date;
    Rating: any;
    CanPublish: boolean;
    isVisible: boolean;
    constructor(){
        this.Name = "",
        this.Content = "",
        this.Date = new Date(),
        this.Rating = 0,
        this.CanPublish = true,
        this.isVisible = false
    }
}