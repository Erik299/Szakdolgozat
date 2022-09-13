<template><div class="homeBTN">
  <button @click="click">Főoldal</button>
  </div>
</template>

<script>
import router from "./../../router";
import Swal from "sweetalert2/dist/sweetalert2.js";
export default {
  props: {
    buttonText: {
      type: String,
      default: () => "Click",
    },
  },
  methods: {
    click() {
      Swal.fire({
        icon: 'warning',
        iconColor: 'red',
        title: "Amennyiben visszalép a főoldalra, az eddigi kitöltése elveszik!",
        text: "Biztos benne?",
        showDenyButton: true,
        confirmButtonText: "Igen",
        denyButtonText: "Nem",
        backdrop: true,
        allowOutsideClick: () => {
          const popup = Swal.getPopup();
          popup.classList.remove("swal2-show");
          setTimeout(() => {
            popup.classList.add("animate__animated", "animate__headShake");
          });
          setTimeout(() => {
            popup.classList.remove("animate__animated", "animate__headShake");
          }, 500);
          return false;
        },
      }).then((result) => {
        if (result.isConfirmed){
          localStorage.clear();
          router.push("/");
        }
      });
    },
  },
};
</script>

<style>
.homeBTN button {
  position: relative;
  border-radius: 25px;
  box-sizing: border-box;
  font-size: 1.2em;
  font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
    Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
  padding: 0.3em;
  line-height: 1.2em;
  margin: auto;
  border: 1px solid #10bbe6;
  box-shadow: rgba(0, 0, 0, 0.19) 0px 10px 20px, rgba(0, 0, 0, 0.23) 0px 6px 6px;
  background-color: #10bbe6;
  color: black;
  width: 100px;
  font-weight: 600;
  cursor: pointer;
  text-align: center;
  margin: 10px;
  text-shadow: 1px 1px 3px white;
  margin-top: 40px;
}

body.swal2-shown > [aria-hidden="true"] {
  transition: 0.1s filter;
  filter: blur(10px);
}

.swal2-title{
  padding: 0;
}

.swal2-html-container{
  font-size: 23px;
  font-weight: bold;
}

.swal2-actions{
  justify-content: space-around;
  width: 80%;
  margin-bottom: 10px;
}

.swal2-confirm{
  box-shadow: rgba(0, 0, 0, 0.19) 0px 10px 20px, rgba(0, 0, 0, 0.23) 0px 6px 6px !important;
  background-color: #10bbe6 !important;
  font-size: 1.1em !important;
}
.swal2-deny{
  box-shadow: rgba(0, 0, 0, 0.19) 0px 10px 20px, rgba(0, 0, 0, 0.23) 0px 6px 6px !important;
  background-color: #10bbe6 !important;
  font-size: 1.1em !important;
}

.swal2-popup{
  padding: 0;
  font-variant: normal;
  font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  border: 2px solid #10bbe6;
  background-color: #f7f7f7 !important;
}

@media only screen and (max-width: 600px) {
  .swal2-title{
  padding: 0;
  font-size: 23px;
}
.swal2-html-container{
  font-size: 17px;
  font-weight: bold;
}
.swal2-popup{
  width: 90%;
}
.swal2-icon{
  height: 4em;
  width: 4em;
}
}
</style>
