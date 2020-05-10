import axios from "axios";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";

export const udpateUserInfo=async(id,NameSend,AboutMeSend,GenderSend,)=>{
    try{
        let response= await axios.post(config.url+"account/changeUserInfo", {
            Id:id,
            AboutMe:AboutMeSend,
            Name:NameSend,
            Gender:GenderSend
        },{
            headers:
            {
                "Authorization": "Bearer "+Jwt.getJwt()
            }
        });
        return response.data
    }

    catch(err){
        console.log(1);
        return await TokenHandlerExpired(err.response, ()=>udpateUserInfo(id,NameSend,AboutMeSend,GenderSend));
    }
}