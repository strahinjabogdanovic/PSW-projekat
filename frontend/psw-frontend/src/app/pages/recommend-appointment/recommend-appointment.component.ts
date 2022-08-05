import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators} from '@angular/forms';
import { RecommendAppointmentService } from 'src/app/recommend-appointment.service';
import { RecommendAppointmentDto } from './recommend-appointment-dto';
import { DatePipe, formatDate } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AvailableRecommendedAppointments } from './available-recommended-appointments';
import { Router } from '@angular/router';


export interface SelectedDoctor{
  name: string;
}

export interface RecommendedAppointment{
  startDate: Date;
  endDate: Date;
  doctorId: number;
  specialization: number;
  priority: number;
}

@Component({
  selector: 'app-recommend-appointment',
  templateUrl: './recommend-appointment.component.html',
  styleUrls: ['./recommend-appointment.component.css']
})
export class RecommendAppointmentComponent implements OnInit {

  doctors: any[]=[];
  selectedDoctor: SelectedDoctor = {name: ""};
  recommendForm: FormGroup;
  appointmentsRecomended: AvailableRecommendedAppointments[] = new Array();
  start: Date = new Date;
  doctorName: string = "";
  doctorId: number = 0;
  id: any = "";
  IdA: number = 0;

  appointment: RecommendedAppointment = {startDate: new Date(),endDate: new Date(), doctorId: 0, specialization: 0, priority: 1};
  public returnAppointment: RecommendAppointmentDto;


  displayedColumns: string[] = ['position', 'Date', 'Time', 'Doctor', '#'];

  constructor(private recommendAppointmentService: RecommendAppointmentService,private formBuilder: FormBuilder, private _snackBar: MatSnackBar, private router: Router) {
    this.returnAppointment = new RecommendAppointmentDto(); 
    this.recommendForm = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
  }

  get f() { return this.recommendForm.controls; }

  public hasError = (controlName: string, errorName: string) =>{
    return this.recommendForm.controls[controlName].hasError(errorName);
  }

  ngOnInit(): void {

    this.recommendForm = this.formBuilder.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      doctor: ['', Validators.required],
      priority: ['', Validators.required]
    });

    this.recommendAppointmentService.GetAllDoctors().subscribe((data: any)=>{
      console.log(data);
      for(const p of (data as any)){
        this.doctors.push(p);      
      }
    })
  }

  onSubmit(){

    this.PrepareDTO();
     for(const d of this.doctors){
       if(d.nameAndSurname == this.selectedDoctor.name){
         this.returnAppointment.DoctorId = d.idD;
       }
      }

    this.recommendAppointmentService.FindAppointments(this.returnAppointment).subscribe(data => {
      this.appointmentsRecomended = data;
      this.DoctorsNames();
    });

   
  }

  PrepareDTO(){
    this.returnAppointment.Priority = this.appointment.priority;

    const format = "MM/dd/yyyy HH:mm:ss a"

    this.returnAppointment.StartInterval = formatDate(this.appointment.startDate, format, "en-US");
    this.returnAppointment.EndInterval = formatDate(this.appointment.endDate, format, "en-US");

  }

  DoctorsNames(){
    for(const a of this.appointmentsRecomended){
      for(const d of this.doctors){
        if(a.doctorId == d.idD){
          a.doctorFullName = d.nameAndSurname;
        }
      }
    }
  }

  schedule(element: { start: Date; doctorFullName: string; }) {
    this.start = element.start;
    this.doctorName = element.doctorFullName;
    this.id = localStorage.getItem('id');
    for(const d of this.doctors){
      if(d.nameAndSurname == this.doctorName){
        this.doctorId = d.idD;
      }
    }
   
    this.recommendAppointmentService.Schedule(this.start, this.doctorId, this.id).subscribe(data => {
     console.log(this.id);
     console.log(this.doctorId);
      alert("Zauzet termin u " + this.start);
     this.router.navigate(['/observeAppointments/' + this.id]);
    });
  }

}