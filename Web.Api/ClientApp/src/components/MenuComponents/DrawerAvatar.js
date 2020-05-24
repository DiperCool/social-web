import React, {useState} from "react";
import SwipeableDrawer from '@material-ui/core/SwipeableDrawer';
import {Link} from "react-router-dom"
import {IconButton,List, ListItem, ListItemText,ListItemIcon} from "@material-ui/core";
import MenuIcon from '@material-ui/icons/Menu';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import SettingsIcon from '@material-ui/icons/Settings';

export const DrawerAvatar=({isAuth})=>{



	let ListYes=[
		{
			text: "My profile",
			icon: <AccountCircleIcon/>,
			href: "/myprofile"
		},
		{
			text: "Settings",
			icon: <SettingsIcon/>,
			href:"/profile"
		}
	]

	let ListNo=[
		{
			text: "Login",
			icon: "none",
			href: "/login"
		},
		{
			text: "Register",
			icon: "none",
			href: "/register"
		}
	]

	let [open, setOpen]=useState(false);


	const handler=()=>{
		setOpen(!open);
	}


	const list= isAuth?
                  <List>
					{ListYes.map((el,i)=> 
						<Link
							key={i}
							to={el.href}
							style={{textDecoration:"none", color:"black"}}
							component="button"
							onClick={()=>setOpen(false)}>
							<ListItem button key={i}>
						<ListItemIcon>{el.icon=="none"? null:el.icon}</ListItemIcon>
                      	<ListItemText>
					  		{el.text}						
						</ListItemText>
                    </ListItem>
						</Link>
					)}
                  </List>:
                  <List>
					{ListNo.map((el, i)=>
					<Link
					key={el.id}
					to={el.href}
					style={{textDecoration:"none", color:"black"}}
					component="button"
					onClick={()=>setOpen(false)}>
						<ListItem button key={i}>
							<ListItemIcon>{el.icon=="none"? null:el.icon}</ListItemIcon>
							<ListItemText primary={el.text}/>
						</ListItem>
					</Link>)}
                  </List>

	return(
		<div>
			<IconButton 
				edge="start" 
				color="inherit" 
				aria-label="menu"
				onClick={handler}>
                <MenuIcon />
            </IconButton>
			<SwipeableDrawer
			anchor={"left"}
			open={open}
			onClose={handler}
			onOpen={()=>{}}
			>
				<div style={{width:"250px"}}>
					{list}	
				</div>
			</SwipeableDrawer>
		</div>
	)
}
