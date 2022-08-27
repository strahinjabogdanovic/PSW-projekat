import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const url = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  constructor (private http: HttpClient) {}

  GetSurveyQuestions(): Observable<any> {
      return this.http.get<any>(url + '/survey');
  }
  
  PostSurveyQuestions(Survey: any, id: any, ap: any): Observable<any> {
    return this.http.post<any>(url + "/survey/"+id +"/"+ap, Survey);
  }
}
