import { AppState } from "../AppState"
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

}

export const vaultsService = new VaultsService()