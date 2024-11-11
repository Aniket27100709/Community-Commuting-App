using CCA_BAL.DTO;
using CCA_BAL.Interface;
using CCA_DAL.Interface;
using CCA_BAL.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA_DAL.Models;

namespace CCA_BAL.Service
{
    public class TripService:ITripService
    {
        private readonly ITripManage _tripRepository;
        public TripService(ITripManage tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<Output> CreateTrip(TripBookingDTO tripBookingDTO)
        {
              
            Trip models = new Trip()
            {
                tripId = tripBookingDTO.TripId,
                creatorUserId = tripBookingDTO.CreatorUserId,
                vehicleId = tripBookingDTO.VehicleId,
                rideDate = tripBookingDTO.RideDate,
                rideTime = tripBookingDTO.RideTime,
                rideStatus = "booked",
                noOfSeat = tripBookingDTO.NoOfSeat,
                seatsFilled = tripBookingDTO.SeatsFilled,
                fromLoc = tripBookingDTO.FromLoc,
                toLoc = tripBookingDTO.ToLoc
            };
            var changes = await _tripRepository.AddTripDetails(models);
            return new Output
            {
                Result = true,
            };
        }
        public async Task<List<TripBookingDTO>> getTrip(string tripId)
        {
            List<Trip> ans=await _tripRepository.GetTripDetails(tripId);
            List<TripBookingDTO> l = new List<TripBookingDTO>();
           foreach(Trip i in ans)
            {
               
                    TripBookingDTO tbk = new TripBookingDTO()
                    {
                        TripId = tripId,
                        CreatorUserId = i.creatorUserId,
                        VehicleId = i.vehicleId,
                        RideDate = i.rideDate,
                        RideTime = i.rideTime,
                        RideStatus = i.rideStatus,
                        NoOfSeat = i.noOfSeat,
                        SeatsFilled = i.seatsFilled,
                        FromLoc = i.fromLoc,
                        ToLoc = i.toLoc
                    };
                    l.Add(tbk);
                
            }
            return l;
        }
        public async Task<Output> updateTrip(string tripId, TripBookingDTO tripBookingDTO)
        {
            try
            {
                var obj=await _tripRepository.FindTripById(tripId);
                obj.tripId=tripId;
                obj.vehicleId=tripBookingDTO.VehicleId;
                obj.creatorUserId=tripBookingDTO.CreatorUserId;
                obj.rideDate=tripBookingDTO.RideDate;
                obj.rideTime=tripBookingDTO.RideTime;
                obj.rideStatus=tripBookingDTO.RideStatus;
                obj.noOfSeat=tripBookingDTO.NoOfSeat;
                obj.seatsFilled=tripBookingDTO.SeatsFilled;
                obj.fromLoc=tripBookingDTO.FromLoc;
                obj.toLoc=tripBookingDTO.ToLoc;
                var changes = await _tripRepository.UpdateTripDetails(obj);
                return new Output
                {
                    Result = true,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
        public async Task<bool> checkTripExist(string tripId)
        {
            var obj = await _tripRepository.FindTripById(tripId);
            if (obj != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsSeatNegative(int noOfSeat)
        {
            if (noOfSeat <= 0)
            {
                return false;
            }
            return true;
        }
        private bool IsSeatsFilledGreater(int noOfSeat, int seatsFilled)
        {
            if(noOfSeat < seatsFilled)
            {
                return false;
            }
            return true;
        }

        private bool checkDateTimeInFuture(DateOnly date,TimeOnly time) {
            if (date < DateOnly.FromDateTime(DateTime.Today))
            {
                return false;
            }
            else if (date == DateOnly.FromDateTime(DateTime.Today))
            {
                if(time<TimeOnly.FromDateTime(DateTime.Today))return false;
            }
            return true;
        }
    }
}
