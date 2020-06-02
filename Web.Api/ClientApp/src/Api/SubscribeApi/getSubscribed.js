import axios from "axios";
import {config} from "../../config";
export const getSubscribed=async (login, page)=>{
    let response= await axios.get(config.url+`user/getSubscribed?login=${login}&page=${page}`);
    return response.data;
}