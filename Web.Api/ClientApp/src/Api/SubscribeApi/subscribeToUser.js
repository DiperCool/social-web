import axios from "axios";
import {TokenHandlerExpired} from "../../Api/LoginApi/TokenHandlerExpired"
import Jwt from "../../Api/LoginApi/ControlJwt";
import {config} from "../../config";
export const subscribeToUser=async (login)=>{
    try{
        let response= await axios.post(config.url+"user/subscribe?login="+login,{},{
            headers: {
                'Authorization': "Bearer "+Jwt.getJwt(),
              }
        });
        return response.data;
    }
    catch(err){
        return await TokenHandlerExpired(err.response, ()=>subscribeToUser(login));
    }

}