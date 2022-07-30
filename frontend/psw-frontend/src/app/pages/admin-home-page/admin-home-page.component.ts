import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-admin-home-page',
  templateUrl: './admin-home-page.component.html',
  styleUrls: ['./admin-home-page.component.css']
})
export class AdminHomePageComponent implements OnInit {
  public token: any;
  public decodedToken: any;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.getToken();
  }
  private getToken(): void {
    if (this.decodedToken !== null) {
      alert("Ne mozete da pristupite ovoj stranici!");
      this.router.navigate(['patientHomePage']);
    }
  }

}
