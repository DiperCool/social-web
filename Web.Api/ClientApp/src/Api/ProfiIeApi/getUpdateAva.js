import axios from "axios";
import {TokenHandlerExpired} from "../../Api/LoginApi/TokenHandlerExpired"
import Jwt from "../../Api/LoginApi/ControlJwt";
export const updateAva=async (fromData)=>{
    try{
        let response= await axios.post("https://localhost:5001/account/uploadAvu",fromData,{
            headers: {
                'Content-Type': 'multipart/form-data',
                'Authorization': "Bearer "+Jwt.getJwt(),
              }
        });
        return response.data;
    }
    catch(err){
        return await TokenHandlerExpired(err.response, ()=>updateAva(fromData));
    }

}