<template>
  <div class="container-fluid">
    <div class="row bg-primary header align-items-center">
      <div class="col-md-3">
        <span class="fs-3 px-5">KeppR</span>
      </div>
      <div class="col-md-6">
        <div class="d-flex justify-content-center">SEARCH BAR</div>
      </div>
      <div class="col-md-3 text-end">
        <Login />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    return {};
  },
};
</script>

<style scoped>
.header {
  height: 100px;
  min-height: 100px;
}
a:hover {
  text-decoration: none;
}
.nav-link {
  text-transform: uppercase;
}
.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
