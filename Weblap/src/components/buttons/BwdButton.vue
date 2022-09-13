<template>
  <button @click="click">{{ buttonText }}</button>
</template>

<script>
import router from "./../../router"
export default {
    props:{
        buttonText:{
            type: String,
            default: () => "Click",
        }
    },
    methods:{
        click(){
            router.go(-1);
        }
    }
}
</script>

<style>

</style>