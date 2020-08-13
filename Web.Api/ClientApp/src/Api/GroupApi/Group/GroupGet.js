import axios from "axios";
import {TokenHandlerExpired} from "../../LoginApi/TokenHandlerExpired";
import Jwt from "../../LoginApi/ControlJwt";
import {config} from "../../../config";

export const groupGet=async(loginGroup)=>{
    try{
        let res= await axios.get(config.url+ "group/get?loginGroup="+loginGroup,{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt(),
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>groupGet(loginGroup), false, false);
    }
}