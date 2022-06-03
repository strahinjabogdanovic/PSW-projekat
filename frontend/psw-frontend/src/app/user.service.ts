import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  url: string;

  constructor(private http: HttpClient) 
  { 
    this.url = "http://" + environment.apiUrl + ":" + environment.port +"/api";
  }

  public registration(body: any) : Observable<any>{ 
    return this.http.post(`/registration`, body);
  }

}
