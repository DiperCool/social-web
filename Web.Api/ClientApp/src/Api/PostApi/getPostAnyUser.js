import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const getPostAnyUser=async(id, login)=>{
    try{
        let res= await axios.get(config.url+ `post/getAnyPostUser?id=${id}&login=${login}`,{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>getPostAnyUser(id,login),false,false);
    }
}