using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepo _vkRepo;
    private readonly VaultsService _vServ;
    private readonly KeepsService _kServ;
    private readonly KeepsRepo _kRepo;

    public VaultKeepsService(VaultKeepsRepo vkRepo, VaultsService vServ, KeepsService kServ, KeepsRepo kRepo)
    {
      _vkRepo = vkRepo;
      _vServ = vServ;
      _kServ = kServ;
      _kRepo = kRepo;
    }

    internal VaultKeep Create(VaultKeep vaultKeepData)
    {
      Vault found = _vServ.GetVault(vaultKeepData.VaultId, vaultKeepData.CreatorId);
      if (found.CreatorId != vaultKeepData.CreatorId)
      {
        throw new Exception("You do not own the vault");
      }
      Keep foundKeep = _kServ.GetKeep(vaultKeepData.KeepId);
      VaultKeep foundVaultKeep = _vkRepo.GetVaultKeepByIds(vaultKeepData);
      if (foundVaultKeep?.VaultId == vaultKeepData.VaultId && foundVaultKeep?.VaultId == vaultKeepData.VaultId)
      {
        throw new Exception("Keep already exists in vault");
      }
      if (foundKeep != null)
      {
        foundKeep.Kept += 1;
        _kRepo.Edit(foundKeep);
      }
      return _vkRepo.Create(vaultKeepData);
    }

    internal List<VaultKeepViewModel> GetVaultKeeps(int id, string userId)
    {
      Vault found = _vServ.GetVault(id, userId);
      if (found == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      return _vkRepo.GetVaultKeeps(id);
    }

    internal VaultKeep GetVaultKeep(int id)
    {
      VaultKeep found = _vkRepo.GetVaultKeep(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal List<VaultKeep> GetVaultKeepsByKeepId(int id, string userId)
    {
      return _vkRepo.GetVaultKeepsByKeepId(id, userId);
    }

    internal VaultKeep Delete(int id, string userId)
    {
      VaultKeep original = GetVaultKeep(id);
      Vault found = _vServ.GetVault(original.VaultId, userId);
      if (userId != original.CreatorId)
      {
        throw new Exception("Delete failed. You are not the creator!");
      }
      if (found.CreatorId != userId)
      {
        throw new Exception("Delete failed. You do not own the vault");
      }
      Keep foundKeep = _kServ.GetKeep(original.KeepId);
      foundKeep.Kept -= 1;
      _kRepo.Edit(foundKeep);
      _vkRepo.Delete(id);
      return original;
    }
  }
}