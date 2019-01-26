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

        <b-form-group id="barCodeGroup" label="Barcode:" label-for="product-barcode">
          <b-form-input id="product-barcode" type="text" v-model="form.barcode" placeholder></b-form-input>
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
import axios from "axios";

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
        barcode: "",
        file: "" //TODO: check binding
      }, // end form
      options: [
        // { value: null, text: "Please select an option" },
        // { value: "a", text: "This is First option" },
        // { value: "b", text: "Selected Option" },
        // { value: { C: "3PO" }, text: "This is an option with object value" }
      ]
    };
  },
  created() {
    this.fetchData();
  },
  mounted() {
    var config = {
      headers: { "Access-Control-Allow-Origin": "*" }
    };
  },
  methods: {
    fetchData() {
      console.log("fetchingdata ");
      axios.get("http://localhost:3630/api/Category/get").then(response => {
        //console.log(response.data);

        let apiRes = response.data;

        // console.log(apiRes.Data && apiRes.Status == 1);

        if (apiRes.Data && apiRes.Status == 1) {
          apiRes.Data.brands.forEach(b => {
            this.options.push({ value: b.Id, text: b.Name });
            // console.log({ value: b.Id, text: b.Name });
          });
          // console.log(this.options);
        }
      });
    },
    onSubmit(evt) {
      evt.preventDefault();
      console.log(JSON.stringify(this.form));
      console.log("product form save ");

      axios
        .post("http://localhost:3630/api/Product/Save", {
          Id: 0,
          Name: this.form.name,
          FK_CategoryId: this.form.category,
          SellPrice: this.form.price
        })
        .then(response => console.log(response.data)); //TODO: show message with response.

      this.$root.$emit("bv::hide::modal", "modal1");
    }
  }
};
</script>

<style>
</style>
