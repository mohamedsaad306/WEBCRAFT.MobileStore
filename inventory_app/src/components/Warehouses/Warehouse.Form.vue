<template>
  <div class="container">
    <h4>Warehouse Form {{form.name}}</h4>
  </div>
</template>

<script>
import BootstrapVue from "bootstrap-vue";

export default {
  name: "WarehousesForm",
  data() {
    return {
      form: {
        name: "test name "
      }
    };
  },
  components: {
    BootstrapVue
  }
};
</script>

<style>
</style>
