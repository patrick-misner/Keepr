<template>
  <div class="container-fluid">
    <button
      @click="modalClose"
      type="button"
      class="btn-close btn btn-light bg-light position-absolute top-0 end-0 p-3"
      data-bs-dismiss="modal"
      aria-label="Close"
    ></button>

    <div class="row justify-content-center">
      <form @submit.prevent="addVault">
        <div class="col-md-6 offset-md-3 p-5">
          <div class="text-center border-bottom border-3 mb-5">
            <h3>Add a Vault</h3>
          </div>
          <div class="form-floating mb-3">
            <input
              type="text"
              class="form-control"
              id="floatingInput4"
              placeholder="Keep name..."
              v-model="editable.name"
              required
            />
            <label for="floatingInput4">Vault Name</label>
          </div>

          <div class="form-floating mb-3">
            <input
              type="text"
              class="form-control"
              id="floatingInput5"
              placeholder="Img url..."
              v-model="editable.img"
              required
            />
            <label for="floatingInput5">Img Url</label>
          </div>
          <div class="form-floating">
            <textarea
              class="form-control"
              placeholder="Keep description..."
              id="floatingTextarea2"
              v-model="editable.description"
              required
            ></textarea>
            <label for="floatingTextarea2">Description</label>
          </div>

          <div class="d-flex justify-content-center pt-3">
            <div class="form-check form-switch">
              <input
                class="form-check-input"
                type="checkbox"
                role="switch"
                id="flexSwitchCheckDefault"
                v-model="editable.isPrivate"
              />
              <label class="form-check-label" for="flexSwitchCheckDefault"
                ><span v-if="editable.isPrivate == false">Public Vault</span
                ><span v-else>Private Vault</span></label
              >
            </div>
          </div>

          <div class="text-center pt-3">
            <button
              @click="modalClose"
              type="button"
              class="btn btn-danger mx-2"
              data-bs-dismiss="modal"
            >
              Cancel
            </button>
            <button type="submit" class="btn btn-primary mx-2">Submit</button>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { ref } from "@vue/reactivity"
import { logger } from "../utils/Logger"
import { keepsService } from "../services/KeepsService"
import Pop from "../utils/Pop"
import { Modal } from "bootstrap"
import { vaultsService } from "../services/VaultsService"
export default {
  setup() {
    const editable = ref({
      isPrivate: false
    })
    return {
      editable,
      modalClose() {
        editable.value = {}
      },
      async addVault() {
        try {
          vaultsService.createVault(editable.value)
          Modal.getOrCreateInstance(document.getElementById("vault-form")).hide();
          editable.value = {
            isPrivate: false
          }
          Pop.toast('Vault added!', 'success')
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
</style>