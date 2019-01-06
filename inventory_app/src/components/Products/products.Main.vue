<template>
  <div class="products">
    <!-- <h3>Products Main Area</h3> -->
    <div class="container">
      <div class="col-md-4">
        <b-btn v-b-modal.modal1>New Product</b-btn>
        <b-modal id="modal1" title="Create New Product" @ok="createNewProduct" hide-footer>
          <!-- <p class="my-4">Hello from modal!</p> -->
          <ProductsForm></ProductsForm>
        </b-modal>
      </div>
      <hr>
      <ProuctsList></ProuctsList>
    </div>
  </div>
</template> 

<script>
import ProductsForm from "./products.Form.vue";
import ProuctsList from "./products.List.vue";

export default {
  name: "ProductsMain",
  methods: {
    createNewProduct(input) {
      console.log(input.target);
    }
  },
  props: {
    msg: String
  },
  components: {
    ProductsForm,
    ProuctsList
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
/* h3 {
  margin: 40px 0 0;
}   
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
} */
</style>
