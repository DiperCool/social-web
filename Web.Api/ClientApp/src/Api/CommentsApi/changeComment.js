import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const changeComment=async(id, idComment, content)=>{
    try{
        let res= await axios.post(config.url+ `comments/change?id=${id}`,{
            Id:idComment,
            Content:content
        },{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>changeComment(id, idComment, content),false,false);
    }
}