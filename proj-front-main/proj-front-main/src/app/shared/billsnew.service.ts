import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BillsNew } from './billnew';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class BillsnewService {

  constructor(private http:HttpClient) { }
  getBillsByRideId(tripId:string):Observable<BillsNew[]>{
    return this.http.get<BillsNew[]>(`https://localhost:7156/api/RideProvider/generatebill/${tripId}`)
  }
}
