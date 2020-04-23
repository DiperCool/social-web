import axios from "axios";
import {config} from "../../config";

export const getPostsUser=async(login, page)=>{
    try{
        let res= axios.post(config.url+"account/getPostsUser",{
            Login:login,
            Page:page
        });
        return res;
    }
    catch(err){
        console.log(err);
    }
}