<template>
  <div id="app">
    <div class="container">
      <ul class="nav nav-tabs">
        <li class="nav-item">
          <router-link to="/">Home</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/Users">Users</router-link>
        </li>
      </ul>
      <router-view/>
    </div>
    <!-- <img src="./assets/logo.png"> -->
  </div>
</template>

<script>
export default {
  name: "App"
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
