import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDto } from './pages/login/user.dto';

const url = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) 
  { }

  public registration(body: any) : Observable<any>{ 
    return this.http.post(url + `/registration`, body);
  }

  public login(userDto: UserDto) : Observable<any>{ 
    return this.http.post<any>(url + `/login`, userDto, { responseType: 'text' as 'json'});
  }


public getDataFromToken() : any
  {
    let token : any;
    let decoded_token : any;
    let result : any;
    token = localStorage.getItem("token");
    decoded_token = this.getDecodedAccessToken(token);
    return decoded_token;
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    }
    catch (Error) {
      return null;
    }
  }
}
function jwt_decode(token: string): any {
  throw new Error('Function not implemented.');
}

