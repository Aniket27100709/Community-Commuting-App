import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Smile } from '../shared/smile';
import { SmileService } from '../shared/smile.service';

@Component({
  selector: 'app-smile',
  templateUrl: './smile.component.html',
  styleUrl: './smile.component.css'
})
export class SmileComponent {

  smiles:Smile[];

  @ViewChild('f') smileForm:NgForm

  constructor(private smileService:SmileService){}


  onSubmit(){
    let val=this.smileForm.value;
    this.smileService.getSmileDetailsByMonthNrpId(val['month'],val['rpId']).subscribe({
      next:(data:Smile[])=>{
        this.smiles=data;
        console.log(data)
      },
      error:(err)=>{

      }
    })
  }


}
