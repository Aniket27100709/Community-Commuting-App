import { Time } from "@angular/common";

export class Trips{

    constructor(
        public tripId:string,
        public creatorUserId:string,
        public vehicleId:string,
        public rideDate:Date,
        public rideTime:Time,
        public rideStatus:string,
        public noOfSeat: number,
        public seatsFilled:number,
        public fromLoc: string,
        public toLoc:string){}

}

