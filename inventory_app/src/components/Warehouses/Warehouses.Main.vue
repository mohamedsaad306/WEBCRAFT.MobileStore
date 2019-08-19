 <template>
  <div>
    <!-- <h3>Warehouses Main</h3> -->
    <div class="container">
      <b-btn v-b-modal.warehouseForm>Add Warehouse</b-btn>
      <b-btn v-b-modal.warehouceStockItemModal v-show="activeWarehouseIndex>-1">Add Stock Item</b-btn>

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

      <b-modal
        id="warehouceStockItemModal"
        :title="activeWarehouseName"
        size="lg"
        ok-title="Save"
        @ok="addStockItem"
      >
        <WarehouseStockItem
          ref="stockItemModal"
          :activeIndex="activeWarehouseIndex"
          :activeId="activeWarehouseId"
        ></WarehouseStockItem>
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
      activeWarehouseId: 0,
      activeWarehouseIndex: -1,
      activeWarehouseName: ""
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
    addStockItem() {
      this.$refs.stockItemModal.onSave();
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
      // this.wareHouseIndex = wareHouseIndex;

      this.activeWarehouseId = params.activeWarehouseId;
      this.activeWarehouseIndex = wareHouseIndex; //params.activeWarehouseIndex;
      this.activeWarehouseName = params.activeWarehouseName;
      //  this.$refs.stockItemModal.wareHouseIndex = 10;
    }
  }
};
</script>

<style>
</style>
