import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommentService } from 'src/app/comment.service';
import { CommentDTO } from './comment.dto';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  pageTitle="Comments"
  public comments: any[];
  public anonymous: boolean = false;
  public content: string = "";
  public comment: CommentDTO;
  public today: Date = new Date();
  public rating : any;

  constructor(private patientCommentService: CommentService, private _snackBar: MatSnackBar) {
    this.comments = [];
    this.comment = new CommentDTO()
  }

  ngOnInit(): void {
    this.patientCommentService.GetAprovedComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
        console.log(data);
      }
    })
  }

  onSubmit():void{
    console.log(this.anonymous);

    console.log(this.content);
    this.PrepareDTO();
    console.log(this.comment);
    this.patientCommentService.SendComment(this.comment).subscribe((data: any)=>{
      this._snackBar.open('Comment sent!', '', {
        duration: 2000
      });
    });
  }
  PrepareDTO(){
    this.comment.Content = this.content;
    this.comment.Date = this.today;
    this.comment.Rating = this.rating;
    if(this.anonymous == true){
    this.comment.Name = "anonymous";
    }
    else{
      this.comment.Name = "user";
    }
  }

}
