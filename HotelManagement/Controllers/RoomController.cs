#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;
using HotelManagement.Model;

namespace HotelManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;


        public RoomController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            return new JsonResult(_db.Rooms.ToList<Room>());
        }

        [HttpPost]
        public JsonResult Create(Room room)
        {

            _db.Rooms.Add(room);
            _db.SaveChanges();

            return new JsonResult(room);
        }

        [HttpPut]
        public JsonResult Update(Room room)
        {
            var r = _db.Rooms.Find(room.RoomId);
            //charr.Summary = character.Summary;
            //charr.Race = character.Race;
            //charr.Name = character.Name;

            r.isVip = room.isVip;
            r.Capacity = room.Capacity;
            r.PricePerDay = room.PricePerDay;
            

            //_db.SaveChanges();

            return new JsonResult("Update Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var r = _db.Rooms.Find(id);
            _db.Rooms.Remove(r);
            _db.SaveChanges();
            string returnString = "Character with " + id + " deleted ";
            return new JsonResult(returnString);
        }


        
    }
}
