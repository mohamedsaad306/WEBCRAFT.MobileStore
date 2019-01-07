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
      <ProuctsList v-bind:products-items="items"></ProuctsList>
    </div>
  </div>
</template> 

<script>
import ProductsForm from "./products.Form.vue";
import ProuctsList from "./products.List.vue";

const _items = [
  {
    isActive: true,
    age: 40,
    name: { first: "Larsen", last: "Larsen" },
    quants: 100
  },
  { isActive: false, age: 21, name: { first: "Larsen", last: "Larsen" } },
  {
    isActive: false,
    age: 9,
    name: { first: "Mini", last: "Navarro" },
    _rowVariant: "success"
  },
  { isActive: false, age: 89, name: { first: "Larsen", last: "Wilson" } },
  { isActive: true, age: 38, name: { first: "Larsen", last: "Carney" } },
  { isActive: false, age: 27, name: { first: "Larsen", last: "Dunlap" } },
  { isActive: true, age: 40, name: { first: "Larsen", last: "Macdonald" } },
  {
    isActive: true,
    age: 87,
    name: { first: "Larsen", last: "Shaw" },
    _cellVariants: { age: "danger", isActive: "warning" }
  },
  { isActive: false, age: 26, name: { first: "Mitzi", last: "Navarro" } },
  { isActive: false, age: 22, name: { first: "Genevieve", last: "Wilson" } },
  { isActive: true, age: 38, name: { first: "John", last: "Carney" } },
  { isActive: false, age: 29, name: { first: "Dick", last: "Dunlap" } }
];

export default {
  name: "ProductsMain",
  data() {
    return { items: _items };
  },
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
