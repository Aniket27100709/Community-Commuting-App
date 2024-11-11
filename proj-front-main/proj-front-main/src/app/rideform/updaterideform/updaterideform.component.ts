import { Component, OnInit,ViewChild,AfterViewInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Rideprovides } from '../../shared/rideprovides';
import { RideprovidesService } from '../../shared/rideprovides.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-updaterideform',
  templateUrl: './updaterideform.component.html',
  styleUrl: './updaterideform.component.css'
})
export class UpdaterideformComponent implements OnInit {
ride:Rideprovides;
rpId:string;
@ViewChild('f') rideForm:NgForm;

constructor(private updateservice:RideprovidesService,private route:ActivatedRoute,private router:Router) {}
  ngOnInit(): void {
    this.route.params.subscribe(
      (data:Params)=>{
        this.rpId=data['id']

        this.updateservice.getRideById(this.rpId).subscribe({
          next:(data:Rideprovides)=>{
            console.log(data);
            this.ride=data[0]
            this.rideForm.form.patchValue({
              'status':this.ride.status
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
   // console.log(this.rideForm.value);
   this.updateservice.updateRide(this.ride.rpId,this.rideForm.value).subscribe({
    next:response=>{
      console.log('updated successfully')
      this.router.navigate(['/rideprovide'])
     },
     error:error=>console.log('error occured',error)
   });
  }

}
