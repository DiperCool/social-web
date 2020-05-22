import axios from "axios";
import {config} from "../../config";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";

export const SearchUsers= async(contains, page)=>{
    try{
        const data= await axios.get(config.url+`searchUsers?contains=${contains}&page=${page}`);
        return data.data;
    }
    catch(err){
        return await TokenHandlerExpired(err.response, ()=>SearchUsers(contains, page));
    }
}