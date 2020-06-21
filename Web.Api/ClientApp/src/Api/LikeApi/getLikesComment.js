import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const getLikesComment=async(id, page)=>{
    try{
        let res= await axios.get(config.url+ "comments/getLikes?id="+id+"&page="+page,{
        },{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>getLikesComment(id), false, false);
    }
}