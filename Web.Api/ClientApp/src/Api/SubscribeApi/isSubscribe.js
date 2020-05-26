import axios from "axios";
import {config} from "../../config";
export const isSubscribe=async (to, who)=>{
    let response= await axios.get(config.url+`user/isSubscribed?who=${who}&to=${to}`);
    return response.data;
}