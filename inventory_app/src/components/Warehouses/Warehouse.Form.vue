<template>
  <div class="container">
    <b-form @submit="onSubmit">
      <!-- <b-img slot="aside" blank blank-color="#ccc" width="100" alt="placeholder"/> -->
      <b-form-group id="nameGroup" label="Wawrehouse Name:" label-for="inventoryName">
        <b-form-input id="inventoryName" type="text" v-model="form.name" placeholder></b-form-input>
      </b-form-group>
      <!-- <b-button type="submit" variant="primary">Submit</b-button> -->
    </b-form>
  </div>
</template>

<script>
import BootstrapVue from "bootstrap-vue";
import axios from "axios";

export default {
  name: "WarehousesForm",

  methods: {
    onSubmit() {
      // console.log(this.form);
      // console.log("inside iNventory submit  ");
      axios
        .post("http://localhost:3630/api/inventory/Save", {
          Id: 0,
          Name: this.form.name
        })
        .then(r => console.log(r));
    }
  },

  data() {
    return {
      form: {
        name: ""
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
