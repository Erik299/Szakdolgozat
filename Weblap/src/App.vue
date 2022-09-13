<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
export default {
  beforeCreate: function () {
    document.body.className = "home";
  },
  name: "App",
  components: {
  },
  mounted(){
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #000;
  text-align: center;
  margin: 0;
}
</style>
