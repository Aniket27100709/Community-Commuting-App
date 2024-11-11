import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Smile } from './smile';

@Injectable({
  providedIn: 'root'
})
export class SmileService {

  constructor(private http:HttpClient) { }

  getSmileDetailsByMonthNrpId(month:number,rpId:string):Observable<Smile[]>{
    return this.http.get<Smile[]>(`https://localhost:7156/api/Smile/${month}/${rpId}`)
  }
}
