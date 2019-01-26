 <template>
  <div>
    <h3>Warehouses Main</h3>
    <div class="container">
      <b-btn v-b-modal.warehouseForm>Add Warehouse</b-btn>
      <b-btn v-b-modal.warehouceStockItemModal v-show="!activeWarehouse==''">Add Stock Item</b-btn>

      <warehouses-list ref="warehouseList" v-on:warehouceChanged="updateActiveWarehouse"></warehouses-list>
      <b-modal
        id="warehouseForm"
        title="Create Warehouse "
        size="lg"
        ok-title="Save"
        @ok="createNewInventory"
      >
        <WarehouseForm ref="warehouseRef"></WarehouseForm>
      </b-modal>

      <b-modal id="warehouceStockItemModal" :title="activeWarehouse" size="lg" ok-title="Save">
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
      activeWarehouse: "",
      activeWarehouseId: 0
    };
  },
  components: {
    WarehouseForm,
    WarehousesList,
    WarehouseStockItem
  },
  methods: {
    createNewInventory() {
      this.$refs.warehouseRef.onSubmit();
      // console.log("ware house form submitted ");
    },
    updateActiveWarehouse(params) {
      console.log("updateActiveWarehouse");
      console.log("emmitted id ");
      console.log(params);
      let wareHouseIndex = params.activeWarehoseIndex; //this.$refs.warehouseList.activeIndex;
      wareHouseIndex > -1
        ? (this.activeWarehouse =
            "Adding Stock Items To Warehouse: " + wareHouseIndex)
        : (this.activeWarehouse = "");
    }
  }
  // mounted() {
  //   this.activeWarehouse = this.$refs.warehouseList.activeIndex;
  // },
};
</script>

<style>
</style>
