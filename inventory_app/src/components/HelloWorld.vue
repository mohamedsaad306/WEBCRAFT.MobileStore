<template>
  <div class="hello">
    <h3>{{ msgg }}</h3>
  </div>
</template> 

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: "This Is Sample "
  },
  data() {
    return {
      msgg: "This Is Sample Data  "
    };
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
