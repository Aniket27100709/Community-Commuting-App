import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BilldetailComponent } from './billdetail/billdetail.component';
import { BillsnewComponent } from './billsnew/billsnew.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NewtripformComponent } from './newtripform/newtripform.component';
import { RideformComponent } from './rideform/rideform.component';
import { UpdaterideformComponent } from './rideform/updaterideform/updaterideform.component';
import { RideprovideComponent } from './rideprovide/rideprovide.component';
import { SmileComponent } from './smile/smile.component';
import { TripComponent } from './trip/trip.component';
import { TripformComponent } from './tripform/tripform.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'rideprovide',component:RideprovideComponent},
  {path:'billdetail',component:BilldetailComponent},
  {path:'billsnew',component:BillsnewComponent},
  {path:'trip',component:TripComponent},
  {path:'smile',component:SmileComponent},
  {path:'login',component:LoginComponent},
  {path:'rideform',component:RideformComponent},
  {path:'tripform',component:TripformComponent},
  {path:'trip/:id',component:NewtripformComponent},
  {path:'rideprovide/:id',component:UpdaterideformComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
