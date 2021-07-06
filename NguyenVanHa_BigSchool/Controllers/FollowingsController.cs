using Microsoft.AspNet.Identity;
using NguyenVanHa_BigSchool.DTOs;
using NguyenVanHa_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenVanHa_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };



            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            /////----------------------------------------------------------
            //            following = _dbContext.Followings
            //                .Where(x => x.FolloweeId == followingDto.FolloweeId && x.FollowerId == userId)
            //                .Include(x => x.Followee)
            //                .Include(x => x.Follower).SingleOrDefault();

            //            var followingNotification = new FollowingNotification()
            //            {
            //                Id = 0,
            //                Logger = following.Follower.Name + " following " + following.Followee.Name
            //            };
            //            _dbContext.FollowingNotifications.Add(followingNotification);
            //            _dbContext.SaveChanges();


            return Ok();
        }

    }
}
