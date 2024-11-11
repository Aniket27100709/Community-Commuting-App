import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RideprovideComponent } from './rideprovide/rideprovide.component';
import { TripComponent } from './trip/trip.component';
import {FormsModule, NgForm, ReactiveFormsModule} from '@angular/forms';
import { BilldetailComponent } from './billdetail/billdetail.component';
import { SmileComponent } from './smile/smile.component';
import { LoginComponent } from './login/login.component';
import { RideformComponent } from './rideform/rideform.component';
import { DatePipe } from '@angular/common';
import { TripformComponent } from './tripform/tripform.component';
import { BillsnewComponent } from './billsnew/billsnew.component';
import { RouterModule } from '@angular/router';
import { NewtripformComponent } from './newtripform/newtripform.component';
import { UpdaterideformComponent } from './rideform/updaterideform/updaterideform.component';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RideprovideComponent,
    TripComponent,
    BilldetailComponent,
    SmileComponent,
    RideformComponent,
    TripformComponent,
    BillsnewComponent,
    NewtripformComponent,
    UpdaterideformComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule
  ],
  providers: [
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
