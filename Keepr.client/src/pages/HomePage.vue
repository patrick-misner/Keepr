<template>
  <div class="container">
    <div class="masonry-frame mt-5">
      <div v-for="k in keeps" :key="k.id" class="mb-4">
        <Keep :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import Pop from "../utils/Pop";
import { logger } from "../utils/Logger";
import { AppState } from "../AppState";
import { keepsService } from "../services/KeepsService"
import { router } from "../router";
export default {
  name: 'Home',
  setup() {
    onMounted(async () => {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }

    });
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
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

.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
