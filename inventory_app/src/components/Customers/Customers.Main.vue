<template>
  <div>
    <!-- New Customer  -->

    <b-container>
      <h5>New Customer</h5>
      <b-row>
        <CustomerForm></CustomerForm>
      </b-row>
    </b-container>
    <hr />

    <!-- Customers List  -->
    <div class="container">
      <!-- User Interface controls -->
      <h5>Customers List</h5>
      <b-row>
        <br />
        <b-col lg="6" class="my-1">
          <b-form-group label-for="filterInput" class="mb-0">
            <b-input-group size="sm">
              <b-form-input
                v-model="filter"
                type="search"
                id="filterInput"
                placeholder="Type to Search"
              ></b-form-input>
              <b-input-group-append>
                <b-button :disabled="!filter" @click="filter = ''">Clear</b-button>
              </b-input-group-append>
            </b-input-group>
          </b-form-group>
        </b-col>
      </b-row>
      <!-- Main table element -->

      <b-table
        show-empty
        small
        stacked="md"
        :items="items"
        :fields="fields"
        :current-page="currentPage"
        :per-page="perPage"
        :filter="filter"
        :filterIncludedFields="filterOn"
        :sort-by.sync="sortBy"
        :sort-desc.sync="sortDesc"
        :sort-direction="sortDirection"
        @filtered="onFiltered"
      >
        <template slot="name" slot-scope="row">{{ row.value.first }} {{ row.value.last }}</template>

        <template slot="  actions" slot-scope="row">
          <b-button
            size="sm"
            @click="info(row.item, row.index, $event.target)"
            class="mr-1"
          >Info modal</b-button>
          <b-button
            size="sm"
            @click="row.toggleDetails"
          >{{ row.detailsShowing ? 'Hide' : 'Show' }} Details</b-button>
        </template>

        <template slot="row-details" slot-scope="row">
          <b-card>
            <ul>
              <li v-for="(value, key) in row.item" :key="key">{{ key }}: {{ value }}</li>
            </ul>
          </b-card>
        </template>
      </b-table>

      <b-row>
        <b-col sm="7" md="6" class="my-1">
          <b-pagination
            v-model="currentPage"
            :total-rows="totalRows"
            :per-page="perPage"
            align="fill"
            size="sm"
            class="my-0"
          ></b-pagination>
        </b-col>

        <b-col sm="3" md="1" class="my-1">
          <b-form-group
            label-cols-sm="2"
            label-cols-md="1"
            label-cols-lg="1"
            label-align-sm="right"
            label-size="sm"
            label-for="perPageSelect"
            class="mb-0"
          >
            <b-form-select v-model="perPage" id="perPageSelect" size="sm" :options="pageOptions"></b-form-select>
          </b-form-group>
        </b-col>
      </b-row>

      <!-- Info modal -->
      <b-modal :id="infoModal.id" :title="infoModal.title" ok-only @hide="resetInfoModal">
        <pre>{{ infoModal.content }}</pre>
      </b-modal>
    </div>
  </div>
</template>

<script>
import CustomerForm from "./Customer.Form.vue";
export default {
  name: "CustomersMain",
  components: { CustomerForm },
  data() {
    return {
      items: [
        {
          isActive: true,

          name: { first: "Dickerson", last: "Macdonald" },
          address: "address "
        },
        { isActive: false, name: { first: "Larsen", last: "Shaw" } },
        {
          isActive: false,

          name: { first: "Mini", last: "Navarro" },
          _rowVariant: "success"
        },
        { isActive: false, name: { first: "Geneva", last: "Wilson" } },
        { isActive: true, name: { first: "Jami", last: "Carney" } },
        { isActive: false, name: { first: "Essie", last: "Dunlap" } },
        { isActive: true, name: { first: "Thor", last: "Macdonald" } },

        { isActive: false, name: { first: "Mitzi", last: "Navarro" } },
        {
          isActive: false,

          name: { first: "Genevieve", last: "Wilson" }
        },
        { isActive: true, name: { first: "John", last: "Carney" } },
        { isActive: false, name: { first: "Dick", last: "Dunlap" } }
      ],
      fields: [
        {
          key: "name",
          label: "Customer Name",
          sortable: true,
          sortDirection: "desc"
        },
        { key: "address", label: "Address" }
        // {
        //   key: "isActive",
        //   label: "is Active",
        //   formatter: (value, key, item) => {
        //     return value ? "Yes" : "No";
        //   },
        //   sortable: true,
        //   sortByFormatted: true,
        //   filterByFormatted: true
        // },
        // { key: "actions", label: "Actions" }
      ],
      totalRows: 1,
      currentPage: 1,
      perPage: 10,
      pageOptions: [5, 10, 15],
      sortBy: "",
      sortDesc: false,
      sortDirection: "asc",
      filter: null,
      filterOn: [],
      infoModal: {
        id: "info-modal",
        title: "",
        content: ""
      }
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
  mounted() {
    // Set the initial number of items
    this.totalRows = this.items.length;
  },
  methods: {
    info(item, index, button) {
      this.infoModal.title = `Row index: ${index}`;
      this.infoModal.content = JSON.stringify(item, null, 2);
      this.$root.$emit("bv::show::modal", this.infoModal.id, button);
    },
    resetInfoModal() {
      this.infoModal.title = "";
      this.infoModal.content = "";
    },
    onFiltered(filteredItems) {
      // Trigger pagination to update the number of buttons/pages due to filtering
      this.totalRows = filteredItems.length;
      this.currentPage = 1;
    }
  }
};
</script>

<style>
</style>
