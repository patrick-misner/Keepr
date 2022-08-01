<template>
  <header>
    <Navbar />
  </header>
  <main>
    <div class="container">
      <router-view />
    </div>
    <Modal id="active-keep">
      <template #body>
        <ActiveKeep />
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
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
