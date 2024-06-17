using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneSistemiApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberReadRepository _memberReadRepository;
        private readonly IMemberWriteRepository _memberWriteRepository;
        public MemberController(IMemberReadRepository memberReadRepository, IMemberWriteRepository memberWriteRepository)
        {
            _memberReadRepository = memberReadRepository;
            _memberWriteRepository = memberWriteRepository;
        }
        [HttpGet("Memberlist")]
        public IActionResult MemberList()
        {
            List<string> memberNames = new List<string>();
            var AllMembers = _memberReadRepository.GetAll();
            foreach (var member in AllMembers)
            {
                memberNames.Add(member.Name);
            }
            return Ok(memberNames);
        }
        [HttpGet("Createmembers")]
        public async Task<IActionResult> addmembers()
        {
            await _memberWriteRepository.AddRangeAsync(new()
            {
                new() {Name="Murat",Password="hashedpass",CreatedDate=DateTime.UtcNow,ExpireDate=DateTime.UtcNow.AddMonths(3),Id=Guid.NewGuid(),MembershipType = Domain.Enums.MembershipTypes.Premium},
                new() {Name="Mehmet",Password="hashedpass",CreatedDate=DateTime.UtcNow,ExpireDate=DateTime.UtcNow.AddMonths(6),Id=Guid.NewGuid(),MembershipType = Domain.Enums.MembershipTypes.Premium},
                new() {Name="Ahmet",Password="hashedpass",Id=Guid.NewGuid(),MembershipType = Domain.Enums.MembershipTypes.Free}
            });
            _memberWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
