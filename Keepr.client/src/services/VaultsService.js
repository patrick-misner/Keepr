import { AppState } from "../AppState"
import { api } from "./AxiosService"

class VaultsService {

  async getMyVaults() {
    const res = await api.get("account/vaults")
    AppState.myVaults = res.data
  }

}

export const vaultsService = new VaultsService()