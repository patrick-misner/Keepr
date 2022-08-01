<template>
  <div
    @click="activeKeep(keep.id)"
    class="
      elevation-2
      rounded
      selectable
      grow
      card-img
      wrapper
      text-white text-shadow
      fs-3
    "
  >
    <img class="img-fluid rounded" :src="keep.img" :alt="keep.img" />
    <div class="text my-3 mx-2 p-1 px-2 bg-grey elevation-2 rounded">
      <span>{{ keep.name }}</span>
    </div>
    <img
      class="profile-img mb-3 mx-2 elevation-2 selectable grow-2"
      :src="keep.creator.picture"
      alt=""
    />
  </div>
</template>

<script>
import { Modal } from "bootstrap"
import { keepsService } from "../services/KeepsService"
export default {
  props: { keep: { type: Object, required: true } },
  setup() {

    return {
      async activeKeep(keepId) {
        await keepsService.getKeep(keepId)
        Modal.getOrCreateInstance(document.getElementById('active-keep')).show()
      }
    }
  }
}
</script>

<style>
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
</style>