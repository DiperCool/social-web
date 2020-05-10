import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";
export const getPostUser=async(idPostS, login)=>{
    try{
        let res= await axios.get(config.url+ "account/getPost?idPost="+idPostS,{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>getPostUser(idPostS), false);
    }
}