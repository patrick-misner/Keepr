<template>
  <div
    @click="activeKeep(keep.id)"
    class="
      elevation-2
      rounded
      selectable
      grow
      wrapper
      text-white text-shadow
      gradient
      fs-3
    "
    :style="`background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0.01), rgba(0, 0, 0, 0.85) ), url('${keep.img}'); background-size: cover; overflow: hidden;`"
  >
    <img class="rounded img-fluid card-img" :src="keep.img" :alt="keep.img" />

    <div class="text my-3 mx-2 p-1 px-2">
      <span>{{ keep.name }}</span>
    </div>
    <img
      v-if="$route.name !== 'Profile'"
      @click.stop="goToProfile"
      class="profile-img mb-3 mx-2 elevation-2 selectable grow-2"
      :src="keep.creator.picture"
      alt=""
    />
  </div>
</template>

<script>
import { Modal } from "bootstrap"
import { keepsService } from "../services/KeepsService"
import { router } from "../router"
import { AppState } from "../AppState"
export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {

    return {
      async activeKeep(keepId) {
        await keepsService.getKeep(keepId)
        Modal.getOrCreateInstance(document.getElementById('active-keep')).show()
      },
      goToProfile() {
        router.push({
          name: "Profile",
          params: { id: props.keep.creatorId }
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