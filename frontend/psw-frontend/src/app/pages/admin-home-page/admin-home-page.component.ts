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
  displayedColumns: string[] = ['name', 'content', 'rating', 'approve', 'remove'];
  id: any = "";
  public comments: any[];
  public comment: CommentDTO;
  public content: string = "";
  public disabled = true;
  dataSource = [];
  
  constructor(private route: ActivatedRoute, private router: Router, private patientCommentService: CommentService) { 
    this.comments = [];
    this.comment = new CommentDTO()
  }

  ngOnInit(): void {
    this.id = localStorage.getItem('Id');

    this.patientCommentService.GetAprovedComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
        this.dataSource = data;
     }
    })
  }

  Approve(stagod: any, stagodd: any, stagoddd: any){
    this.comment.Name = stagod;
    this.comment.Content = stagodd;
    this.comment.Rating = stagoddd;
    this.disabled = !this.disabled;
     this.patientCommentService.SendComment(this.comment).subscribe((data: any)=>{
      alert("Comment approved");
    })
    window.location.reload();
  }

  Remove(stagod: any, stagodd: any, stagoddd: any){
    alert("Maknuto");
    this.comment.Name = stagod;
    this.comment.Content = stagodd;
    this.comment.Rating = stagoddd;
    this.comment.CanPublish = false;
    this.disabled = !this.disabled;
    this.patientCommentService.SendComment(this.comment).subscribe((data: any)=>{
    })
    window.location.reload();
  }

}
