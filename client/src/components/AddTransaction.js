import React, { useState, useContext } from 'react'
import { GlobalContext } from '../context/GlobalState';
export const AddTransaction = () => {
    const { addTransaction } = useContext(GlobalContext);
    const [text, setText] = useState('');
    const [amount, setAmount] = useState(0);
    const ClearFields = () =>{
        setText('');
        setAmount(0);
    }

    const onSubmit = (e) => {
        e.preventDefault();
        const newTransaction = {
            "Text": text,
            "Amount": parseInt(amount)
        }

        addTransaction(newTransaction);
        ClearFields();
    }
    return (
        <div>
            <h3>Add new Transaction</h3>
            <form onSubmit={onSubmit}>
                <div className='form-control'>
                    <label htmlFor='text'>Text</label>
                    <input type="text" value={text} onChange={e => setText(e.target.value)} placeholder='Enter text ...' />
                </div>
                <div className='form-control'>
                    <label htmlFor='amount'>Amount</label>
                    <input type="number" value={amount} onChange={e => setAmount(e.target.value)} placeholder='Enter amount ...' />
                </div>

                <button type='submit' className='btn'>Add Transaction</button>
            </form>
        </div>
    )
}
