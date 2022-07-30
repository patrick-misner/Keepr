using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepo _repo;

    public VaultsService(VaultsRepo repo)
    {
      _repo = repo;
    }

    internal List<Vault> GetVaults()
    {
      return _repo.GetVaults();
    }

    internal Vault GetVault(int id)
    {
      Vault found = _repo.GetVault(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Vault Create(Vault vaultData)
    {
      return _repo.Create(vaultData);
    }

    internal Vault Edit(Vault vaultData)
    {
      Vault original = GetVault(vaultData.Id);
      if (vaultData.CreatorId != original.CreatorId)
      {
        throw new Exception("Edit failed. You are not the creator!");
      }
      original.Name = vaultData.Name ?? original.Name;
      original.Description = vaultData.Description ?? original.Description;
      original.IsPrivate = vaultData.IsPrivate ?? original.IsPrivate;
      _repo.Edit(original);
      return original;

    }

    internal Vault Delete(int id, string userId)
    {
      Vault original = GetVault(id);
      if (userId != original.CreatorId)
      {
        throw new Exception("Delete failed. You are not the creator");
      }
      _repo.Delete(id);
      return original;
    }

  }
}