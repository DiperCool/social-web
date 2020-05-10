import React, {useContext} from "react";
import {AppBar, Typography, Button, Toolbar} from "@material-ui/core"
import { makeStyles } from '@material-ui/core/styles';
import {AvatarMenu} from "./AvatarMenu";
import {DrawerAvatar} from "./DrawerAvatar";
import { UserContext } from "../UserComponent/UserContext";



const useStyles = makeStyles((theme) => ({
    root: {
      flexGrow: 1,
    },
    menuButton: {
      marginRight: theme.spacing(2),
    },
    title: {
      flexGrow: 1,
    },
  }));
export const Menu=()=>{

    let {Auth}= useContext(UserContext);
    const root= useStyles();
    


    let renderLogin=Auth.isAuth?<AvatarMenu url={Auth.ava.urlImg} />: <Button color="inherit">Login</Button>;

    return (
        <div className={root.root}>
          <AppBar position="static">
            <Toolbar>
                <DrawerAvatar isAuth={Auth.isAuth}/>
                <Typography variant="h6" style={{flexGrow:1}}>
                    Social-Web
                </Typography>
                {renderLogin}
              </Toolbar>
          </AppBar>
        </div>
    )
}