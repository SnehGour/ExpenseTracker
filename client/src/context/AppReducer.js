// When state will change how the application will respond , what action does it takes this is implemented in reducers
export default (state, action) => {
    switch(action.type){
        case 'DELETE_TRANSACTION':
            return {
                ...state,
                transactions:state.transactions.filter(transaction => transaction.id!==action.payload)
            }
        case 'ADD_TRANSACTION':
            return {
                ...state,
                transactions:action.payload
            }
        case 'GET_TRANSACTIONS':
            return{
                ...state,
                transactions:action.payload
            }
        case 'TRANSACTION_ERROR':
            return {
                ...state,
                error:action.payload
            }    
        default:
            return state;
    }
}