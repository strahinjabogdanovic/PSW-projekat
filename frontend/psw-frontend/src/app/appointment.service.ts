import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

const url = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class AppointmentObserveService {

  constructor(private http: HttpClient) {}
  
  GetAppointments(id: number): Observable<any> {
    console.log(id);
    return this.http.get<any>(url + '/observeAppointments/',{params:{id: id}});
  }

  CancelAppointment(id: number): any {
    return this.http.post<any>(url + '/cancelAppointments', id);
  }
}