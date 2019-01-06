<template>
  <div>
    <!-- <div class="col-md-6"> -->
    <b-form @submit="onSubmit">
      <!-- <b-img slot="aside" blank blank-color="#ccc" width="100" alt="placeholder"/> -->
      <b-form-group id="nameGroup" label="Product Name:" label-for="productName">
        <b-form-input id="productName" type="text" v-model="form.name" placeholder></b-form-input>
      </b-form-group>

      <b-form-group id="categoryGroup" label="Select Category:" label-for="productCategory">
        <b-form-select
          id="productCategory"
          v-model="form.category"
          :options="options"
          class="mb-3"
        />
        <b-form-group id="priceGroup" label="Price:" label-for="product-price">
          <b-form-input id="product-price" type="text" v-model="form.price" placeholder></b-form-input>
        </b-form-group>
      </b-form-group>

      <!-- <b-form-file v-model="form.file" :state="Boolean(file)" placeholder="Choose a file..."></b-form-file> -->
      <b-form-file v-model="form.file" class="mt-3" plain></b-form-file>
      <br>
      <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>
    <!-- </div> -->
    <!-- <div class="col-md-4"> -->
    <!-- </div> -->
  </div>
</template>

<script>
import BootstrapVue from "bootstrap-vue";

export default {
  name: "ProductsForm",
  components: {
    BootstrapVue
  },
  data() {
    return {
      form: {
        id: "",
        name: "",
        category: "",
        price: "",
        file: "" //TODO: check binding
      }, // end form
      options: [
        { value: null, text: "Please select an option" },
        { value: "a", text: "This is First option" },
        { value: "b", text: "Selected Option" },
        { value: { C: "3PO" }, text: "This is an option with object value" }
      ]
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      console.log(JSON.stringify(this.form));
    }
  }
};
</script>

<style>
</style>
