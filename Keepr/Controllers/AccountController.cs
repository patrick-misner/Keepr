using System;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly VaultsService _vServ;

    private readonly VaultKeepsService _vkServ;

    public AccountController(AccountService accountService, VaultsService vServ, VaultKeepsService vkServ)
    {
      _accountService = accountService;
      _vServ = vServ;
      _vkServ = vkServ;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("vaults")]
    [Authorize]
    public async Task<ActionResult<List<Vault>>> GetVaultsByAccount()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Vault> vaults = _vServ.GetVaultsByAccount(userInfo.Id);
        return Ok(vaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("vaultkeeps")]
    [Authorize]
    public async Task<ActionResult<List<VaultKeep>>> GetVaultKeeps(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<VaultKeep> vaultkeeps = _vkServ.GetVaultKeepsByKeepId(userInfo?.Id);
        return Ok(vaultkeeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}