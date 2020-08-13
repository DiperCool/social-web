import axios from "axios";
import {TokenHandlerExpired} from "../../LoginApi/TokenHandlerExpired";
import Jwt from "../../LoginApi/ControlJwt";
import {config} from "../../../config";

export const setGroupAva=async(loginGroup, img)=>{
    try{
        let res= await axios.post(config.url+ "group/updateAva?loginGroup="+loginGroup,img,{
            headers: {
                'Content-Type': 'multipart/form-data',
                "Authorization": "Bearer "+Jwt.getJwt(),
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>setGroupAva(loginGroup, img), false, false);
    }
}