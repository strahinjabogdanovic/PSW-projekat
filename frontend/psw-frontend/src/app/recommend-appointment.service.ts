import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RecommendAppointmentDto } from 'src/app/pages/recommend-appointment/recommend-appointment-dto';

const url = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class RecommendAppointmentService {
  //url: string;
  constructor(private http: HttpClient) { 
   
    //this.url = "http://" + environment.apiUrl + ":" + environment.port +"/api";
  }

  GetAllDoctors(): Observable<any> {
      return this.http.get<any>(url + '/findDoctors');
  }
  
  FindAppointments(appointment: RecommendAppointmentDto): Observable<any>{
    return this.http.post<any>(url + "/recommendedAppointment", appointment);
  }

  Schedule(start: Date, id: number, patientId: number): Observable<any>{
    const body = {
      Start : start,
      Id : id,
      PatientId: patientId
    }
    return this.http.post<any>(url + "/recommendedAppointment/schedule", body);
  }
}