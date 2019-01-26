<template>
  <div class="container">
    <b-table hover :items="stockItems" :fields="fields">
      <template slot="actions" slot-scope>
        <!-- A custom formatted footer cell  for field 'name' -->
        <b-button size="sm" variant="danger">Remove</b-button>
      </template>
      <template slot="table-caption">
        <b-form-select
          v-show="true"
          list="products"
          v-model="selectedProduct"
          :data-id="selectedProductIndex"
          class="custom-select"
          :onselect="sayhi"
          type="text"
        >
          <option
            :data-id="item.id"
            v-for="item in products"
            :key="item.id"
            :onSelect="sayhi"
          >{{item.name}}</option>
        </b-form-select>

        <datalist id="products" v-show="false">
          <option
            :data-id="item.id"
            v-for="item in products"
            :key="item.id"
            :onSelect="sayhi"
          >{{item.name}}</option>
        </datalist>

        <b-button size="sm" variant="success">Addssss</b-button>
      </template>
    </b-table>
  </div>
</template>

<script>
export default {
  name: "WarehouseStockItem",
  watch: {
    selectedProduct: function() {
      console.log(this.selectedProduct);
    },
    selectedProductIndex: function() {
      console.log(this.selectedProductIndex);
    }
  },
  methods: {
    sayhi: function() {
      alert("his");
    }
  },
  data() {
    return {
      selectedProduct: "",
      selectedProductIndex: "",
      newItem: { productId: "", warehouseId: "", quantity: 0 },
      fields: {
        // warehouseId: {},
        name: {
          key: "product.name"
        },
        quantity: {},
        actions: {}
      },

      products: [
        { id: 1, name: "product 1", barcode: "123456" },
        { id: 2, name: "product 2", barcode: "654321" },
        { id: 3, name: "product 3", barcode: "951753" },
        { id: 4, name: "product 3", barcode: "951753" }
      ],

      stockItems: [
        {
          warehouseId: 1,
          product: { id: 1, name: "Product 1 " },
          quantity: 20
        }
      ]
    };
  }
};
</script>

<style>
</style>
