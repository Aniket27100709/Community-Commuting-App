import { Component,ViewChild } from '@angular/core';
import { Bills } from '../shared/bill';
import { NgForm } from '@angular/forms';
import { BillsService } from '../shared/bills.service';

@Component({
  selector: 'app-billdetail',
  templateUrl: './billdetail.component.html',
  styleUrl: './billdetail.component.css'
})
export class BilldetailComponent {
  bills:Bills;

  @ViewChild('f') billForm:NgForm

  constructor(private billService:BillsService){}
  onSubmit(){
    let val=this.billForm.value;
    console.log(typeof(val['month']))
    this.billService.getBillsByMonth(val['month']).subscribe({
      next:(data:Bills)=>{
       this.bills=data;
        //console.log(data)
      },
      error:(err)=>{

      }
    })
  }
}
