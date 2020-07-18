import React from "react"
import {TextField, Button} from "@material-ui/core";
export const GroupCreate=()=>{
    return(
        <div>
            <TextField id="standard-basic" label="Логин группы"/>
            <br></br>
            <TextField id="standard-basic" label="Название группы"/>
            <br></br>
            <Button variant="contained" color="primary">Создать</Button>

        </div>
    )
}