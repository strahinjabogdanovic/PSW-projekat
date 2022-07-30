import { Component, Input, OnInit } from '@angular/core';
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
  displayedColumns: string[] = ['id', 'start time', 'description', 'doctor', 'status','survey','cancel'];
  dataSource = [];
  surveys: any[] = []
  appointmentId: any;
  id: any = "";


  constructor(private observeAppointemntsService: AppointmentObserveService, private router: Router, private _snackBar: MatSnackBar) { }

  CancelAppointment(element: { id: number }){
    this.appointmentId = element.id;
    
    this.observeAppointemntsService.CancelAppointment(element.id).subscribe((data: any) =>{
      this.ngOnInit();
      this._snackBar.open('Appointment cancelled!', '', {
        duration: 2000
      });
    });
    
  }

  ngOnInit(): void {
    this.id = localStorage.getItem('id');
    this.observeAppointemntsService.GetAppointments(this.id).subscribe((data: any)=>{
      console.log(data);
    this.dataSource = data;
  });
  }
 

}