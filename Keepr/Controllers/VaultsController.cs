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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vaultServ;
    private readonly VaultKeepsService _vkServ;
    private readonly KeepsService _kServ;

    public VaultsController(VaultsService vaultServ, VaultKeepsService vkServ, KeepsService kServ)
    {
      _vaultServ = vaultServ;
      _vkServ = vkServ;
      _kServ = kServ;
    }

    [HttpGet]
    public ActionResult<List<Vault>> GetVaults()
    {
      try
      {
        // Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Vault> vaults = _vaultServ.GetVaults();
        return Ok(vaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> GetVault(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Vault vault = _vaultServ.GetVault(id, userInfo?.Id);
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultData.CreatorId = userInfo?.Id;
        Vault newVault = _vaultServ.Create(vaultData);
        newVault.Creator = userInfo;
        return Ok(newVault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultData.Id = id;
        vaultData.CreatorId = userInfo?.Id;
        Vault update = _vaultServ.Edit(vaultData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Vault deletedVault = _vaultServ.Delete(id, userInfo?.Id);
        return Ok(deletedVault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/keeps")]
    public async Task<ActionResult<List<VaultKeep>>> GetVaultKeeps(int id)
    {
      try
      {

        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<VaultKeepViewModel> keeps = _vkServ.GetVaultKeeps(id, userInfo?.Id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}