import React, { Fragment, useState } from 'react';
import logo from './logo.svg';
import './App.css';

type form = React.FormEvent<HTMLFormElement>;

interface ITodo {
  todo:string,
  check:boolean
};

function App() {
  const [todo,setTodo] = useState<string>('')
  const [todoList,setTodos] = useState<ITodo[]>([])

  const handleSubmit = (e:form):void =>{
    e.preventDefault();
    addTodo(todo);
    setTodo('');
    
  }

  const addTodo =(text:string):void=>{
    const todoListAux:ITodo[] = [... todoList,{todo:text,check:false}];
    setTodos(todoListAux);
  }

  const completeTodo= (index:number):void=>{
    const todoListAux:ITodo[] = [... todoList]
    todoListAux[index].check = !todoListAux[index].check;
    setTodos(todoListAux)
  }

  const removeTodo= (index:number):void=>{
    const todoListAux:ITodo[] = [... todoList]
    todoListAux.splice(index,1);
    setTodos(todoListAux)
  }

  return (
    <Fragment>
      <h1>todo list</h1>
      <form onSubmit={handleSubmit}>
        <input type="text" value={todo} onChange={e=>setTodo(e.target.value)} required/>
        <button type="submit" >Add Todo</button>
      </form>
      <section>
          {todoList.map((todo:ITodo,index:number)=>{
            <Fragment key= {index}>
              <div style={{textDecoration:todo.check?'Line-through':''}} >{todo.todo}</div>
              <button type="button" onClick={()=>{completeTodo(index)}}>{todo.check?'complete':'uncomplete'}</button>
              <button type="button" onClick={()=>{removeTodo(index)}}>&times</button>
            </Fragment>
          })}
      </section>
    </Fragment>
    
  );
}

export default App;
