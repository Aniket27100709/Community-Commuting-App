import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Trips } from './trip';

@Injectable({
  providedIn: 'root'
})
export class TripsService {

  constructor(public http:HttpClient) { }
 getTrip(tripId:string):Observable<Trips>{
  return this.http.get<Trips>(`https://localhost:7156/api/RideProvider/bookingStatus/${tripId}`)
 }
 createTrip(trip:Trips):Observable<Trips>{
  // console.log(trip.seatsFilled)
  return this.http.post<Trips>(`https://localhost:7156/api/RideProvider/addbooking`,trip);
 }

 updateTrip(tripId:string,trip:Trips):Observable<Trips>{
  return this.http.put<Trips>(`https://localhost:7156/api/RideProvider/bookings/${tripId}`,trip);
 }
}
