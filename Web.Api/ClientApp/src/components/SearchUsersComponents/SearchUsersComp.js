import React,{useState, useRef, useEffect} from "react";
import { makeStyles,InputBase,fade } from "@material-ui/core";
import SearchIcon from '@material-ui/icons/Search';
import {SearchUsers} from "../../Api/SearchUsersApi/SearchUsers";
import {UserView} from "./UserView";
import { MenuList,Paper,Grow,Popper,ClickAwayListener } from "@material-ui/core";
export const SearchUsersComp=()=>{
    const anchorRef= useRef(null);
    const [open, setOpen]=useState(false)
    const classes=useStyles();
    const [page, setPage]=useState(1);
    const [contains, setContains]=useState("");
    const [users, setUsers]=useState([]);
    const [end, setEnd]=useState(false);


    const handleClose=(e)=>{
        if(e.target.id==="notDisable"){
            return;
        }
        setOpen(false);
    }

    const handlerOpen=(e)=>{
      if(e.target.value===""|| open) return;
      setOpen(true);
    }

    const newUsersHandle=()=>{
      setPage(page+1);
      getUsers(contains, page+1);
    }

    const getUsers=async(contains, page, deleteOld=false)=>{
      let res=await SearchUsers(contains, page);
      if(deleteOld){
        setUsers(res.result);
      }else{
        setUsers([...users, ...res.result]);
      }
      setEnd(res.isEnd)
    }

    const newContains=(e)=>{
      setContains(e.target.value);
    }

    useEffect(()=>{
      if( contains===""){
        setOpen(false);
        return;
      }
      if(!open) setOpen(true);
      let timeout=setTimeout(()=>{
        console.log("new users!!!");
        getUsers(contains, 1, true);
        setPage(1);
      },500)

      return ()=>clearTimeout(timeout);
    }, [contains]);


    return(
        <div>
            
            <div className={classes.search}>
            <div className={classes.searchIcon}>
              <SearchIcon />
            </div>
            <InputBase
              inputRef={anchorRef}
              onChange={newContains}
              onClick={handlerOpen}
              id={"notDisable"}
              placeholder="Search…"
              classes={{
                root: classes.inputRoot,
                input: classes.inputInput,
              }}
              inputProps={{ 'aria-label': 'search' }}
            />
          </div>
            <Popper open={open} anchorEl={anchorRef.current} role={undefined} transition disablePortal>
          {({ TransitionProps, placement }) => (
            <Grow
              {...TransitionProps}
              style={{ transformOrigin: placement === 'bottom' ? 'center top' : 'center bottom' }}
            >
              <Paper>
                <ClickAwayListener onClickAway={handleClose}>
                    <MenuList id="menu-list-grow">
                        {users.map((el,i)=><UserView key={i} login={el.login} ava={el.ava.urlImg}/>)}
                        {!end&&users.length!=0?<button onClick={newUsersHandle}>Загрузить еще</button>:null}
                    </MenuList>
                </ClickAwayListener>
              </Paper>
            </Grow>
          )}
        </Popper>
        </div>
    )
}




const useStyles = makeStyles((theme) => ({
    search: {
      position: 'relative',
      borderRadius: theme.shape.borderRadius,
      backgroundColor: fade(theme.palette.common.white, 0.15),
      '&:hover': {
        backgroundColor: fade(theme.palette.common.white, 0.25),
      },
      marginLeft: 0,
      width: '100%',
      [theme.breakpoints.up('sm')]: {
        marginLeft: theme.spacing(1),
        width: 'auto',
      },
    },
    searchIcon: {
      padding: theme.spacing(0, 2),
      height: '100%',
      position: 'absolute',
      pointerEvents: 'none',
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'center',
    },
    inputRoot: {
      color: 'inherit',
    },
    inputInput: {
      padding: theme.spacing(1, 1, 1, 0),
      paddingLeft: `calc(1em + ${theme.spacing(4)}px)`,
      width: '100%',
      [theme.breakpoints.up('sm')]: {
        width: '20ch',
      },
    },
  }));

