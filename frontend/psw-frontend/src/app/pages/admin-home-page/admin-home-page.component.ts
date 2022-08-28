import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommentService } from 'src/app/comment.service';
import { CommentDTO } from '../comment/comment.dto';

@Component({
  selector: 'app-admin-home-page',
  templateUrl: './admin-home-page.component.html',
  styleUrls: ['./admin-home-page.component.css']
})
export class AdminHomePageComponent implements OnInit {
  id: any = "";
  public comments: any[];
  public comment: CommentDTO;
  public content: string = "";
  public disabled = true;
  
  constructor(private route: ActivatedRoute, private router: Router, private patientCommentService: CommentService) { 
    this.comments = [];
    this.comment = new CommentDTO()
  }

  ngOnInit(): void {
    this.id = localStorage.getItem('Id');
    console.log(this.id);

    this.patientCommentService.GetAprovedComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
     }
    })
  }

  Approve(stagod: any, stagodd: any, stagoddd: any){
    this.comment.Name = stagod;
    this.comment.Content = stagodd;
    this.comment.Rating = stagoddd;
   /* if(this.comment.CanPublish == true){
      this.disabled = true;
    }else{
      this.disabled = false;
    }*/
    this.disabled = !this.disabled;
    console.log(this.comment);
     this.patientCommentService.SendComment(this.comment).subscribe((data: any)=>{
      alert("Comment approved");
    })
  }

  Remove(){
    alert("Maknuto");
    this.disabled = !this.disabled;
  }

}
