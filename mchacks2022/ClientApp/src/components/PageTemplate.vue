<template>
  <div>
    <slot></slot>
  </div>
</template>

<script>

export default {
  name: 'PageTemplate',
  props: {
    title: String
  }

}
</script>
