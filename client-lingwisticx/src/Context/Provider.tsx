import { ReactNode, useCallback, useReducer } from "react"
import { Context, INITIAL_STATE } from "./Context"
import { ContextActionType } from "./ActionsType";
import { ContextReducer } from "./Reducer";

import axios from 'axios';
import { ILearningSpaceForm } from "../Interfaces/ILearningSpaceFrom";

interface Props {
  children: ReactNode
}

export const ContextProvider = ({children}: Props)=> {
  const [ state, dispatch ] = useReducer(ContextReducer, INITIAL_STATE)


  // THEME
  const toggleTheme = useCallback(()=>{
    dispatch({ type: ContextActionType.ToggleTheme})

  }, [dispatch])

  // LANGUAGES
  const getAllLanguages = useCallback(async ()=>{
    axios.get("http://localhost:5000/api/Languages")
    .then(response=>{
      dispatch({type: ContextActionType.SetAllLanguages, payload: response.data})

    })

  }, [dispatch])


  // LEARNING SPACE
  const closeLearningSpaceForm = useCallback(()=>{
    dispatch({ type: ContextActionType.CloseLearningSpaceForm})
  }, [dispatch])

  const openLearningSpaceForm = useCallback(()=>{
    dispatch({ type: ContextActionType.OpenLearningSpaceForm})
  }, [dispatch])
  
  const createLearningSpace = useCallback(async (values: ILearningSpaceForm) => {
    axios.post("http://localhost:5000/api/LearningSpace", values)
    .then(response=>{
      console.log(response.data)
      console.log(response.status)
    })
    .catch(error =>{
      console.error(error)      
    })

  }, [dispatch])



  // const createLearningSpace = useCallback(()=>{
  //   dispatch({ type: ContextActionType.CreateLearningSpace})

  // }, [dispatch])


  return (
    <Context.Provider
      value={{
        state, 
        toggleTheme, 
        getAllLanguages,
        closeLearningSpaceForm,
        createLearningSpace,
        openLearningSpaceForm,
      }}
    >

      {children}

    </Context.Provider>
  )
}