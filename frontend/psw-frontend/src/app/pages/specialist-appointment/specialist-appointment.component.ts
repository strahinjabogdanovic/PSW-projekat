import { formatDate } from '@angular/common';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { RecommendAppointmentService } from 'src/app/recommend-appointment.service';
import { AvailableRecommendedAppointments } from '../recommend-appointment/available-recommended-appointments';
import { RecommendAppointmentDto } from '../recommend-appointment/recommend-appointment-dto';  
import { jsPDF } from 'jspdf';

export interface SelectedPatient{
  name: string;
  surname: string;
}

export interface SelectedDoctor{
  name: string;
}

export interface RecommendedAppointment{
  startDate: Date;
  endDate: Date;
  doctorId: number;
  specialization: number;
  reason: string;
}

@Component({
  selector: 'app-specialist-appointment',
  templateUrl: './specialist-appointment.component.html',
  styleUrls: ['./specialist-appointment.component.css']
})
export class SpecialistAppointmentComponent implements OnInit {
  doctors: any[]=[];
  patients: any[]=[];
  selectedPatient: SelectedPatient = {name: "", surname: ""};
  selectedDoctor: SelectedDoctor = {name: ""};
  recommendForm: FormGroup;
  appointmentsRecomended: AvailableRecommendedAppointments[] = new Array();
  start: Date = new Date;
  doctorName: string = "";
  patientName: string = "";
  doctorId: number = 0;
  patientId: number = 0;
  id: any = "";

  appointment: RecommendedAppointment = {startDate: new Date(), endDate: new Date(), doctorId: 0, specialization: 0, reason: ''};
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
      patient: ['', Validators.required],
      doctor: ['', Validators.required],
      reason: ['', Validators.required]
    });

    this.recommendAppointmentService.GetAllPatients().subscribe((data: any)=>{
       for(const p of (data as any)){
        this.patients.push(p);      
      }
    })

    this.recommendAppointmentService.GetAllSpecDoctors().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.doctors.push(p);      
      }
    })
  }

  onSubmit(){
    this.PrepareDTO();
    for(const p of this.patients){
      if(p.name == this.selectedPatient.name){
        this.patientName = p.name + p.surname;
        this.patientId = p.id;
      }
     }

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

  @ViewChild('content')
  content!: ElementRef;  

  // public SavePDF(): void {  
  //   let content=this.content.nativeElement;  
  //   let doc = new jsPDF();  
  //   let _elementHandlers =  
  //   {  
  //     '#editor':function({element, renderer}: any){  
  //       return true;  
  //     }  
  //   };  
  //   doc.html(data, {
  //     callback: (doc) => {
  //       doc.output("dataurlnewwindow");
  //     }
  //  });  
  
  //   doc.save('test.pdf');  
  // }

  schedule(element: { start: Date; doctorFullName: string; }) {
    console.log(element);
    this.start = element.start;
    this.doctorName = element.doctorFullName;
    this.id = this.patientId;
    for(const d of this.doctors){
      if(d.nameAndSurname == this.doctorName){
        this.doctorId = d.idD;
      }
    }
    //this.SavePDF();
    this.recommendAppointmentService.Schedule(this.start, this.doctorId, this.id).subscribe(data => {
      alert("Zauzeli ste termin u " + this.start);
     this.router.navigate(['/observeAppointments/' + this.id]);
    });
  }

}
