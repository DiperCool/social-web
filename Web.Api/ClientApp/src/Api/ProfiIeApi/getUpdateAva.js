import axios from "axios";
import {TokenHandlerExpired} from "../../Api/LoginApi/TokenHandlerExpired"
import Jwt from "../../Api/LoginApi/ControlJwt";
import {config} from "../../config";
export const updateAva=async (fromData)=>{
    try{
        let response= await axios.post(config.url+"account/uploadAvu",fromData,{
            headers: {
                'Content-Type': 'multipart/form-data',
                'Authorization': "Bearer "+Jwt.getJwt(),
              }
        });
        return response.data;
    }
    catch(err){
        return await TokenHandlerExpired(err.response, ()=>updateAva(fromData),false,false);
    }

}