import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AppointmentObserveService } from 'src/app/appointment.service';
import { GiveRecipeComponent } from '../give-recipe/give-recipe.component';
import { elementAt } from 'rxjs';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-doctor-home-page',
  templateUrl: './doctor-home-page.component.html',
  styleUrls: ['./doctor-home-page.component.css']
})
export class DoctorHomePageComponent implements OnInit {
  displayedColumns: string[] = ['id', 'start time', 'patient', 'status', 'giveRecipe'];
  dataSource = [];
  appointmentId: any;
  id: any = "";
  appointments: any[] = [];

  constructor(private route: ActivatedRoute, private router: Router, public matDialog: MatDialog, private _snackBar: MatSnackBar, private observeAppointemntsService: AppointmentObserveService) { }



  ngOnInit(): void {
    this.id = localStorage.getItem('Id');
    console.log(this.id);

    this.observeAppointemntsService.GetDoctorsAppointments(this.id).subscribe((data: any)=>{
      this.dataSource = data;   
    });
  }

  GiveRecipe(element: {idA: number}){
    this.appointmentId = element.idA;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = 'modal-component';
    dialogConfig.height = 'fit-content';
    dialogConfig.width = '500px';
    let dialogRef = this.matDialog.open(GiveRecipeComponent, dialogConfig);
    dialogRef.componentInstance.idR = this.appointmentId;
    this.ngOnInit();
    
  }

}
