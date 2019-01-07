 <template>
  <div>
    <h3>Warehouses Main</h3>
    <div class="container">
      <b-btn v-b-modal.warehouceStockItemModal v-show="!activeWarehouse==''">Add Stock Item</b-btn>
      <warehouses-list ref="warehoucesList" v-on:warehouceChanged="updateActiveWarehouse"></warehouses-list>
      <!-- <WarehouseForm></WarehouseForm> -->
      <b-modal id="warehouceStockItemModal" :title="activeWarehouse" size="lg" ok-title="Save">
        <!-- <p class="my-4">Hello from modal!</p> -->
        <WarehouseStockItem></WarehouseStockItem>
      </b-modal>
    </div>
  </div>
</template>

<script>
import WarehouseForm from "./Warehouse.Form.vue";
import WarehousesList from "./Warehouses.List.vue";
import WarehouseStockItem from "./Warehouse.StockItems.vue";

export default {
  name: "WarehousesMain",
  data() {
    return {
      activeWarehouse: ""
    };
  },
  components: {
    WarehouseForm,
    WarehousesList,
    WarehouseStockItem
  },
  methods: {
    updateActiveWarehouse() {
      console.log("updateActiveWarehouse");
      let wareHouseIndex = this.$refs.warehoucesList.activeIndex;
      wareHouseIndex > -1
        ? (this.activeWarehouse =
            "Adding Stock Items To Warehouse: " + wareHouseIndex)
        : (this.activeWarehouse = "");
    }
  }
  // mounted() {
  //   this.activeWarehouse = this.$refs.warehoucesList.activeIndex;
  // },
};
</script>

<style>
</style>
