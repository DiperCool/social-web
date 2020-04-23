import React, {useRef, useState, useContext} from "react";
import Auth from "../../Api/LoginApi/Auth";
import {Error} from "./Error"
import {Redirect} from "react-router-dom";
import {TextField} from "@material-ui/core";
import {Button} from "@material-ui/core";
import {CenterComponent} from "../CenterComponent";
import { UserContext } from "../UserComponent/UserContext";
export const Register=()=>{

    let [Errors, setErrors]=useState({
        isErrors:false,
        allErrors:[]
    });
    let {setGetLogin}= useContext(UserContext);
    let [isOk, setIsOk]=useState(false);
    let refLogin = useRef(null);
    let refEmeil = useRef(null);
    let refPassword = useRef(null);
    let refRePassword = useRef(null);

    let handler=async()=>{
        let login=refLogin.current.value;
        let emeil=refEmeil.current.value;
        let pas=refPassword.current.value;
        let rePas=refRePassword.current.value;
        let result= await Auth.register(login,pas,rePas,emeil);
        if(result.notSuccesed){
            setErrors({
                isErrors:true,
                allErrors:result.errors
            })
            return;
        }
        setGetLogin();
        setIsOk(true);



    }


    if(isOk){
        return <Redirect to="/profile"/>
    }

    return(
            <div>
                 <Error Visible={Errors.isErrors} Errors={Errors.allErrors}></Error>
                 <CenterComponent>
                        <div>
                            <TextField type={"text"} inputRef={refLogin} placeholder={"Введите логин"}></TextField>
                            <TextField type={"text"} inputRef={refEmeil} placeholder={"Введите почту"}></TextField>
                        </div>
                        <br></br>
                        <div>
                            <TextField type={"password"} inputRef={refPassword} placeholder={"Введите пароль"}></TextField>
                            <TextField type={"password"} inputRef={refRePassword} placeholder={"Повторите пароль"}></TextField>
                        </div>
                        <br></br>
                        <Button onClick={handler} variant="contained" color="primary" >Зарегестрироваться</Button>
                </CenterComponent>
            </div>

    )
}