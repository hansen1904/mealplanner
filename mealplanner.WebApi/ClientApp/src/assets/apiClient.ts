import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://*****",
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
    "access-control-allow-credentials": true,
    "access-control-allow-methods": "*",
    "access-control-allow-origin": "*",
    "access-control-allow-headers": "*",
    "cache-control": "no-cache"
  },
});

export default apiClient;