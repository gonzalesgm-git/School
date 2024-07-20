import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { Student } from './student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  url:string = `${environment.apiBaseUrl}/student`
  constructor(private httpClient:HttpClient) { 

  }

  refreshList() {
    this.httpClient.get(this.url)
      .subscribe({
        next: res => {
          console.log(res);
        },
        error: err => {
          console.log(err);
        },
      }
        
      )
  }

  list():Observable<any>{
    return this.httpClient.get(this.url);
  }

  update(student: Student): Observable<any>{
    return this.httpClient.put(`${this.url}/${student.id}`, student);
  }

  save(student: Student):Observable<any>{
    return this.httpClient.post(this.url, student);
  }

  delete(student: Student):Observable<any>{
    return this.httpClient.delete(`${this.url}/${student.id}`);
  }
}
