<template>
  <div class="container-fluid">
    <div class="row mt-5">
      <div class="col-12 ps-md-5">
        <div class="d-flex justify-content-between">
          <div>
            <h1>{{ activeVault.name }}</h1>
            <h4 class="pt-2 ps-1">Keeps: {{ keeps.length }}</h4>
          </div>
          <div class="me-md-5 pe-md-5">
            <button
              v-if="account.id == activeVault.creatorId"
              type="button"
              class="btn btn-danger"
            >
              Delete Vault
            </button>
          </div>
        </div>
      </div>
    </div>

    <div class="masonry-frame mt-3 ms-md-5">
      <div v-for="k in keeps" :key="k.id" class="mb-4">
        <VaultKeep :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity"
import { onMounted } from "@vue/runtime-core"
import { useRoute } from "vue-router"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { vaultsService } from "../services/VaultsService"
import { keepsService } from "../services/KeepsService"
import { AppState } from "../AppState"
import VaultKeep from "../components/VaultKeep.vue"
import { router } from "../router"
export default {
  setup() {
    const route = useRoute();
    onMounted(async () => {
      try {
        await vaultsService.getVault(route.params.id);
        await keepsService.getVaultKeeps(route.params.id);
      }
      catch (error) {
        logger.error(error);
        Pop.toast(error.message, "error");
        router.push({
          name: "Home"
        });

      }
    });
    return {
      activeVault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.activeVaultKeeps),
      account: computed(() => AppState.account)
    };
  },
  components: { VaultKeep }
}
</script>

<style scoped lang="scss">
.masonry-frame {
  columns: 4;
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