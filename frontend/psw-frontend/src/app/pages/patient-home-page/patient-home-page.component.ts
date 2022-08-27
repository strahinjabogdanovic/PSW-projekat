import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patient-home-page',
  templateUrl: './patient-home-page.component.html',
  styleUrls: ['./patient-home-page.component.css']
})
export class PatientHomePageComponent implements OnInit {
  id: any = "";

  ngOnInit(): void {
    this.id = localStorage.getItem('Id');
  }
}