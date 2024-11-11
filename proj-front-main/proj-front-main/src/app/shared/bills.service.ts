import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bills } from './bill';

@Injectable({
  providedIn: 'root'
})
export class BillsService {

  constructor(private http:HttpClient) { }
  getBillsByMonth(month:number):Observable<Bills>{
    return this.http.get<Bills>(`https://localhost:7156/api/RideProvider/billing/${month}`)
  }
}
