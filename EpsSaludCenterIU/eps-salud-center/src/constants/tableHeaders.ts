import {IHeader} from '../interfaces/IMaterialTable' 

export interface dataHeader{
    type:string,
    headers:Array<IHeader>  
}

export const headers=(_type:string):Array<IHeader>=>{
     const obj:Array<dataHeader>=
      [{type:"userList",
         headers :[
            {title:'Primer Nombre',field:'firstName'},
            {title:'Segundo Nombre',field:'middleName'},
            {title:'Apellidos',field:'lastName'},
            {title:'Rol',field:'roleName'},
            {title:'Activo',field:'isActive'}
         ]
        }
    ]
    return obj.find((x:dataHeader)=>
      x.type===_type
    )?.headers!;
}


    
