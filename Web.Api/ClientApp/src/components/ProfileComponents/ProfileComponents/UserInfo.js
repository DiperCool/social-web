import React, {useContext, useRef, useState, useEffect} from "react";
import {ProfileContext} from "../Context/contextProfile";
import {Button} from "@material-ui/core"
import {TextField} from "@material-ui/core";
import Backdrop from '@material-ui/core/Backdrop';
import Radio from '@material-ui/core/Radio';
import RadioGroup from '@material-ui/core/RadioGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel'
import FormControl from '@material-ui/core/FormControl';
import {CenterHorizontal} from '../../CenterHorizontal'
export const UserInfo=(props)=>{


    let {handlerSaveUserInfo}=useContext(ProfileContext);
    let [propsState, setProps]=useState(props);
    let [backDrop, setBackDrop]=useState(false);
    useEffect(()=>{
        setProps(props);
    },[props])
    const handler=()=>{
        console.log(propsState.id)
        handlerSaveUserInfo(propsState.id,propsState.name,propsState.aboutme, propsState.gender);
    }

    const handlerOpen=()=>{
        setBackDrop(true);
    }

    const handleClose=()=>{
        setBackDrop(false);
    }

    const handleChange=(e)=>{
        setProps({
            id: propsState.id,
            aboutme: propsState.aboutme,
            name: propsState.name,
            gender:e.target.value
        })
    }


    return(
        <div>
            <Backdrop open={backDrop} style={{zIndex:2}} onClick={handleClose}>

                <div style={{backgroundColor:"white", zIndex:4}} onClick={(event)=>{ event.stopPropagation(); }}>
                <FormControl component="fieldset">
                    <RadioGroup aria-label="gender" name="gender1" onChange={handleChange} value={propsState.gender}>
                        <FormControlLabel value="Мужик" control={<Radio />} label="Мужик" />
                        <FormControlLabel value="Женщина" control={<Radio />} label="Женщина" />
                        <FormControlLabel value="custom" control={<Radio />} label="custom" />
                        <FormControlLabel value="Предпочитаю не указывать" control={<Radio />} label="Предпочитаю не указывать" />
                    </RadioGroup>
                 </FormControl>
                </div>
            </Backdrop>
            <TextField 
                placeholder={"Введите ваше имя"} 
                label="Имя" 
                value={propsState.name}
                onChange={(e)=>{
                    setProps({
                        id: propsState.id,
                        aboutme: propsState.aboutme,
                        name: e.target.value,
                        gender:propsState.gender
                    })
                }}></TextField>
            <br></br>
            <TextField
                label="О себе"
                placeholder={"Введите информацию о себе"} 
                value={propsState.aboutme}
                onChange={(e)=> setProps({
                    id: propsState.id,
                    name: propsState.name,
                    aboutme: e.target.value,
                    gender:propsState.gender
                })}></TextField>
            <br></br>
            <TextField
                onClick={handlerOpen}
                label="Пол"
                value={propsState.gender}>

            </TextField>
            <br></br>
            <CenterHorizontal>
                <Button 
                    color="primary" 
                    variant="contained" 
                    style={{"marginTop":"10px"}}
                    onClick={handler}>Сохранить</Button>
            </CenterHorizontal>
            
            
        </div>
    )
}