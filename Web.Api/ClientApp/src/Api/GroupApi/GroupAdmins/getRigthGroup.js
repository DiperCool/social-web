import axios from "axios";
import {TokenHandlerExpired} from "../../LoginApi/TokenHandlerExpired";
import Jwt from "../../LoginApi/ControlJwt";
import {config} from "../../../config";

export const getRigthGroup=async(loginGroup, loginUser)=>{
    try{
        let res= await axios.get(config.url+ "group/getUserRigths?loginGroup="+loginGroup+"&loginUser="+loginUser,{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt(),
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>getRigthGroup(loginGroup, loginUser), false, false);
    }
}