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
}

export const keepsService = new KeepsService()