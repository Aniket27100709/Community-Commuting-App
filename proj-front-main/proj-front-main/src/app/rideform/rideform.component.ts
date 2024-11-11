import { Component,ViewChild } from '@angular/core';
import { RideprovidesService } from '../shared/rideprovides.service';
import { Rideprovides } from '../shared/rideprovides';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-rideform',
  templateUrl: './rideform.component.html',
  styleUrl: './rideform.component.css'
})
export class RideformComponent {
  @ViewChild('f') rideForm:NgForm;
  ride:Rideprovides;
 constructor(public rideService:RideprovidesService,private router:Router){}
onSubmit(){
  this.rideForm.value['rpId']="1"
  console.log(this.rideForm.value);
  this.rideService.createRide(this.rideForm.value).subscribe({
    next:(data)=>{
      console.log(data);
      this.ride=data;
      this.router.navigate(['rideprovide'])
      alert('Details of RideProvider added successfully');
    },
    error:(err)=>{
      console.log(err);
    }
  });
}
}
