import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultsService {

  async getVault(vaultId) {
    const res = await api.get("api/vaults/" + vaultId)
    AppState.activeVault = res.data
  }


  async getMyVaults() {
    const res = await api.get("account/vaults")
    AppState.myVaults = res.data
  }

  async getMyVaultKeeps() {
    const res = await api.get("account/vaultkeeps")
    AppState.myVaultKeeps = res.data
  }

  async createVault(vaultData) {
    const res = await api.post("api/vaults", vaultData)
    AppState.myVaults.push(res.data)
  }
  async addKeepToVault(vaultData) {
    const res = await api.post("api/vaultkeeps", vaultData)

    let vault = AppState.myVaults.find(v => v.id == vaultData.vaultId)
    vault.isKept = true
    logger.log("Add keep to vault", res.data)
  }

  async deleteVaultKeep(vaultKeepId) {
    const res = await api.delete("api/vaultkeeps/" + vaultKeepId)
    AppState.activeVaultKeeps = AppState.activeVaultKeeps.filter(k => k.vaultKeepId != vaultKeepId)
  }

  async deleteVault(vaultId) {
    const res = await api.delete('api/vaults/' + vaultId)
    AppState.myVaults = AppState.myVaults.filter(v => v.id != vaultId)
  }
}

export const vaultsService = new VaultsService()