using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepo
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepo(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Create(VaultKeep vaultKeepData)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (vaultId, keepId, creatorId)
      VALUES
      (@VaultId, @KeepId, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
      vaultKeepData.Id = id;
      return vaultKeepData;
    }

    internal List<VaultKeepViewModel> GetVaultKeeps(int id)
    {
      string sql = @"
      SELECT
      a.*,
      k.*,
      v.id AS vaultKeepId
      FROM vaultkeeps v
      JOIN keeps k ON k.id = v.keepId
      JOIN accounts a ON a.id = k.creatorId
      WHERE v.vaultId = @id
      ";
      return _db.Query<Account, VaultKeepViewModel, VaultKeepViewModel>(sql, (prof, keep) =>
      {
        keep.Creator = prof;
        return keep;
      }, new { id }).ToList();
    }

    internal VaultKeep GetVaultKeep(int id)
    {
      string sql = @"
      SELECT *
      FROM vaultkeeps
      WHERE id = @id
      ";
      return _db.Query<VaultKeep>(sql, new { id }).FirstOrDefault();
    }

    internal VaultKeep GetVaultKeepByIds(VaultKeep vaultKeepData)
    {
      string sql = @"
      SELECT *
      FROM vaultkeeps
      WHERE vaultId = @VaultId AND keepId = @KeepId
      ";
      return _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }


    // !!NOTE Is this possible?
    // internal List<VaultKeep> GetVaultKeepsByKeepId(int id, string userId)
    // {
    //   string sql = @"
    //   SELECT *
    //   FROM vaultkeeps
    //   WHERE keepId = @id AND creatorId = @userId
    //   ";
    //   return _db.Query<VaultKeep, Account, VaultKeep>(sql, (vaultkeep, account) =>
    //   {
    //     return vaultkeep;
    //   }, new { id }).ToList();
    // }

    internal List<VaultKeep> GetVaultKeepsByKeepId(int id, string userId)
    {
      string sql = @"
      SELECT *
      FROM vaultkeeps
      WHERE keepId = @id AND creatorId = @userId
      ";
      return _db.Query<VaultKeep, Account, VaultKeep>(sql, (vaultkeep, account) =>
      {
        return vaultkeep;
      }, new { id }).ToList();
    }
  }
}