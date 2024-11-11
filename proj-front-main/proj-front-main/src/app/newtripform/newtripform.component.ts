import { Component, OnInit,ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Route, Router } from '@angular/router';
import { Trips } from '../shared/trip';
import { TripsService } from '../shared/trips.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-newtripform',
  templateUrl: './newtripform.component.html',
  styleUrl: './newtripform.component.css'
})
export class NewtripformComponent implements OnInit {
trip:Trips;
isInvalidDate:boolean=false;
tripId:string;
@ViewChild('f') tripForm:NgForm;
constructor(private updateservice:TripsService,private route:ActivatedRoute,private router:Router){}
ngOnInit(): void {
  this.route.params.subscribe(
    (data:Params)=>{
      this.tripId=data['id']
      this.updateservice.getTrip(this.tripId).subscribe({
        next:(data:Trips)=>{
           console.log(data);
           this.trip=data[0]
           this.tripForm.form.patchValue({
            'creatorUserId':this.trip.creatorUserId,
            'vehicleId':this.trip.vehicleId,
            'rideDate':this.trip.rideDate,
            'rideTime':this.trip.rideTime,
            'rideStatus':this.trip.rideStatus,
            'noOfSeat':this.trip.noOfSeat,
            'seatsFilled':this.trip.seatsFilled,
            'fromLoc':this.trip.fromLoc,
            'toLoc':this.trip.toLoc
           })
        },
        error:(err)=>{
          console.log(err);
        }
      })
    }
  )
}

onSubmit(){
 this.updateservice.updateTrip(this.trip.tripId,this.tripForm.value).subscribe({
  next:res=>{
    console.log("updated successfully");
    this.router.navigate(['/trip']);
    alert('Details of Trip updated successfully');
  },
  error:err=>{
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
