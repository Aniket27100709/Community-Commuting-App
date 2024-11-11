using CCA_BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA_BAL.Result;
using CCA_DAL.Models;
using CCA_DAL.Interface;
using CCA_BAL.DTO;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace CCA_BAL.Service
{
    public class BillService:IBillService
    {
        private readonly IBill _billRepository;
        private readonly ITripManage _tripManage;

        public BillService(IBill billRepository,ITripManage tripManage) { 
             _billRepository=billRepository;
            _tripManage=tripManage;
        }
        public async Task<BillDTO>RetrieveBill(int month)
        {


            var bills=await _billRepository.GetBill(month);

            int noOfKM=bills.Sum(t=>t.noOfKm);
            int totalBill = bills.Sum(t => t.totalbill);
            int noOfOccupants = bills.Sum(t => t.noOfOccupants);

            BillDTO res = new BillDTO
            {
                month = month,
                noOfKm = noOfKM,
                totalbill = totalBill,
                noOfOccupants = noOfOccupants
            };

            return res;
        }
        public async Task<List<BillDTOs>> generateBillDetails(string tripId)
        {

            List<billMaster> bills = await _billRepository.GetBillDetils(tripId);
            List<BillDTOs> res=new List<BillDTOs>();
            foreach(billMaster i in bills)
            {
                BillDTOs bt = new BillDTOs()
                {
                    rideId = i.rideId,
                    month = i.month,
                    noOfKm = i.noOfKm,
                    totalbill = i.totalbill,
                    noOfOccupants=i.noOfOccupants
                };
                res.Add(bt);
            }
            return res;
        }

    }
}
