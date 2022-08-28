import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommentService } from 'src/app/comment.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  public comments: any[];


  constructor(private router: Router, private patientCommentService: CommentService) {
    this.comments = [];
   }

  ngOnInit(): void {
    this.patientCommentService.GetAprovedComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
        console.log(data);
      }
    })
  }

}
