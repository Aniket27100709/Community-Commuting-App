import { DatePipe } from '@angular/common';
import { Component,OnInit } from '@angular/core';
import { Rideprovides } from '../shared/rideprovides';
import { RideprovidesService } from '../shared/rideprovides.service';

@Component({
  selector: 'app-rideprovide',
  templateUrl: './rideprovide.component.html',
  styleUrl: './rideprovide.component.css'
})
export class RideprovideComponent implements OnInit{

constructor(public rideService:RideprovidesService) {}
rides:Rideprovides[];
  ngOnInit(){
     this.GetAllRides();
  }
 deleteRow(event:any,rpId:string){
      event.preventDefault();
     this.rideService.DeleteRide(rpId).subscribe({
       next:()=>{
         this.GetAllRides();
         alert('deleted the rideprovider details');
       },
       error:(err)=>{

       }
     })

   }
GetAllRides(){
  this.rideService.getRide().subscribe({
    next:(data)=>{
      this.rides=data
    },
    error:(err)=>{

    }
  })
}
}
