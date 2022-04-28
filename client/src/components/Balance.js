import React, { useContext } from 'react'
import { GlobalContext } from '../context/GlobalState'

export const Balance = () => {
    const { transactions } = useContext(GlobalContext);
    let total = 0    

    const amount = transactions.map(transaction => total+=transaction.amount)
    return (
        <div>
            <h4>Your Balance</h4>
            <h1 id='balance'>{total}₹</h1>
        </div>
    )
}
