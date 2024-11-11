import { Component,ViewChild } from '@angular/core';
import { BillsNew } from '../shared/billnew';
import { NgForm } from '@angular/forms';
import { BillsnewService } from '../shared/billsnew.service';
@Component({
  selector: 'app-billsnew',
  templateUrl: './billsnew.component.html',
  styleUrl: './billsnew.component.css'
})
export class BillsnewComponent {
  bills:BillsNew[];

  @ViewChild('f') billForm:NgForm

  constructor(private billService:BillsnewService){}

  Floorf(a){
    return Math.floor(a);
  }
  onSubmit(){
    let val=this.billForm.value;
    this.billService.getBillsByRideId(val['rideId']).subscribe({
      next:(data:BillsNew[])=>{
      this.bills=data;
         console.log(data)
      },
      error:(err)=>{

      }
    })
  }
}
