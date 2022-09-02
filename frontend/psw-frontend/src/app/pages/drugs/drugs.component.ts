import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentObserveService } from 'src/app/appointment.service';
import { ReplenishDrugsComponent } from '../replenish-drugs/replenish-drugs.component';

@Component({
  selector: 'app-drugs',
  templateUrl: './drugs.component.html',
  styleUrls: ['./drugs.component.css']
})
export class DrugsComponent implements OnInit {

  displayedColumns: string[] = ['idL', 'medicine', 'quantity', 'mgs'];
  dataSource = [];

  constructor(private route: ActivatedRoute, private router: Router, public matDialog: MatDialog, private observeAppointemntsService: AppointmentObserveService) { }

  ngOnInit(): void {

    this.observeAppointemntsService.GetDrugs().subscribe((data: any)=>{
      this.dataSource = data;   
    });
  }

  Replenish(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = 'modal-component';
    dialogConfig.height = 'fit-content';
    dialogConfig.width = '500px';
    let dialogRef = this.matDialog.open(ReplenishDrugsComponent, dialogConfig);
    this.ngOnInit();
  }

}
