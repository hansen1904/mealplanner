import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:5000/api/v1",
  headers: {
    'Content-Type': 'application/json',
    'Access-Control-Allow-Headers': 'Accept',
  }
});