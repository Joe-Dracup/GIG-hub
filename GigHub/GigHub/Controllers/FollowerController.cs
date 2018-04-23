using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowerController: ApiController
    {
        private ApplicationDbContext _context;

        public FollowerController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult follow(FollowDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Followers.Any(u => u.FollowerId == userId && u.FolloweeId == dto.FolloweeId);

            if (exists)
                return BadRequest("The attendance already exists.");

            var follow = new Follow
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followers.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }
}