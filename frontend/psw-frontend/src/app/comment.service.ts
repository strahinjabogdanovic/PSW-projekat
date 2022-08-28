import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentDTO } from './pages/comment/comment.dto';
import axios from "axios";

const url = 'http://localhost:5000';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor (private http: HttpClient) {}

    GetAprovedComments(): Observable<any> {
      // const token = localStorage.getItem('jwtToken');
      // let headers = new Headers();
      // headers.append('Authorization', 'Bearer ' + token);
      //axios.get(url+"/comments").then((resp)=>{console.log(resp)})
      return this.http.get<any>(url + '/comments');
  }
    SendComment(comment: CommentDTO):Observable<any> {
      return this.http.post<any>(url + "/comments", comment, { responseType: 'text' as 'json'});
    }

    GetAp(): Observable<any>{
      return this.http.get<any>(url + '/commentAp');
    }
}
