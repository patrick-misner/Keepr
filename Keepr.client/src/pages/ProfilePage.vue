<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 mt-5 px-md-5">
        <div class="d-flex flex-md-row flex-column">
          <div>
            <img
              class="profile-img rounded"
              :src="profile.picture"
              :alt="profile.picture"
            />
          </div>

          <div class="mx-md-5 pt-3">
            <h3>{{ profile.name }}</h3>
            <div class="pt-3">
              <h4 v-if="account.id != profile.id">
                Vaults: {{ profileVaults.length }}
              </h4>
              <h4 v-if="account.id == profile.id">
                Vaults: {{ myVaults.length }}
              </h4>
              <h4>Keeps: {{ profileKeeps.length }}</h4>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="row mt-5">
      <div class="col-12 mt-5 ps-md-5">
        <h2>
          Vaults
          <i
            v-if="account.id == profile.id"
            class="mdi mdi-plus text-primary selectable"
            title="Add a Vault"
            @click="triggerVaultForm"
          ></i>
        </h2>
      </div>
    </div>

    <div v-if="account.id == profile.id" class="masonry-frame mt-3 ms-md-4">
      <div v-for="v in myVaults" :key="v.id" class="mb-3">
        <Vault :vault="v" />
      </div>
    </div>

    <div v-else class="masonry-frame mt-3 ms-md-4">
      <div v-for="v in profileVaults" :key="v.id" class="mb-3">
        <Vault :vault="v" />
      </div>
    </div>

    <div class="row mt-5">
      <div class="col-12 mt-5 ps-md-5">
        <h2>
          Keeps

          <i
            v-if="account.id == profile.id"
            title="Add a Keep"
            class="mdi mdi-plus text-primary selectable grow"
            @click="triggerKeepForm"
          ></i>
        </h2>
      </div>
    </div>

    <div class="masonry-frame mt-3 ms-md-4">
      <div v-for="k in profileKeeps" :key="k.id" class="mb-3">
        <Keep :keep="k" />
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
import KeepFormVue from "../components/KeepForm.vue";
import { Modal } from "bootstrap";
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
      profileVaults: computed(() => AppState.profileVaults),
      myVaults: computed(() => AppState.myVaults),
      account: computed(() => AppState.account),
      triggerKeepForm() {
        Modal.getOrCreateInstance(document.getElementById('keep-form')).show()
      },
      triggerVaultForm() {
        Modal.getOrCreateInstance(document.getElementById('vault-form')).show()
      },
    };
  },
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
@media only screen and (max-width: 768px) {
  .masonry-frame {
    columns: 2;
    div {
      break-inside: avoid;
    }
  }
}
</style>