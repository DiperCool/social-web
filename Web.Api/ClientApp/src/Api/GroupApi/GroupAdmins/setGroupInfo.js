import axios from "axios";
import {TokenHandlerExpired} from "../../LoginApi/TokenHandlerExpired";
import Jwt from "../../LoginApi/ControlJwt";
import {config} from "../../../config";

export const setGroupInfo=async(loginGroup, info)=>{
    try{
        let res= await axios.post(config.url+ "group/updateInfo?loginGroup="+loginGroup,info,{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt(),
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>setGroupInfo(loginGroup, info), false, false);
    }
}