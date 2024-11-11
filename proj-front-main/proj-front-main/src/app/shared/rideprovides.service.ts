import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Rideprovides } from './rideprovides';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RideprovidesService {
//All types of http calls are managed over here

  constructor(private http:HttpClient) { }
  getRide():Observable<Rideprovides[]>{
    const URL="https://localhost:7156/"+'api/RideProvider/Rideprovide'; 
    return this.http.get<Rideprovides[]>(URL);
  } 
  DeleteRide(rpId:string){
    const URL="https://localhost:7156/"+`api/RideProvider/${rpId}/delete`;
    return this.http.delete<any>(URL)
  }
  createRide(ride:Rideprovides){
    console.log(ride.phone);
    return this.http.post<Rideprovides>(`https://localhost:7156/api/RideProvider/new`,ride);
  }
  updateRide(rpId:string,status:{status:string}):Observable<Rideprovides>{
    return this.http.put<Rideprovides>(`https://localhost:7156/api/RideProvider/${rpId}/update`,status);
   }
   getRideById(rpId:string):Observable<Rideprovides>{
    return this.http.get<Rideprovides>(`https://localhost:7156/api/RideProvider/${rpId}`)
   }

}
