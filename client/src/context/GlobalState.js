import React, { createContext, useContext, useReducer } from 'react'
import AppReducer from './AppReducer'
import axios from 'axios'
// Initial State
const initialState = {
    transactions: []
}

// Create Context
export const GlobalContext = createContext(initialState);

// Provider Component
export const GlobalProvider = ({ children }) => {
    const [state, dispatch] = useReducer(AppReducer, initialState);


    // Actions

    async function getAllTransactions() {
        try {
            const res = await axios.get('https://localhost:7188/api/transaction');

            dispatch({
                type: 'GET_TRANSACTIONS',
                payload: res.data
            })
        } catch (error) {
            dispatch({
                type: 'TRANSACTION_ERROR',
                payload: error.response
            })
        }
    }

    async function deleteTransaction(id) {

        try {
            const res = await axios.delete(`https://localhost:7188/api/transaction?id=${id}`);

            dispatch({
                type: 'DELETE_TRANSACTION',
                payload: id
            })
        } catch (err) {
            dispatch({
                type: 'TRANSACTION_ERROR',
                payload: err.response
            })
        }
    }
    async function addTransaction(transaction) {

        const config = {
            headers: {
                'Content-Type': 'application/json'
            }
        }

        try {
            const res = await axios.post('https://localhost:7188/api/transaction', transaction, config);
            dispatch({
                type: 'ADD_TRANSACTION',
                payload: res.data
            })
        } catch (err) {
            dispatch({
                type: 'TRANSACTION_ERROR',
                payload: err.response
            })
        }
    }
    return (
        <GlobalContext.Provider value={{
            transactions: state.transactions,
            deleteTransaction,
            addTransaction,
            getAllTransactions
        }}>
            {children}
        </GlobalContext.Provider>
    )
}