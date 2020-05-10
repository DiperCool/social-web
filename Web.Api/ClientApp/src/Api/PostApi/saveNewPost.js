import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";
export const saveNewPost=async(photos)=>{
    try{
        let res= await axios.post(config.url+ "account/createPost", photos,{
            headers: {
                'Content-Type': 'multipart/form-data',
                'Authorization': "Bearer "+Jwt.getJwt(),
              }
        })
        console.log(res.data);
    }
    catch(e){
        return await TokenHandlerExpired(e.response, ()=>saveNewPost(photos), false);
    }
}