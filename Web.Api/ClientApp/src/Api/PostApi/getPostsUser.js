import axios from "axios";
import {config} from "../../config";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
export const getPostsUser=async(login, page)=>{
    try{
        let res= axios.post(config.url+"account/getPostsUser",{
            Login:login,
            Page:page
        },{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        });
        return res;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>getPostsUser(login,page), false);
    }
}