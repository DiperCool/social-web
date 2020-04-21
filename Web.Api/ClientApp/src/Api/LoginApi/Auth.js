import axios from "axios";
import jwt from "./ControlJwt";
import {config} from "../../config";
class Auth{
    async login(login,password){
        try{
            let result= await axios.post(config.url+"auth/login",{Login:login, Password: password});
            jwt.setJwt(result.data.token)
            jwt.setRefreshToken(result.data.refreshToken);
            return {
                notSuccesed: false
            }
        }
        catch(result){
            return {
                notSuccesed: true,
                errors:result.response.data
            }
        }
    }


    async register(login, password, rePassword, emeil){
        try{
            let result = await axios.post(config.url+"auth/register",{Login:login, Password:password, RePassword:rePassword, Emeil:emeil});
            jwt.setJwt(result.data.token)
            jwt.setRefreshToken(result.data.refreshToken);
            return {
                notSuccesed: false
            }
        }
        catch(result){
            let errorsRes=result.response.data.errors;
            let arr=[];
            for(let obj in errorsRes){
                errorsRes[obj].map(el=>{
                    arr.push(el);
                    return el;
                })
            }
            if(result.response.data.LoginExcaption!=null){
                arr.push(result.response.data.LoginExcaption);
            }
            return {
                notSuccesed: true,
                errors:arr,
            }
        }
    }

}

export default new Auth();