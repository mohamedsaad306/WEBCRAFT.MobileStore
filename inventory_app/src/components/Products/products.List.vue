<template>
  <b-container fluid>
    <!-- User Interface controls -->
    <b-row>
      <b-col md="6" class="my-1">
        <b-form-group horizontal label="Filter" class="mb-0">
          <b-input-group>
            <b-form-input v-model="filter" placeholder="Type to Search"/>
            <!-- <b-input-group-append> -->
            <b-btn :disabled="!filter" @click="filter = ''">Clear</b-btn>
            <!-- </b-input-group-append> -->
          </b-input-group>
        </b-form-group>
      </b-col>
      <b-col md="6" class="my-1">
        <b-form-group horizontal label="Per pprice" class="mb-0">
          <b-form-select :options="perPageOptions" v-model="perPage"/>
        </b-form-group>
      </b-col>

      <b-col md="6" class="my-1">
        <!-- <b-form-group horizontal label="Sort" class="mb-0">
          <b-input-group>
            <b-form-select v-model="sortBy" :options="sortOptions">
              <option slot="first" :value="null">-- none --</option>
            </b-form-select>
            <b-form-select :disabled="!sortBy" v-model="sortDesc" slot="append">
              <option :value="false">Asc</option>
              <option :value="true">Desc</option>
            </b-form-select>
          </b-input-group>
        </b-form-group>-->
      </b-col>
      <b-col md="6" class="my-1">
        <b-form-group horizontal label class="mb-0">
          <b-input-group>
            <b-form-select v-model="sortDirection" slot="append">
              <option value="asc">Asc</option>
              <option value="desc">Desc</option>
              <option value="last">Last</option>
            </b-form-select>
          </b-input-group>
        </b-form-group>
      </b-col>
    </b-row>

    <!-- Main table element -->
    <b-table
      show-empty
      stacked="md"
      :items="listDataProvider"
      :fields="fields"
      :current-page="currentPage"
      :per-page="perPage"
      :filter="filter"
      :sort-by.sync="sortBy"
      :sort-desc.sync="sortDesc"
      :sort-direction="sortDirection"
      @filtered="onFiltered"
    >
      <template slot="name" slot-scope="row">{{row.value}}</template>
      <template slot="isActive" slot-scope="row">{{row.value?'Yes :)':'No :('}}</template>
      <!-- <template slot="actions" slot-scope="row">
                <b-button
          size="sm"
          @click.stop="info(row.item, row.index, $event.target)"
          class="mr-1"
        >Info modal</b-button>
        <b-button
          size="sm"
          @click.stop="row.toggleDetails"
        >{{ row.detailsShowing ? 'Hide' : 'Show' }} Details</b-button>
      </template>-->
      <template slot="row-details" slot-scope="row">
        <b-card>
          <ul>
            <li v-for="(value, key) in row.item" :key="key">{{ key }}: {{ value}}</li>
          </ul>
        </b-card>
      </template>
    </b-table>

    <b-row>
      <b-col md="6" class="my-1">
        <b-pagination
          :total-rows="totalRows"
          :per-page="perPage"
          v-model="currentPage"
          class="my-0"
        />
      </b-col>
    </b-row>

    <!-- Info modal -->
    <b-modal id="modalInfo" @hide="resetModal" :title="modalInfo.title" ok-only>
      <pre>{{ modalInfo.content }}</pre>
    </b-modal>
  </b-container>
</template>

<script>
import BootstrapVue from "bootstrap-vue";
import axios from "axios";
const items = [
  {
    isActive: true,
    price: 40,
    name: { first: "Dickerson", last: "Macdonald" }
  },
  { isActive: false, price: 21, name: { first: "Larsen", last: "Shaw" } },
  {
    isActive: false,
    price: 9,
    name: { first: "Mini", last: "Navarro" },
    _rowVariant: "success"
  },
  {
    isActive: false,
    price: 89,
    name: { first: "Geneva", last: "Wilson" }
    //quants: 100
  },
  { isActive: true, price: 38, name: { first: "Jami", last: "Carney" } },
  { isActive: false, price: 27, name: { first: "Essie", last: "Dunlap" } },
  { isActive: true, price: 40, name: { first: "Thor", last: "Macdonald" } },
  {
    isActive: true,
    price: 87,
    name: { first: "Larsen", last: "Shaw" },
    _cellVariants: { price: "danger", isActive: "warning" }
  },
  { isActive: false, price: 26, name: { first: "Mitzi", last: "Navarro" } },
  { isActive: false, price: 22, name: { first: "Genevieve", last: "Wilson" } },
  { isActive: true, price: 38, name: { first: "John", last: "Carney" } },
  { isActive: false, price: 29, name: { first: "Dick", last: "Dunlap" } }
];

export default {
  name: "ProuctsList",
  components: {
    BootstrapVue
  },
  props: {
    ["productsItems"]: Array,
    ["diplayQuants"]: Boolean
  },
  created() {
    if (this.diplayQuants) {
      this.fields.push("quants");
    }
  },
  data() {
    return {
      items: this.productsItems || items,
      fields: [
        {
          key: "name",
          label: "Product Name",
          sortable: true,
          sortDirection: "desc"
        },
        {
          key: "price",
          label: "Price",
          sortable: true,
          class: "text-center"
        },
        "barcode"
        // { key: "isActive", label: "is Active" },
        // { key: "actions", label: "Actions" }
      ],
      currentPage: 1,
      perPage: 5,
      totalRows: items.length,
      perPageOptions: [5, 10, 15],
      sortBy: null,
      sortDesc: false,
      sortDirection: "asc",
      filter: null,
      modalInfo: { title: "", content: "" }
    };
  },
  computed: {
    sortOptions() {
      // Create an options list from our fields
      return this.fields
        .filter(f => f.sortable)
        .map(f => {
          return { text: f.label, value: f.key };
        });
    }
  },
  methods: {
    info(item, index, button) {
      this.modalInfo.title = `Row index: ${index}`;
      this.modalInfo.content = JSON.stringify(item, null, 2);
      this.$root.$emit("bv::show::modal", "modalInfo", button);
    },
    resetModal() {
      this.modalInfo.title = "";
      this.modalInfo.content = "";
    },
    onFiltered(filteredItems) {
      // Trigger pagination to update the number of buttons/pprices due to filtering
      this.totalRows = filteredItems.length;
      this.currentPprice = 1;
    },
    listDataProvider(ctx) {
      console.log("Data Provider ctx ");
      console.log(ctx);
      let prom = axios.get("http://localhost:3630/api/Product/get");

      return prom.then(res => {
        let listData = [];
        console.log("response recieved ");
        let apiRes = res.data;
        if (apiRes.Status == 1 && apiRes.Data) {
          console.log("string loop ");
          console.log(apiRes.Data);
          apiRes.Data.products.forEach(element => {
            // debugger;
            listData.push({
              name: element.Name,
              price: element.SellPrice,
              barcode: element.Barcode
            });
          });
        }
        // console.log(listData);
        console.log("daty");
        // debugger;
        return listData;
      });
    }
  }
};
// https://bootstrap-vue.js.org/docs/components/table/#using-items-provider-functions
</script>

 