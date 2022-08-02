<template>
  <div class="container-fluid">
    <i></i>
    <div class="row">
      <div class="col-md-6 ps-0">
        <img class="left-side rounded-start" :src="keep.img" :alt="keep.img" />
      </div>

      <div class="col-md-6 pt-5">
        <div
          class="d-flex flex-column justify-content-between h-100 right-side"
        >
          <div>
            <div class="d-flex flex-column justify-content-between">
              <div class="">
                <div
                  class="d-flex justify-content-center align-items-center fs-4"
                >
                  <i class="mdi mdi-eye px-2 text-primary"></i>
                  <span class="fs-6">{{ keep.views }}</span>
                  <i class="mdi mdi-safe-square-outline px-2 text-primary"></i>
                  <span class="fs-6">{{ keep.kept }}</span>
                </div>

                <div class="d-flex justify-content-center fs-1 py-5">
                  {{ keep.name }}
                </div>

                <div
                  class="
                    d-flex
                    justify-content-center
                    border-bottom border-2 border-dark
                    px-3
                  "
                >
                  <p class="pb-5">
                    {{ keep.description }} Lorem ipsum dolor sit amet,
                    consectetur adipisicing elit. Perspiciatis corrupti modi
                    impedit libero totam, at porro fugit debitis vitae nihil
                    provident atque tempore! Debitis, labore.
                  </p>
                </div>

                <div class="d-flex justify-content-center pt-4">
                  <div class="border border-1 border-dark rounded p-1 m-2">
                    <span class="">tag 1</span>
                  </div>
                  <div class="border border-1 border-dark rounded p-1 m-2">
                    <span class="">tag 2</span>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div
            class="d-flex justify-content-between pb-3 px-0 align-items-center"
          >
            <div>
              <form>
                <select
                  v-if="!keep.vaultKeepId"
                  v-model="addToVault.vaultId"
                  @change="addKeepToVault"
                  class="form-select"
                  aria-label="Select Vault"
                >
                  <option selected>Add to Vault</option>
                  <option v-for="v in vaults" :key="v.id" :value="v.id">
                    {{ v.name }}
                  </option>
                </select>
              </form>
              <button
                v-if="keep.vaultKeepId"
                type="button"
                @click="deleteVaultKeep"
                class="btn btn-danger"
              >
                Remove from Vault
              </button>
            </div>

            <div class="align-items-center">
              <i
                @click="deleteKeep(keep.id)"
                v-if="keep.creatorId == account.id && !keep.vaultKeepId"
                class="mdi mdi-trash-can fs-3 text-danger selectable"
              ></i>
            </div>

            <div>
              <img
                class="rounded profile-img pe-2"
                :src="keep.creator.picture"
                :alt="keep.creator.picture"
              />
              <span>{{ keep.creator.name }}</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, ref } from "@vue/reactivity"
import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { keepsService } from "../services/KeepsService"
import { Modal } from "bootstrap"
import { vaultsService } from "../services/VaultsService"
export default {
  setup() {
    const addToVault = ref({
      vaultId: "Add to Vault",
    });
    return {
      addToVault,
      keep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.myVaults),
      account: computed(() => AppState.account),
      async deleteKeep(keepId) {
        try {
          if (await Pop.confirm('Are you sure you want to delete this keep ' + this.keep.name + '?')) {
            await keepsService.deleteKeep(keepId)
            Modal.getOrCreateInstance(document.getElementById("active-keep")).hide()
            Pop.toast("Keep deleted", 'success')

          }
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteVaultKeep(keepId) {
        try {
          if (await Pop.confirm('Are you sure you want to remove this keep, ' + this.keep.name + 'from this vault?')) {
            await vaultsService.deleteVaultKeep(this.keep.vaultKeepId)
            Modal.getOrCreateInstance(document.getElementById("active-keep")).hide()
            Pop.toast("Keep removed from vault", 'success')
            this.keep.kept--
          }
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async addKeepToVault() {
        try {
          addToVault.value.keepId = this.keep.id
          let vault = this.vaults.find(v => v.id == addToVault.value.vaultId)
          await vaultsService.addKeepToVault(addToVault.value)
          Pop.toast("Added keep, " + this.keep.name + " to Vault " + vault.name, 'success')
          addToVault.value.vaultId = "Add to Vault"
          this.keep.kept++
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>

<style>
.left-side {
  height: 600px;
  min-height: 600px;
  width: 100%;
  object-fit: cover;
}

.profile-img {
  height: 30px;
}
</style>