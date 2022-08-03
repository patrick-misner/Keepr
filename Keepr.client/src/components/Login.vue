<template>
  <span class="navbar-text">
    <button
      class="
        btn
        selectable
        text-white
        mx-2
        lighten-30
        text-uppercase
        my-2 my-lg-0
      "
      @click="login"
      v-if="!user.isAuthenticated"
    >
      Login
    </button>

    <div class="dropdown my-2 my-lg-0" v-else>
      <div
        class="dropdown-toggle selectable"
        data-bs-toggle="dropdown"
        id="authDropdown"
      >
        <div v-if="account.picture" class="rounded mx-3 login-bg">
          <img
            :src="account.picture"
            class=""
            alt="account photo"
            height="40"
            title="Account menu"
          />
          <span
            class="mx-3 text-white lighten-30 name-hide"
            title="Account menu"
            >{{ account.name }}</span
          >
        </div>
      </div>
      <div class="dropdown-menu p-0 list-group w-100">
        <router-link :to="{ name: 'Account' }" title="Home" name="Home">
          <div class="list-group-item list-group-item-action hoverable">
            Manage Account
          </div>
        </router-link>

        <div
          @click="goToProfile"
          class="list-group-item list-group-item-action hoverable"
        >
          My Profile
        </div>

        <div
          class="list-group-item list-group-item-action hoverable text-danger"
          @click="logout"
        >
          <i class="mdi mdi-logout"></i>
          logout
        </div>
      </div>
    </div>
  </span>
</template>


<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState";
import { AuthService } from "../services/AuthService";
import { router } from "../router";
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup();
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin });
      },
      goToProfile() {
        router.push({
          name: "Profile",
          params: { id: this.account.id }
        });
      },
    };
  },
};
</script>


<style scoped lang="scss">
img {
  height: 45px;
  border-radius: 3px 0px 0px 3px;
}

@media only screen and (min-width: 768px) {
  .login-bg {
    background-color: #505050;
  }
}
@media only screen and (max-width: 768px) {
  img {
    border-radius: 50%;
  }
  .name-hide {
    display: none;
  }
}
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
</style>
