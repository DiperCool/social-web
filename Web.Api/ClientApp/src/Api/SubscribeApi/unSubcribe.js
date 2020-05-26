import axios from "axios";
import {TokenHandlerExpired} from "../../Api/LoginApi/TokenHandlerExpired"
import Jwt from "../../Api/LoginApi/ControlJwt";
import {config} from "../../config";
export const unSubcribe=async (login)=>{
    try{
        let response= await axios.post(config.url+"user/unSubscribe?login="+login,{},{
            headers: {
                'Authorization': "Bearer "+Jwt.getJwt(),
              }
        });
        return response.data;
    }
    catch(err){
        return await TokenHandlerExpired(err.response, ()=>unSubcribe(login));
    }

}