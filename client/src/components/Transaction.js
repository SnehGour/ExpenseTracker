import React, { useContext, useEffect } from 'react'
import { GlobalContext } from '../context/GlobalState';
export const Transaction = ({ transaction }) => {
 
    const { deleteTransaction } = useContext(GlobalContext);
    const classSign = transaction.amount > 0 ? "plus" : "minus";
    const sign = transaction.amount > 0 ? "+" : "-";
    return (
        <li key={transaction.id} className={classSign}>
            {transaction.text} <span>{sign}{Math.abs(transaction.amount)}₹</span><button onClick={() => deleteTransaction(transaction.id)} className='delete-btn'>x</button>
        </li>
    )
}
