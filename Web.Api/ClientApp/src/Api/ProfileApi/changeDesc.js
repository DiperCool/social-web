import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const changeDesc=async(text,id)=>{
    try{
        let res= await axios.post(config.url+ "post/changeDesc?newDesc="+text+"&idPost="+id,{
        },{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>changeDesc(text,id), false);
    }
}