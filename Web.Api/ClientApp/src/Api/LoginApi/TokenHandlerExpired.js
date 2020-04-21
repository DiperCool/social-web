import axios from "axios";
import {config} from "../../config";
import jwt from "./ControlJwt";


export const TokenHandlerExpired=async (response, callback, redirect=true)=>{
    try{
        if(response.headers["token-expired"]){
            console.log(1);
            let res=await axios.post(config.url+"auth/refreshingToken", {
                "Token": jwt.getJwt(),
                "RefreshToken": jwt.getRefreshToken()
            })
            jwt.setJwt(res.data.token);
            jwt.setRefreshToken(res.data.refreshToken);
            return await callback();
        }
        window.location.href="/login";
    }
    catch{
        if(redirect){
            window.location.href="/login";
        }
        console.log(response);
        return response;
    }
   //
}