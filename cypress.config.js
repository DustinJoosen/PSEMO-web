const { defineConfig } = require("cypress");

module.exports = defineConfig({
  projectId: '7p5dba',
  e2e: {
    baseUrl: "https://localhost:9001",
  },
});
