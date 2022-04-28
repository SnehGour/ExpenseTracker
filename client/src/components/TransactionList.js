import React, { useContext, useEffect } from 'react'
import { Transaction } from './Transaction';
import { GlobalContext } from '../context/GlobalState'
export const TransactionList = () => {
    const { transactions, getAllTransactions } = useContext(GlobalContext);

    useEffect(() => {
        getAllTransactions();
    },[]);
    return (
        <div>
            <h3>History</h3>
            <ul  className='list'>
                {transactions.map(transaction => (<Transaction transaction={transaction} />))}
            </ul>
        </div>
    )
}
