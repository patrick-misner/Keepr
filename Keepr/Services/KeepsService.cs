using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepo _kRepo;

    public KeepsService(KeepsRepo kRepo)
    {
      _kRepo = kRepo;
    }

    internal List<Keep> GetKeeps()
    {
      return _kRepo.GetKeeps();
    }

    internal Keep GetKeep(int id)
    {
      Keep found = _kRepo.GetKeep(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Keep Create(Keep keepData)
    {
      return _kRepo.Create(keepData);
    }

    internal Keep Edit(Keep keepData)
    {
      Keep original = GetKeep(keepData.Id);
      if (keepData.CreatorId != original.CreatorId)
      {
        throw new Exception("Edit failed. You are not the creator");
      }
      original.Name = keepData.Name ?? original.Name;
      original.Description = keepData.Description ?? original.Name;
      original.Img = keepData.Img ?? original.Img;
      original.Views = keepData.Views ?? original.Views;
      original.Kept = keepData.Kept ?? original.Kept;
      _kRepo.Edit(original);
      return original;

    }

    internal Keep Delete(int id, string userId)
    {
      Keep original = GetKeep(id);
      if (userId != original.CreatorId)
      {
        throw new Exception("Delete failed. You are not the creator");
      }
      _kRepo.Delete(id);
      return original;
    }
  }
}