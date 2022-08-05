import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patient-home-page',
  templateUrl: './patient-home-page.component.html',
  styleUrls: ['./patient-home-page.component.css']
})
export class PatientHomePageComponent implements OnInit {
  id: any = "";

  //constructor(private medicalRecordService: MedicalRecordService, private domSanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.id = localStorage.getItem('id');
    //this.medicalRecordService.GetMedicalRecord(this.id).subscribe((data: any)=>{

   // });
  }
}
  //  this.getToken();

  /*private getToken(): void {
    if(this.route.snapshot.params['token'] === undefined || this.route.snapshot.params['token'] === null){
      this.token = JSON.parse(localStorage.getItem('token') || '{}');
    }else{
      this.token = this.route.snapshot.params['token'];
    }
    this.decodedToken = this.getDecodedAccessToken(this.token);
    if (this.decodedToken === null || this.decodedToken === undefined) {
      alert("Nije dozvoljen pristup ovde");
      this.router.navigate(['landingPage']);
    }else {
      localStorage.setItem('token', JSON.stringify(this.token));
      if(this.decodedToken.user_role === 'ADMIN'){
        alert("Nije dozvoljen pristup");
        this.router.navigate(['adminHomePage']);
      }else {
        this.router.navigate(['patientHomePage']);
      }
    }
  }
  
  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    }
    catch (Error) {
      return null;
    }
  }

}
function jwt_decode(token: string): any {
  throw new Error('Function not implemented.');
}
}*/

