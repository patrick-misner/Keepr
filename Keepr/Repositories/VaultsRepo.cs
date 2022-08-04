using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepo
  {
    private readonly IDbConnection _db;

    public VaultsRepo(IDbConnection db)
    {
      _db = db;
    }

    internal List<Vault> GetVaults()
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.isPrivate = false
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }).ToList();
    }

    internal List<Vault> GetVaultsAuth(string userId)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.isPrivate = false OR v.isPrivate = true AND v.creatorId = @userId
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { userId }).ToList();
    }

    internal Vault GetVault(int id)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @id
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { id }).FirstOrDefault();
    }

    internal Vault GetVaultAuth(int id)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @id
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { id }).FirstOrDefault();
    }


    internal List<Vault> GetVaultsByAccount(string id)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.creatorId = @id
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { id }).ToList();
    }

    internal Vault Create(Vault vaultData)
    {
      string sql = @"
      INSERT INTO vaults
      (name, description, img, isPrivate, creatorId)
      VALUES
      (@Name, @Description, @Img, @IsPrivate, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, vaultData);
      vaultData.Id = id;
      return vaultData;
    }

    internal List<Vault> GetVaultsByUser(string id)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.creatorId = @id AND v.isPrivate = false
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { id }).ToList();
    }

    internal void Edit(Vault original)
    {
      string sql = @"
      UPDATE vaults
      SET
      name = @Name,
      description = @Description,
      isPrivate = @IsPrivate
      WHERE id = @Id
      ";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}