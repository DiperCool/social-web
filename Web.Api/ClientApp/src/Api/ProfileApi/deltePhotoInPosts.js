import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const deltePhotoInPosts=async(list, idPost)=>{
    try{
        let res= await axios.post(config.url+ "Post/deletePhotos",{
            idPost:idPost,
            idPhotos:list
        },{
            headers: {
                "Authorization": "Bearer "+Jwt.getJwt()
              }
        })
        return res.data;
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>deltePhotoInPosts(list,idPost), false);
    }
}