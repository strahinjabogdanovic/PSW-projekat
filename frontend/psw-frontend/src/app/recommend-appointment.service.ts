import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RecommendAppointmentDto } from 'src/app/pages/recommend-appointment/recommend-appointment-dto';
import { RecipeDto } from './pages/give-recipe/recipe.dto';

const url = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class RecommendAppointmentService {

  constructor(private http: HttpClient) { 
  }

  UnblockUser(Id: number): Observable<any> {
    return this.http.post<any>(url + "/unblock", Id);
  }

  BlockUser(Id: number): Observable<any> {
    return this.http.post<any>(url + "/block", Id);
  }

  GetAllSpecDoctors(): Observable<any> {
      return this.http.get<any>(url + '/findDoctors');
  }

  GetAllGeneralDoctors(): Observable<any> {
    return this.http.get<any>(url + '/general');
}

  GetAllPatients(): Observable<any> {
    return this.http.get<any>(url + '/findPatients');
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
    return this.http.post<any>(url + "/schedule", body);
  }

  SendRecipe(idR: number, medicine: string, quantity: string, instructions: string): Observable<any> {
    const body = {
      IdR: idR,
      Medicine: medicine,
      Quantity: quantity,
      Instructions: instructions
    }
    console.log(idR);
    return this.http.post<any>(url + "/sendRecipe", body);
  }
}