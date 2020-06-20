import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const unLikePost=async(id)=>{
    try{
        let res= await axios.post(config.url+ "post/unLike?id="+id,{
        },{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>unLikePost(id));
    }
}