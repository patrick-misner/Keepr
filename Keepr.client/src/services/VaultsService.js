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

  async createVault(vaultData) {
    const res = await api.post("api/vaults", vaultData)
    AppState.vaults.unshift(res.data)
  }
  async addKeepToVault(vaultData) {
    const res = await api.post("api/vaultkeeps", vaultData)
    logger.log("Add keep to vault", res.data)
  }

  async deleteVaultKeep(vaultKeepId) {
    const res = await api.delete("api/vaultkeeps/" + vaultKeepId)
    AppState.activeVaultKeeps = AppState.activeVaultKeeps.filter(k => k.vaultKeepId != vaultKeepId)
  }

}

export const vaultsService = new VaultsService()