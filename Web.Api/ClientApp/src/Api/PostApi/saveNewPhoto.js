import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";
export const saveNewPhoto=async(data)=>{
    try{
        let res= await axios.post(config.url+ "post/saveNewPhoto", data,{
            headers: {
                'Content-Type': 'multipart/form-data',
                'Authorization': "Bearer "+Jwt.getJwt(),
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>saveNewPhoto(data), false);
    }
}