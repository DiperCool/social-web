import axios from "axios";
import {TokenHandlerExpired} from "../../LoginApi/TokenHandlerExpired";
import Jwt from "../../LoginApi/ControlJwt";
import {config} from "../../../config";

export const groupCreate=async(login, photos)=>{
    try{
        let res= await axios.get(config.url+ "group/createPost?login="+login,photos,{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt(),
                'Content-Type': 'multipart/form-data',
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>groupCreate(login,post), false, false);
    }
}