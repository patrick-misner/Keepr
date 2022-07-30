using Keepr.Services;
using Microsoft.AspNetCore.Mvc;
using Keepr.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CodeWorks.Auth0Provider;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _pServ;
    private readonly AccountService _aServ;
    private readonly KeepsService _kServ;
    private readonly VaultsService _vServ;

    public ProfilesController(ProfilesService pServ, AccountService aServ, KeepsService kServ, VaultsService vServ)
    {
      _pServ = pServ;
      _aServ = aServ;
      _kServ = kServ;
      _vServ = vServ;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(string id)
    {
      try
      {
        Profile profile = _aServ.GetProfile(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/keeps")]
    public async Task<ActionResult<List<Keep>>> GetKeepsByUser(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Keep> keeps = _kServ.GetKeepsByUser(id, userInfo?.Id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetVaultsByUser(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Vault> vaults = _vServ.GetVaultsByUser(id, userInfo?.Id);
        return Ok(vaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}