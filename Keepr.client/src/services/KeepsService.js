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



  async deleteKeep(keepId) {
    const res = await api.delete('api/keeps/' + keepId)
    AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
  }
}

export const keepsService = new KeepsService()