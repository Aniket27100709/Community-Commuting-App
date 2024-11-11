import { Component, ViewChild } from '@angular/core';
import { Trips } from '../shared/trip';
import { TripsService } from '../shared/trips.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-trip',
  templateUrl: './trip.component.html',
  styleUrl: './trip.component.css'
})
export class TripComponent {
trips:Trips;
@ViewChild('f') tripForm:NgForm
  constructor(private tripService:TripsService,private router:Router) {}
 
  onSubmit(){
   let val=this.tripForm.value;
   this.tripService.getTrip(val['tripId']).subscribe({
    next:(data:Trips)=>{
      // console.log(data)
      this.trips=data[0];
    },
    error:(err)=>{

    }
   })
 };
 
}
