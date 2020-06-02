import axios from "axios";
import {config} from "../../config";
export const getSubscribers=async (login, page)=>{
    let response= await axios.get(config.url+`user/getSubscribers?login=${login}&page=${page}`);
    return response.data;
}
