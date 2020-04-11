import React, {useEffect} from 'react';
import MaterialTable, { Column } from 'material-table';
import {IMaterialize} from '../../interfaces/IMaterialTable' 



interface TableState {
  columns: Array<Column<any>>;
  data: Array<any>;
}

export default function MaterialTableGeneric(props:IMaterialize<any>):JSX.Element {
  const [state, setState] = React.useState<TableState>({
    columns:[{}],data:[]
  });

  useEffect(() => { 
    if(state.columns!=props.headers && state.data!=props.data){
    setState(
      {
      columns: props.headers,
      data: props.data
      }
      );
    }       
});
  
  
  return (
    <MaterialTable
      title="Editable Example"
      columns={state.columns}
      data={state.data}      
      actions={[
        {
          icon: 'delete',
          tooltip: 'Inhabilitar usuario',
          onClick:(event, rowData) => {
            props.deletecallback(rowData)
          } 
        },{
          icon: 'edit',
          tooltip: 'Editar usuario',
          onClick:(event, rowData) => {
            props.editcallback(rowData)
          } 
        },{
          icon: 'add',
          tooltip: 'Agregar usuario',
          onClick:(event, rowData) => {
            props.addcallback(rowData)
          },
          isFreeAction:true 
        }]}
    />
  );
}