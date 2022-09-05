import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AppointmentObserveService } from 'src/app/appointment.service';

export interface Appointment {
  id: number;
  patientId: number;
}
@Component({
  selector: 'app-appointment-observe',
  templateUrl: './appointment-observe.component.html',
  styleUrls: ['./appointment-observe.component.css']
  
})
export class AppointmentObserveComponent implements OnInit {
  displayedColumns: string[] = ['id', 'start time', 'doctor', 'status', 'recipe', 'cancel', 'survey'];
  dataSource = [];
  surveys: any[] = [];
  appointmentId: any;
  id: any = "";

  appointments: any[] = [];

  constructor(private observeAppointemntsService: AppointmentObserveService, private router: Router, private _snackBar: MatSnackBar) { }

  TakeSurvey(idA: number, $myParam: number = 0, $myParam1: number = 0): void {
    const navigationDetails: string[] = ['/survey'];
    this.appointmentId = idA;
    localStorage.setItem('idA', this.appointmentId);
    if($myParam && $myParam1) {
      navigationDetails.push($myParam.toString());
      navigationDetails.push($myParam1.toString());
    }
    this.router.navigate(navigationDetails);
  }
  
  CancelAppointment(element: { idA: number }){
    this.appointmentId = element.idA;

    this.observeAppointemntsService.CancelAppointment(element.idA).subscribe((data: any) =>{
      this.ngOnInit();
      this._snackBar.open('Appointment cancelled!', '', {
        duration: 2000
      });
    });  
  }

  Recipe(element: {idA: number}){
    this.appointmentId = element.idA;
    this.observeAppointemntsService.TakeRecipe(this.appointmentId).subscribe((data: any)=>{
      this.dataSource = data;   

    });
    this.ngOnInit();
    window.location.reload();
  }

  ngOnInit(): void {

    this.id = localStorage.getItem('Id');

    this.observeAppointemntsService.GetAppointments(this.id).subscribe((data: any)=>{
      this.dataSource = data;   
    });
  }
 

}