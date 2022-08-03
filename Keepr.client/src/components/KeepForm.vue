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
      <form @submit.prevent="addKeep">
        <div class="col-md-6 offset-md-3 p-5">
          <div class="text-center border-bottom border-3 mb-5">
            <h3>Add a Keep</h3>
          </div>
          <div class="form-floating mb-3">
            <input
              type="text"
              class="form-control"
              id="floatingInput1"
              placeholder="Keep name..."
              v-model="editable.name"
              maxlength="20"
              required
            />
            <label for="floatingInput1">Keep Name</label>
          </div>

          <div class="form-floating mb-3">
            <input
              type="text"
              class="form-control"
              id="floatingInput2"
              placeholder="Img url..."
              v-model="editable.img"
              required
            />
            <label for="floatingInput2">Img Url</label>
          </div>
          <div class="form-floating">
            <textarea
              class="form-control"
              placeholder="Keep description..."
              id="floatingTextarea1"
              v-model="editable.description"
              required
            ></textarea>
            <label for="floatingTextarea1">Description</label>
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
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      modalClose() {
        editable.value = {}
      },
      async addKeep() {
        try {
          keepsService.createKeep(editable.value)
          Modal.getOrCreateInstance(document.getElementById("keep-form")).hide();
          editable.value = {}
          Pop.toast('Keep added!', 'success')
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