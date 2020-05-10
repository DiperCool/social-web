import axios from "axios";
import {config} from "../../config";
import jwt from "./ControlJwt";


export const TokenHandlerExpired=async (response, callback, redirect=true,auth=true)=>{
    try{
        if(response.headers["token-expired"]){
            let res=await axios.post(config.url+"auth/refreshingToken", {
                "Token": jwt.getJwt(),
                "RefreshToken": jwt.getRefreshToken()
            })
            jwt.setJwt(res.data.token);
            jwt.setRefreshToken(res.data.refreshToken);
            return await callback();
        }
        if(auth){
            window.location.href="/login";
        }
        return response;    
    }
    catch{
        if(redirect){
            window.location.href="/login";
        }
        return response;
    }
}