import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { SurveyService } from 'src/app/survey.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  pageTitle="Survey"
  public surveys: any[];

  constructor(private surveyService:SurveyService, private _snackBar: MatSnackBar, private route: ActivatedRoute, private router: Router) { 
    this.surveys = [];
  }

  id: any;
  ap: any;

  ngOnInit(): void {
    this.surveyService.GetSurveyQuestions().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.surveys.push(p);
      }     
    })
    this.id = localStorage.getItem('Id');
    this.ap = localStorage.getItem('idA');
  }

  onSubmit(){ 
    this.surveyService.PostSurveyQuestions(this.surveys, this.id, this.ap).subscribe((data: any) =>{
      this._snackBar.open('Survey sent!', '', {
        duration: 2000
      });
    });
  }


}
