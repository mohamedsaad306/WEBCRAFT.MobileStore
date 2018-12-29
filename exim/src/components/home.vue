<template>
  <div>
    <h2>Home : {{Title}}</h2>
    <b-button :model="pressed" variant="primary">Toggle Me</b-button>
    
    <b-alert    
      variant="danger"
      dismissible
      :show="showDismissibleAlert"
      @dismissed="showDismissibleAlert=false"
    >Dismissible Alert!</b-alert>

    <router-view/>
  </div>
</template>

<script>
export default {
  name: "Home",
  data() {
    return {
      Title: "This Is the Home ",
      pressed:false
    };
  }
};
</script>

<style scoped>
</style>
