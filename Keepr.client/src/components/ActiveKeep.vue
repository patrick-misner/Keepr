<template>
  <div class="container-fluid">
    <div class="position-absolute bottom-0 start-0 p-2"></div>
    <div class="position-absolute top-0 end-0 p-2 d-flex flex-row">
      <div
        class="dropdown"
        v-if="keep.creatorId == account.id && !keep.vaultKeepId"
      >
        <a
          class="btn"
          href="#"
          role="button"
          id="dropdownMenuLink"
          data-bs-toggle="dropdown"
          aria-expanded="false"
        >
          <i class="mdi mdi-dots-horizontal ellipses"></i>
        </a>

        <ul
          class="dropdown-menu dropdown-menu-end"
          aria-labelledby="dropdownMenuLink"
        >
          <li>
            <a
              @click="deleteKeep(keep.id)"
              class="dropdown-item text-danger d-flex justify-content-between"
              href="#"
              >Delete<i class="mdi mdi-trash-can"> </i
            ></a>
          </li>
        </ul>
      </div>

      <button
        @click="modalClose"
        type="button"
        class="btn-close btn btn-light bg-light mx-2"
        data-bs-dismiss="modal"
        aria-label="Close"
      ></button>
    </div>

    <div class="row">
      <div class="col-lg-6 px-0">
        <img class="left-side modal-round" :src="keep.img" :alt="keep.img" />
      </div>

      <div class="col-lg-6 pt-2 pt-lg-5">
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

                <div class="d-flex justify-content-center fs-1 py-2 py-lg-5">
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
                  <p class="pb-2 pb-lg-5">
                    {{ keep.description }}
                  </p>
                </div>

                <div
                  v-if="keep.tags"
                  class="d-flex justify-content-center pt-4"
                >
                  <div class="border border-1 border-dark rounded p-1 m-2">
                    <span class="">{{ t }}</span>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div
            class="
              d-flex
              justify-content-between
              flex-column flex-xl-row
              pb-3
              px-0
              align-items-center
            "
          >
            <div class="py-4 py-xl-0">
              <div class="d-flex">
                <select
                  v-if="!keep.vaultKeepId && account.id"
                  v-model="addToVault.vaultId"
                  @change="addKeepToVault"
                  class="form-select"
                  aria-label="Select Vault"
                >
                  <option selected>Add to Vault</option>
                  <option
                    v-for="v in vaults"
                    :key="v.id"
                    :value="v.id"
                    :disabled="v.isKept == true"
                  >
                    {{ v.name }} {{ v.isKept ? " (Already added)" : "" }}
                  </option>
                </select>
              </div>
              <button
                v-if="keep.vaultKeepId && account.id == vault.creatorId"
                type="button"
                @click="deleteVaultKeep"
                class="btn btn-danger"
              >
                Remove from Vault
              </button>
            </div>

            <div @click="goToProfile" class="selectable">
              <img
                class="profile-img"
                :src="keep.creator.picture"
                :alt="keep.creator.picture"
              />
              <span class="ps-1">{{ keep.creator.name }}</span>
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
import { router } from "../router"
import { watchEffect } from "@vue/runtime-core"
export default {
  setup() {
    const addToVault = ref({
      vaultId: "Add to Vault",
    });
    function filterVaultKeeps() {
      logger.log('filter vaultkeeps ran')
      AppState.myVaults = AppState.myVaults.map(v => {
        return {
          ...v,
          isKept: false
        }
      })
      // logger.log('I deleted ISKEPT!!!', AppState.myVaults.filter(mv => mv.isKept == true).length)

      let myKeptVaults = AppState.myVaults
      let myVaultKeeps = AppState.myVaultKeeps.filter(vk => vk.keepId === AppState.activeKeep.id)

      myVaultKeeps.forEach(vk => {
        let vault = myKeptVaults.find(v => v.id == vk.vaultId)
        if (vault) {
          vault.isKept = true
        }
      })

    }
    watchEffect(() => {
      filterVaultKeeps();
    })
    return {
      addToVault,
      keep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.myVaults),
      account: computed(() => AppState.account),
      vault: computed(() => AppState.activeVault),
      myVaultKeeps: computed(() => AppState.myVaultKeeps),
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
          if (await Pop.confirm('Are you sure you want to remove ' + this.keep.name + ' from this Vault?', 'You wont be able to revert this!', '', 'Yes, remove it!')) {
            await vaultsService.deleteVaultKeep(this.keep.vaultKeepId)
            Modal.getOrCreateInstance(document.getElementById("active-keep")).hide()
            Pop.toast("Keep removed from vault", 'success')
            this.keep.kept--
            await vaultsService.getMyVaultKeeps();
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
          addToVault.value.vaultId = "Add to Vault"
          await vaultsService.getMyVaults()
          await vaultsService.getMyVaultKeeps();
          Pop.toast("Added keep, " + this.keep.name + " to Vault " + vault.name, 'success')
          this.keep.kept++
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      modalClose() {
        addToVault.value = {
          vaultId: "Add to Vault"
        }
        AppState.activeKeep = {}
      },
      isKept() {

      },
      goToProfile() {
        router.push({
          name: "Profile",
          params: { id: this.keep.creatorId }
        });
        Modal.getOrCreateInstance(document.getElementById("active-keep")).hide()
      },
    }
  }
}
</script>

<style scoped lang="scss">
.left-side {
  height: 600px;
  min-height: 600px;
  width: 100%;
  object-fit: cover;
}

.modal-round {
  border-radius: 5px 0px 0px 5px;
}

@media only screen and (max-width: 992px) {
  .left-side {
    height: 350px;
    min-height: 350px;
    width: 100%;
    object-fit: cover;
    padding: 0px;
  }
  .modal-round {
    border-radius: 5px 5px 0px 0px;
  }
  .ellipses {
    color: white;
  }
}
.profile-img {
  height: 30px;
  border-radius: 5px 5px 5px 5px;
}
.btn {
  box-shadow: none !important;
}
.btn:focus {
  outline: none;
  border: none;
  box-shadow: none;
}
</style>