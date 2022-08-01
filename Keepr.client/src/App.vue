<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />

    <Modal id="active-keep">
      <template #body>
        <ActiveKeep v-if="keep.id" />
      </template>
    </Modal>
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState),
      keep: computed(() => AppState.activeKeep)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
