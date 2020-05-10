import axios from "axios";
import {config} from "../../config";

export const getInfoUser=async(login)=>{
    try{
        let res=await axios.get(config.url+"user/getInfo?login="+login);
        return res;
    }
    catch(err){
        console.log(err);
    }
}