import { AppState } from "../AppState"
import { api } from "./AxiosService"


class KeepsService {


  async getKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async getKeep(keepId) {
    const res = await api.get('api/keeps/' + keepId)
    AppState.activeKeep = res.data
  }

  async createKeep(keepData) {
    const res = await api.post("api/keeps", keepData)
    AppState.keeps.unshift(res.data)
  }

  async getVaultKeeps(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    AppState.activeVaultKeeps = res.data
  }

  async getVaultKeepsByActive(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    AppState.activeVaultKeeps = res.data
  }


  async deleteKeep(keepId) {
    const res = await api.delete('api/keeps/' + keepId)
    AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
  }
}

export const keepsService = new KeepsService()