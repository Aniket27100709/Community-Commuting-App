import { Component, ViewChild,OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Trips } from '../shared/trip';
import { TripsService } from '../shared/trips.service';

@Component({
  selector: 'app-tripform',
  templateUrl: './tripform.component.html',
  styleUrl: './tripform.component.css'
})
export class TripformComponent {

  @ViewChild('f') tripForm:NgForm;
  isInvalidDate:boolean=false
  
  trip:Trips;
  //DateTime today = DateTime.Today;

  constructor(private tripService:TripsService,private router:Router){}

  onSubmit(){
    console.log(this.tripForm)

   this.tripService.createTrip(this.tripForm.value).subscribe({
     next:(data)=>{
     // console.log(data)
       this.trip=data;
       this.router.navigate(['trip'])
       alert('Trip Details added successfully');
      //  data.tripId=this.tripForm.value;
      //  data.creatorUserId=this.trip
      // console.log()
     },
     error:(err)=>{
       console.log(err);
     }
   });

    this.tripService.updateTrip(this.trip.tripId,this.trip).subscribe({
      next:(data)=>{
        this.trip=data;
        this.router.navigate(['trip'])
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }
  getTodayDate() {
    const today = new Date();
    let value=new Date(this.tripForm.value['rideDate']);
    if(value<=today){
      this.isInvalidDate=true;
      this.tripForm.controls['rideDate'].setErrors({isErr:true})
    }
    else{
      this.isInvalidDate=false;
      // this.tripForm.controls['rideDate'].remo
    }
    console.log(this.isInvalidDate)
  }
}
