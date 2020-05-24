import React from "react";
import {Link} from "react-router-dom";
import { MenuItem, ListItemIcon, Avatar } from "@material-ui/core";

export const UserView=({ava, login})=>{


    return(
        <Link to={"/profileUser/"+login} style={{textDecoration:"none", color:"black"}}>
        <MenuItem>
            <ListItemIcon>
                <Avatar src={ava}/>
            </ListItemIcon>
            {login}
        </MenuItem>
    </Link>
        
    )
}

/* <Link to={"/profileUser/"+login} style={{textDecoration:"none", color:"black"}}>
            <MenuItem>
                <ListItemIcon>
                    <Avatar src={ava}/>
                </ListItemIcon>
                {login}
            </MenuItem>
        </Link> */