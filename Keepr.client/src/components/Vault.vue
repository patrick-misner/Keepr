<template>
  <div
    @click="goToVault"
    class="
      elevation-2
      rounded
      selectable
      grow
      wrapper
      text-white text-shadow
      fs-6
    "
    :style="`background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0.01), rgba(0, 0, 0, 0.85) ), url('${vault.img}'); background-size: cover; overflow: hidden;`"
  >
    <img class="img-fluid rounded card-img" :src="vault.img" :alt="vault.img" />
    <div class="text my-2 mx-2 p-1 px-2">
      <span>{{ vault.name }}</span>
    </div>
  </div>
</template>

<script>
import { Modal } from "bootstrap"
import { keepsService } from "../services/KeepsService"
import { router } from "../router"
import { AppState } from "../AppState"
export default {
  props: { vault: { type: Object, required: true } },
  setup(props) {

    return {
      async activeVault(keepId) {
        await keepsService.getKeep(keepId)
        Modal.getOrCreateInstance(document.getElementById('active-keep')).show()
      },
      goToVault() {
        router.push({
          name: "Vault",
          params: { id: props.vault.id }
        });
      },
    }
  }
}
</script>

<style scoped lang="scss">
.wrapper {
  position: relative;
  width: 100%;
}

.wrapper img {
  position: relative;
  z-index: 0;
}

.wrapper .text {
  position: absolute;
  z-index: 10;
  bottom: 0;
}

.wrapper .profile-img {
  position: absolute;
  z-index: 10;
  bottom: 0;
  right: 0;
  height: 40px;
  border-radius: 50%;
}

.grow {
  transition: all 0.1s ease-in-out;
}

.grow:hover {
  transform: scale(1.02);
}

.grow-2 {
  transition: all 0.1s ease-in-out;
}

.grow-2:hover {
  transform: scale(1.15);
}

.card-img {
  visibility: hidden;
}
</style>