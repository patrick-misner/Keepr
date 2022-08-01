<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 mt-5 px-5">
        <div class="d-flex">
          <div>
            <img
              class="profile-img rounded"
              :src="profile.picture"
              :alt="profile.picture"
            />
          </div>

          <div class="mx-5 pt-3">
            <h3>{{ profile.name }}</h3>
            <div class="pt-3">
              <h4>Vaults: {{ profileVaults.length }}</h4>
              <h4>Keeps: {{ profileKeeps.length }}</h4>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="row mt-5">
      <div class="col-12 mt-5 ps-5">
        <h2>Vaults <i class="mdi mdi-plus text-primary selectable"></i></h2>
      </div>
    </div>

    <div class="masonry-frame mt-3 ms-4">
      <div v-for="v in profileVaults" :key="v.id" class="mb-4">
        <Vault :vault="v" />
      </div>
    </div>

    <div class="row mt-5">
      <div class="col-12 mt-5 ps-5">
        <h2>Keeps <i class="mdi mdi-plus text-primary selectable"></i></h2>
      </div>
    </div>

    <div class="masonry-frame mt-3 ms-4">
      <div v-for="k in profileKeeps" :key="k.id" class="mb-4">
        <ProfileKeep :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core";
import { useRoute } from "vue-router"
import Pop from "../utils/Pop";
import { logger } from "../utils/Logger";
import { AppState } from "../AppState";
import { profilesService } from "../services/ProfilesService"
import Vault from "../components/Vault.vue"
import ProfileKeep from "../components/ProfileKeep.vue"
export default {
  setup() {
    const route = useRoute();
    onMounted(async () => {
      try {
        await profilesService.getProfile(route.params.id);
        await profilesService.getProfileVaults(route.params.id);
        await profilesService.getProfileKeeps(route.params.id);
      }
      catch (error) {
        logger.error(error);
        Pop.toast(error.message, "error");
      }
    });
    return {
      profile: computed(() => AppState.profile),
      profileKeeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults)
    };
  },
  components: { Vault, ProfileKeep }
}
</script>

<style scoped lang="scss">
.profile-img {
  height: 200px;
  width: 200px;
  object-fit: cover;
}
.masonry-frame {
  columns: 6;
  div {
    break-inside: avoid;
  }
}
</style>