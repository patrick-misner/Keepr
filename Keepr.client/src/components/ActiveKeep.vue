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
              <div class="dropdown">
                <button
                  class="btn btn-secondary dropdown-toggle"
                  type="button"
                  id="dropdownMenuButton1"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  Add to Vault
                </button>
                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                  <li><a class="dropdown-item" href="#">Action</a></li>
                  <li><a class="dropdown-item" href="#">Another action</a></li>
                  <li>
                    <a class="dropdown-item" href="#">Something else here</a>
                  </li>
                </ul>
              </div>
            </div>

            <div class="align-items-center">
              <i class="mdi mdi-trash-can fs-3 text-danger"></i>
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