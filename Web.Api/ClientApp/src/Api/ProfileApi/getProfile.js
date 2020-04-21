import axios from "axios";
import Jwt from "../LoginApi/ControlJwt";
import {config} from "../../config";
import {TokenHandlerExpired} from "../LoginApi/TokenHandlerExpired";
class ProfileApi{


    async getProfile(){
        try{
            const data= await axios.get(config.url+"account/getProfile", {headers:{"Authorization": "Bearer "+Jwt.getJwt()}});
            console.log(data.data);
            return data.data;
        }
        catch(err){
            return await TokenHandlerExpired(err.response, this.getProfile);
        }
    }
}


export default new ProfileApi();