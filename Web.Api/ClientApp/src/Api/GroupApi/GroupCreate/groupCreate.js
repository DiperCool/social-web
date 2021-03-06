import axios from "axios";
import {TokenHandlerExpired} from "../../LoginApi/TokenHandlerExpired";
import Jwt from "../../LoginApi/ControlJwt";
import {config} from "../../../config";

export const groupCreate=async(login, name)=>{
    try{
        let res= await axios.post(config.url+ "group/create",{login:login, name:name},{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt(),
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>groupCreate(login,name), false, false);
    }
}