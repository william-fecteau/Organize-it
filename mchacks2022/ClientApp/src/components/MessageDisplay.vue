<template>
  <div class="border-4 border-black rounded">
    <h1 class="italic font-bold">{{ msg }}</h1>
  </div>
</template>

<script>
export default {
  name: 'MessageDisplay',
  props: {
    msg: String
  }
}
</script>
