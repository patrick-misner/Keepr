<template>
  <div class="row bg-primary header">
    <div class="col-md-3"></div>
    <div class="col-md-6"></div>
    <div class="col-md-3">
      <Login />
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
