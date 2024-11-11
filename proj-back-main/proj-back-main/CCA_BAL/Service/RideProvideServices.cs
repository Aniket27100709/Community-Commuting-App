using CCA_BAL.DTO;
using CCA_BAL.Interface;
using CCA_BAL.Result;
using CCA_DAL.Interface;
using CCA_DAL.Models;
using CCA_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CCA_BAL.Service
{
    public class RideProvideServices : IRideProvideService
    {

        private readonly IRideProvide _rideProvideRepository;
  
        public RideProvideServices(IRideProvide rideProvideRepository)
        {
            _rideProvideRepository = rideProvideRepository;
           
        }

        public async Task<List<RideProviderDTO>> getRider()
        {
            List<RideProvide> ans = await _rideProvideRepository.GetRider();
            List<RideProviderDTO> l = new List<RideProviderDTO>();
            foreach (RideProvide i in ans)
            {

                RideProviderDTO tbk = new RideProviderDTO()
                {
                    rpId= i.rpId,
                   adharcard=i.adharcard,
                   birthDate=i.birthDate,
                   firstName=i.firstName,
                   lastName=i.lastName,
                   dlNo=i.dlNo,
                   emailId=i.emailId,
                    age=i.age,
                    status=i.status,
                   phone=i.phone,
                   validUpto=i.validUpto
                };
                l.Add(tbk);

            }
            return l;
        }
        public async Task<List<RideProviderDTO>> getRiderById(string rpId)
        {
            List<RideProvide> ans=await _rideProvideRepository.GetRiderDetails(rpId);
            List<RideProviderDTO> l=new List<RideProviderDTO>();
            foreach(RideProvide i in ans)
            {
                RideProviderDTO rp = new RideProviderDTO()
                {
                    rpId = i.rpId,
                    adharcard = i.adharcard,
                    birthDate = i.birthDate,
                    firstName = i.firstName,
                    lastName = i.lastName,
                    dlNo = i.dlNo,
                    emailId = i.emailId,
                    age = i.age,
                    status = i.status,
                    phone = i.phone,
                    validUpto = i.validUpto
                };
                l.Add(rp);
            }
            return l;
        }
        public async Task<Output> CreateNewRideProvider(RideDTO rideProviderDTO)
        { 
                try
                {
                    

                    RideProvide actualModel = new RideProvide
                    {
                        rpId=GeneratePPId(rideProviderDTO.lastName,rideProviderDTO.BirthDate),
                        firstName=rideProviderDTO.FirstName,
                        lastName=rideProviderDTO.lastName,
                        birthDate=rideProviderDTO.BirthDate,
                        phone=rideProviderDTO.Phone,
                        emailId=rideProviderDTO.EmailId,
                        adharcard=rideProviderDTO.Adharcard,
                        dlNo=rideProviderDTO.dlNo,
                        age=CalculateAge(rideProviderDTO.BirthDate),
                        validUpto=rideProviderDTO.validUpto,
                        status="Registered"
                    };

                    var changes = await _rideProvideRepository.AddRider(actualModel);

                    return new Output()
                    {
                        Result = true,
                    };
                }
                catch (Exception ex)
                {
                    throw;
                }   
        }



        public async Task<Output> UpdateNewRideProvider(string providerId,UpdateRideProvideDTO rideProviderDTO)
        {
            try
            {

                var obj = await _rideProvideRepository.FindRideProviderById(providerId);

                obj.status=rideProviderDTO.status;

                var changes = await _rideProvideRepository.UpdateRider(obj);

                return new Output()
                {
                    Result = true,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Output> DeleteRideProvider(string providerId)
        {
            var obj = await _rideProvideRepository.FindRideProviderById(providerId);
            if (obj.status == "Un-registered" || obj.status == "Un-Registered" || obj.status == "Unregistered") {
                var changes = await _rideProvideRepository.DeleteRider(obj);
                return new Output
                {
                    Result = true,
                };
            }
            return new Output{
                Result=false,
                errorMessage="Ride provide is registered it cannot be deleted"
            };
        }
       
            
        private string GeneratePPId(string lastName, DateOnly birthDate)
        {
            string birthYear = birthDate.Year.ToString();
            return $"RP{lastName.Substring(0, 2)}{birthYear.Substring(birthYear.Length - 2)}";
        }
        

        private int CalculateAge(DateOnly birthDate)
        {
            // Calculate age based on birth date
            int currentYear = DateOnly.FromDateTime(DateTime.Today).Year;
            int birthYear = birthDate.Year;
            int age = currentYear - birthYear;
            return age;
        }
      
    }
}
