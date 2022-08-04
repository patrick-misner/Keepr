using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _kServ;
    private readonly VaultsService _vServ;

    public KeepsController(KeepsService kServ, VaultsService vServ)
    {
      _kServ = kServ;
      _vServ = vServ;
    }

    [HttpGet]
    public ActionResult<List<Keep>> GetKeeps()
    {
      try
      {
        List<Keep> keeps = _kServ.GetKeeps();
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> GetKeep(int id)
    {
      try
      {
        Keep keep = _kServ.GetKeep(id);
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        keepData.CreatorId = userInfo?.Id;
        Keep newKeep = _kServ.Create(keepData);
        newKeep.Creator = userInfo;
        return Ok(newKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> Edit(int id, [FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        keepData.Id = id;
        keepData.CreatorId = userInfo?.Id;
        Keep update = _kServ.Edit(keepData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Keep deletedKeep = _kServ.Delete(id, userInfo?.Id);
        return Ok(deletedKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}