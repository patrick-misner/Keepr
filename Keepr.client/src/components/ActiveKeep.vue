<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-6">
        <img class="img-fluid" :src="keep.img" alt="" />
      </div>

      <div class="col-md-6">
        {{ keep.name }}
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  setup() {
    return {
      keep: computed(() => AppState.activeKeep)
    }
  }
}
</script>

<style>
</style>