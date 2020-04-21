import React,{useRef, useState, useContext} from "react";
import Auth from "../../Api/LoginApi/Auth";
import {Error} from "./Error";
import {Redirect} from "react-router-dom";
import {TextField} from "@material-ui/core";
import {Button} from "@material-ui/core"
import {CenterComponent} from "../CenterComponent";
import {UserContext} from "../UserComponent/UserContext";

export const Login=()=>{

    let [isOk, setOk]= useState(false);
    let [Errors, setErrors]=useState({
        isErrors:false,
        allErrors:[]
    });
    let refLogin= useRef(null);
    let refPassword=useRef(null);

    let {setLoginAndSetAuth}= useContext(UserContext);

    const handler=async()=>{
        let login= refLogin.current.value;
        let password= refPassword.current.value;
        let result=await Auth.login(login,password);
        if(result.notSuccesed){
            setErrors({
                isErrors:true,
                allErrors:[result.errors]
            })
            return;
        }
        setLoginAndSetAuth(login);
        setOk(true);
    }

    if(isOk){
        return <Redirect to="/profile"/>
    }

    return (
        <div>
            <Error Errors={Errors.allErrors} Visible={Errors.isErrors}></Error>
            <CenterComponent>
                <div>
                    <TextField 
                        inputRef={refLogin} 
                        id="standard-basic" 
                        label="Login" />
                    <br></br>
                    <TextField 
                        inputRef={refPassword} 
                        id="standard-basic" 
                        label="Password" 
                        type="password"
                        />
                    <br></br>
                    <Button variant="contained" color="primary" onClick={handler} style={{"marginTop":"10px"}}>Войти</Button>
                </div>
            </CenterComponent>
        </div>
    )
}