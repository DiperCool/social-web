import axios from "axios";
import {TokenHandlerExpired} from "./LoginApi/TokenHandlerExpired";
import {config} from "../config";
import Jwt from "./LoginApi/ControlJwt";
export const getLogin=async()=>{
    try{
        const res= await axios.get(config.url+"account/getLogin", {
            headers: {
                'Authorization': "Bearer "+Jwt.getJwt(),
              }
        });
        return res;
    }
    catch(e){
        return await TokenHandlerExpired(e.response,getLogin,false);
    }
}