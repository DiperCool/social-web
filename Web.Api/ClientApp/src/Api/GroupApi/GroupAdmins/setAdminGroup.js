import axios from "axios";
import {TokenHandlerExpired} from "../../LoginApi/TokenHandlerExpired";
import Jwt from "../../LoginApi/ControlJwt";
import {config} from "../../../config";

export const setAdminGroup=async(loginGroup, loginUser, right)=>{
    try{
        let res= await axios.post(config.url+ "group/setRight?loginGroup="+loginGroup+"&loginUser="+loginUser,{
            Rights:right
        },{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt(),
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>setAdminGroup(loginGroup, loginUser, right), false, false);
    }
}