import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const newComment=async(id,content,to=null)=>{
    try{
        let res= await axios.post(config.url+ `comments/create?id=${id}`,{
            Content:content,
            To:to
        },{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>newComment(id,content,to), false,false);
    }
}