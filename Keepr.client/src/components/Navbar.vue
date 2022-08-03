<template>
  <div
    class="
      bg-primary
      d-flex
      flex-column flex-md-row
      justify-content-between
      align-items-end align-items-md-center
      elevation-2
    "
  >
    <router-link :to="{ name: 'Home' }">
      <img
        class="img-fluid header-img p-3"
        src="../assets/img/logo-white.png"
        alt=""
      />
    </router-link>

    <Login />
  </div>
</template>

<script>
export default {
  setup() {
    return {};
  },
};
</script>

<style scoped lang="scss">
.header {
  height: 100px;
  min-height: 100px;
  z-index: -1;
}
.header-img {
  height: 100px;
}

img {
  border-radius: 0px;
}
a:hover {
  text-decoration: none;
}

.profile-img .nav-link {
  text-transform: uppercase;
}
.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
