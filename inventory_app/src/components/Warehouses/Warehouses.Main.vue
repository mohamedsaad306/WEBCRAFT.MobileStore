 <template>
  <div>
    <h3>Warehouses Main</h3>
    <warehouses-list></warehouses-list>
    <!-- <WarehouseForm></WarehouseForm> -->
  </div>
</template>

<script>
import WarehouseForm from "./Warehouse.Form.vue";
import WarehousesList from "./Warehouses.List.vue";

export default {
  name: "WarehousesMain",
  components: {
    WarehouseForm,
    WarehousesList
  }
};
</script>

<style>
</style>
