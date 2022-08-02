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

    <Modal id="keep-form">
      <template #body>
        <KeepForm />
      </template>
    </Modal>

    <Modal id="vault-form">
      <template #body>
        <VaultForm />
      </template>
    </Modal>
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import KeepForm from "./components/KeepForm.vue";
import VaultForm from "./components/VaultForm.vue";
export default {
  name: "App",
  setup() {
    return {
      appState: computed(() => AppState),
      keep: computed(() => AppState.activeKeep),
    };
  },
  components: { KeepForm, VaultForm }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
