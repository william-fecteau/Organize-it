<template>
  <page-template title="Class">
    <h1>TestView2 in da house B) {{ classId }}</h1>
    <input type="file"
           id="file-input" name="avatar"
           accept="pdf"/>
  </page-template>
</template>

<script>
import PageTemplate from "../../components/PageTemplate";
import axios from "axios";

export default {
  name: "TestView2",
  components: {PageTemplate},
  props: {
    classId: {
      type: String,
      default: 'no class selected'
    }
  },
  methods: {
    readFile(file) {
      return new Promise((resolve, reject) => {
        // Create file reader
        let reader = new FileReader()

        // Register event listeners
        reader.addEventListener("loadend", e => resolve(e.target.result))
        reader.addEventListener("error", reject)

        // Read file
        reader.readAsArrayBuffer(file)
      })
    },
    async getAsByteArray(file) {
      return Array.from(new Uint8Array(await this.readFile(file)));
    },
  },
  async mounted() {

  },
  watch: {
    classId: {
      immediate: true,
      async handler() {
        const inputNode = document.getElementById('file-input')
        const selectedFile = inputNode.files[0]
        const byteFile = await this.getAsByteArray(selectedFile)

        console.log(byteFile);

        const res = await axios.post("/file/upload-test",
            {fileContent: byteFile, filename: "test", extension: "pdf"});
        console.log(res);


        // const res = await axios.get("/note/H2022?classFilter=MAT-1919");
        // console.log(res);

      }
    }
  }
}
</script>