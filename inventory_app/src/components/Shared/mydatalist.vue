<template>
  <div>

    <b-form-input list="items" v-model="selectedItemString" type="text"></b-form-input>
    <b-form-input list="items" v-model="selectedItemString" type="text"></b-form-input>
    <datalist id="items" v-show="false">
      <option :value="item.id" v-for="item in itemsList" :key="item.id"></option>
    </datalist>
  </div>
</template>

<script>
export default {
  name: "MyDataList",
  data() {
    return {
      selectedItemString: ""
    };
  },
  props: {
    ["itemsList"]: Array
  }
};
</script>

<style>
</style>
