import React from "react";
import { MenuItem, ListItemIcon, Avatar } from "@material-ui/core";

export const UserView=({ava, login})=>{

    return(
        <MenuItem>
            <ListItemIcon>
                <Avatar src={ava}/>
            </ListItemIcon>
            {login}
        </MenuItem>
    )
}