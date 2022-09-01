import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

const url = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class AppointmentObserveService {

  headers = { headers: new Headers({ 'Content-Type': 'application/json' })};

  constructor(private http: HttpClient) {}
  
  GetAppointments(id: number): Observable<any> {
    return this.http.get<any>(url + "/observeAppointments/",{params:{id: id}});
  }

  GetDoctorsAppointments(id: number): Observable<any> {
    return this.http.get<any>(url + "/doctorsAppointments/",{params:{id: id}});
  }

  CancelAppointment(id: number): Observable<any> {
    return this.http.post<any>(url + "/cancelAppointments", id);
  }
}