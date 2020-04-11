export interface IMaterialize <T> {
    data :Array<T>,
    headers:Array<IHeader>,
    deletecallback:CallableFunction,
    editcallback:CallableFunction,
    addcallback:CallableFunction,
    iconDelete:string
}

export interface IHeader {
    title:string,
    field:string
}