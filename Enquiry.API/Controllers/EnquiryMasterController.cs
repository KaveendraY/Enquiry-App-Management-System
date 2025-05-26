using Enquiry.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enquiry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryMasterController : ControllerBase
    {
        private readonly EnquiryDbContext _context;  //injecting DbContext class into constructor

        public EnquiryMasterController(EnquiryDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllStatus")]

        public List<EnquiryStatus> GetEnquiryStatus()
        {
            var list = _context.EnquiryStatus.ToList(); //fetching all enquiry status from database
            return list;

        }

        [HttpGet("GetAllTypes")]

        public List<EnquiryType> GetAllTypes()
        {
            var list = _context.EnquiryType.ToList(); //fetching all enquiry types from database
            return list;
        }

        [HttpGet("GetAllEnquiry")]

        public List<EnquiryModel> GetAllEnquiry()
        {
            var list = _context.EnquiryModels.ToList(); //fetching all enquiry models from database
            return list;
        }

        [HttpPost("CreateNewEnquiry")]

        public EnquiryModel AddNewEnquiry(EnquiryModel obj)
        {
            obj.createdDate = DateTime.Now;
            _context.EnquiryModels.Add(obj); //adding new enquiry model to the database
            _context.SaveChanges(); //saving changes to the database
            return obj;
        }

        [HttpPut("UpdateEnquiry")]

        public EnquiryModel Update(EnquiryModel obj)
        {
            var record = _context.EnquiryModels.SingleOrDefault(n => n.enquiryId == obj.enquiryId); //fetching the enquiry model to be updated
            if (record != null)
            {
                record.resolution = obj.resolution;
                record.enquiryStatusId = obj.enquiryStatusId; //updating the enquiry status
                _context.SaveChanges(); //saving changes to the database
            }
            return obj;
        }

        [HttpDelete("DeleteEnquiryById")]
        public bool DeleteEnquiryById(int id)
        {
            var record = _context.EnquiryModels.SingleOrDefault(n=> n.enquiryId == id);
            if (record != null) 
            {
                _context.EnquiryModels.Remove(record);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
