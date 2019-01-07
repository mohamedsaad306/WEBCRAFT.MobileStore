<template>
  <b-table hover :items="stockItems" :fields="fields">
    <template slot="actions" slot-scope="row">
      <!-- A custom formatted footer cell  for field 'name' -->
      <h3>asd</h3>
    </template>
  </b-table>
</template>

<script>
export default {
  name: "WarehouseStockItem",
  data() {
    return {
      fields: {
        warehouseId: {},
        quantity: {},
        name: {
          key: "product.name"
        },
        actions: {}
      },

      products: [
        { id: 1, name: "product 1", barcode: "123456" },
        { id: 2, name: "product 2", barcode: "654321" },
        { id: 3, name: "product 3", barcode: "951753" }
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
