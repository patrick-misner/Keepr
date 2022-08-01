import { AppState } from "../AppState"
import { api } from "./AxiosService"

class ProfilesService {

  async getProfile(profileId) {
    const res = await api.get("api/profiles/" + profileId)
    AppState.profile = res.data
  }

  async getProfileVaults(profileId) {
    const res = await api.get("api/profiles/" + profileId + "/vaults")
    AppState.profileVaults = res.data
  }

  async getProfileKeeps(profileId) {
    const res = await api.get("api/profiles/" + profileId + "/keeps")
    AppState.profileKeeps = res.data
  }
}

export const profilesService = new ProfilesService()