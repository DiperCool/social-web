import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const deleteComment=async(id, idComment)=>{
    try{
        let res= await axios.post(config.url+ `comments/delete?id=${id}&idComment=${idComment}`,{},{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>deleteComment(id, idComment),false,false);
    }
}