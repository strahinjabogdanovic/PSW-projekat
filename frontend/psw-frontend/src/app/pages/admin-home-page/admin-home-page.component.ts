import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(private route: ActivatedRoute, private router: Router) { 
    this.comments = [];
    this.comment = new CommentDTO()
  }

  ngOnInit(): void {
    this.id = localStorage.getItem('Id');
    console.log(this.id);
  }

}
