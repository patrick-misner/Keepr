using System;
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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vkServ;

    public VaultKeepsController(VaultKeepsService vkServ)
    {
      _vkServ = vkServ;
    }

    // [HttpGet]
    // public ActionResult<List<VaultKeep>> GetVaultKeeps()
    // {
    //   try
    //   {
    //     List<VaultKeep> vaultKeeps = _vkServ.GetVaultKeeps();
    //     return Ok(vaultKeeps);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultKeepData.CreatorId = userInfo?.Id;
        VaultKeep newVaultKeep = _vkServ.Create(vaultKeepData);
        return Ok(newVaultKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        VaultKeep deletedVaultKeep = _vkServ.Delete(id, userInfo?.Id);
        return Ok(deletedVaultKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}