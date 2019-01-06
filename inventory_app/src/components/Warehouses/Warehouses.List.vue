<template>
  <div class="container">
    <b-table striped hover :items="items" :fields="fields">
      <template slot="show_details" slot-scope="row">
        <!-- we use @click.stop here to prevent emitting of a 'row-clicked' event  -->
        <b-button
          size="sm"
          @click.stop="viewProductsList(row)"
          class="mr-2"
          :variant="row.index == activeIndex ? 'danger':'dark'"
        >Products</b-button>
      </template>
    </b-table>
    <hr>
    <!-- <div v-show=""></div> -->
  </div>
</template>

  

<script>
import ProductsList from "../Products/Products.List.vue";
export default {
  name: "WarehoucesList",
  components: {
    ProductsList
  },
  methods: {
    viewProductsList(r) {
      console.log("Show");
      r.index == this.activeIndex
        ? (this.activeIndex = -1)
        : (this.activeIndex = r.index);
      console.log(r);
      console.log(this.activeIndex);
    }
  },
  data() {
    return {
      activeIndex: -1,
      fields: [
        { key: "name", label: "Location ", sortable: true },
        { key: "value", label: "Items Value", sortable: true },
        { key: "items_count", label: "Items Count", sortable: true },
        "show_details"
      ],
      items: [
        { name: "location one", value: 10560, items_count: 200 },
        { name: "location Two ", value: 7500, items_count: 152 }
      ]
    };
  },
  computed: {
    activeBtn(row) {
      console.log("Show");
      r.index == this.activeIndex
        ? (this.activeIndex = -1)
        : (this.activeIndex = r.index);
      console.log(r);
      console.log(this.activeIndex);
    }
  }
};
</script>

<style>
</style>
